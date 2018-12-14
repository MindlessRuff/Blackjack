using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.ComponentModel;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Blackjack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page, INotifyPropertyChanged
    {
        // These need to be outside of the constructor so they can be acessed be the other methods
        Blackjack blackjack = new Blackjack();
        SaveGame save = new SaveGame();
        ObservableCollection<String> myHand = new ObservableCollection<string>();
        ObservableCollection<String> dealerHand = new ObservableCollection<string>();

        // The following bool and event will control all user buttons
        // whenever the ButtonsEnabled bool is changed in a function.
        // SOURCE: https://stackoverflow.com/questions/23641688/changing-a-label-when-a-bool-variable-turns-true
        private bool _buttons_enabled = true;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Page Constructor
        /// </summary>
        public GamePage()
        {
            this.InitializeComponent();

            // Bind the UI hands to the player and dealer hands.
            PlayerHand.ItemsSource = myHand;
            DealerHand.ItemsSource = dealerHand;
            NextRoundUI();
        }

        /// <summary>
        /// Creates a bool that can be changed using an event handler.
        /// Bound to all user buttons that need to be toggled.
        /// </summary>
        public bool ButtonsEnabled
        {
            get { return _buttons_enabled; }
            set
            {
                _buttons_enabled = value;
                OnPropertyChanged("ButtonsEnabled");
            }
        }

        /// <summary>
        /// Event handler for the user button toggle.
        /// </summary>
        /// <param name="propName"></param>
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        /// <summary>
        /// Returns to title screen from game page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Return_Title(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// Closes flyout from return to title screen if user cancels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Flyout(object sender, RoutedEventArgs e)
        {
            //QuitFlyout.Hide();
        }

        /// <summary>
        /// Pressing settings button will bring up the options menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings.IsPaneOpen = !Settings.IsPaneOpen;
        }

        /// <summary>
        /// Called when the Hit button in the gamePage is pressed by the user.
        /// Adds a card and checks for bust. Also starts a new round when necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Hit(object sender, RoutedEventArgs e)
        {
            // Turn buttons off immediately to prevent user from spamming hit button.
            ButtonsEnabled = false;

            try
            {
                blackjack.Hit();    // Hit in blackjack class
            }
            // TODO: Figure out what exceptions can be raised and handle.
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            myHand.Add(blackjack.player.hand[blackjack.player.hand.Count - 1]);   // Add last card if hit was successful.

            // If bust, reinitialize UI hand to the now-reset Blackjack.cs hand.
            if (blackjack.player.busted)
            {
                await Task.Delay(TimeSpan.FromSeconds(0.5));

                // Display busted message.
                Logo.Visibility = Visibility.Collapsed;
                BustMessage.Visibility = Visibility;
                // Reveal dealer's 2nd card.
                DealerCardBack.Visibility = Visibility.Collapsed;
                dealerHand.Add(blackjack.dealer.hand[1]);

                Loading.IsActive = true;                        // Loading ring on
                await Task.Delay(TimeSpan.FromSeconds(3));      // 3 Sec Delay
                BustMessage.Visibility = Visibility.Collapsed;  // Logo back on
                Logo.Visibility = Visibility;
                Loading.IsActive = false;                       // Loading ring off

                NextRoundUI();
            }
            else ButtonsEnabled = true;
        }

        /// <summary>
        /// This will call the blackjack stand function, which initiates the dealer
        /// logic until end of round.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Stand(object sender, RoutedEventArgs e)
        {
            ButtonsEnabled = false;  // Disable user buttons.
            blackjack.Stand();
            // Reveal dealer's 2nd card.
            DealerCardBack.Visibility = Visibility.Collapsed;
            dealerHand.Add(blackjack.dealer.hand[1]);

            // Check for dealer natural blackjack.
            if (blackjack.dealer.naturalBlackjack)
            {
                // Change message and display.
                PlayerBlackjackMessage.Text = "Dealer Blackjack, You Lose.";
                Logo.Visibility = Visibility.Collapsed;
                PlayerBlackjackMessage.Visibility = Visibility.Visible;

                // Delay and turn logo on before dealing new cards.
                Loading.IsActive = true;                        // Loading ring on
                await Task.Delay(TimeSpan.FromSeconds(3));      // 3 Sec Delay
                Logo.Visibility = Visibility;
                Loading.IsActive = false;                       // Loading ring off

            }
            // Dealer hits until busting or hard > 17, will only run if player hasn't busted.
            else if (!blackjack.player.busted)
            {
                
                /* Try-catch block will attempt until failure, adding a new card to the
                 * UI hand while cards exist in the Player class hand
                */
                bool success = false;   // Tracks if card was successfully added to allow retrying of block.
                do
                {
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));  // 1 Sec Delay between dealer cards.
                        dealerHand.Add(blackjack.dealer.hand[dealerHand.Count]);
                        success = true;
                    }
                    catch (ArgumentOutOfRangeException)     // No more cards to add.
                    {
                        // Change display message based on hand values and display.
                        if (blackjack.player.handValue > blackjack.dealer.handValue) PlayerBlackjackMessage.Text = "You Win!";
                        else if (blackjack.player.handValue < blackjack.dealer.handValue) PlayerBlackjackMessage.Text = "You Lose!";
                        else PlayerBlackjackMessage.Text = "Push!";

                        // TODO: Change display message/delay to its own function.
                        Logo.Visibility = Visibility.Collapsed;
                        PlayerBlackjackMessage.Visibility = Visibility.Visible;

                        // Delay and turn logo on before dealing new cards.
                        Loading.IsActive = true;                        // Loading ring on
                        await Task.Delay(TimeSpan.FromSeconds(3));      // 3 Sec Delay

                        PlayerBlackjackMessage.Visibility = Visibility.Collapsed;
                        Logo.Visibility = Visibility;
                        Loading.IsActive = false;                       // Loading ring off
                        success = false;
                    }
                } while (success);
            }
            NextRoundUI();
        }

        private void BetAmount_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Print rules upon button press.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog myMessage = new MessageDialog("BlackJack Rules: The dealer deals the cards and runs all the action at the blackjack table.\n" +
                "The game starts after the player places their bet.Blackjack games use chips instead of cash. You'll buy your chips from the side menu bar.\n" +
                "You should buy your chips between hands, don't try to interrupt a hand that's being played to get chips.\n" +
                "You place your bet by putting your chips in the designated spot in front of your seat.\n" +
                "It's a circle drawn onto the table. Once you and the other players have placed their bets, the dealer starts the game.\n" +
                "The game begins when the dealer deals 2 cards.The dealer deals himself a 2 card hand, but he deals himself one card face up and the other card face down.\n" +
                "This is important, because that face up card gives the player a lot of information about how she should play her hand. Since you're starting with a 2 card hand, " +
                "the highest possible total you could have is 21 - that's an ace (which counts as 11) and a ten.\nOnce all the cards are dealt, the dealer peeks to see if he has blackjack. " +
                "If he doesn't, then the players get to decide how to play their hands.");
             await myMessage.ShowAsync();
        }

        /// <summary>
        /// Print creators upon button press.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button4_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog myMessage2 = new MessageDialog("Brandon, " +
                "Carlo, " +
                "Ferdinand, " +
                "Matt, " +
                "Huy, " +
                "Anush. ");
            await myMessage2.ShowAsync();
        }

        /// <summary>
        /// A natural blackjack occurs when the initial two cards dealt
        /// to the player are 21. This method prints a message, automatically stands,
        /// and pays out 1.5x the initial bet. If dealer also has natural blackjack (not just 21!) -> push.
        /// </summary>
        private async void NaturalBlackjack()
        {
            ButtonsEnabled = false;  // Disable user buttons.
            
            Logo.Visibility = Visibility.Collapsed;
            // Change the message text and display to user.
            PlayerBlackjackMessage.Text = "Blackjack!";
            PlayerBlackjackMessage.Visibility = Visibility;

            Loading.IsActive = true;                    // Loading ring on
            await Task.Delay(TimeSpan.FromSeconds(3));  // 3 Sec Delay
            Loading.IsActive = false;                   // Loading ring off
            PlayerBlackjackMessage.Visibility = Visibility.Collapsed;
            Logo.Visibility = Visibility;

            NextRoundUI();
        }


        /// <summary>
        /// Starts a new round in the UI.
        /// </summary>
        private async void NextRoundUI()
        {
            ButtonsEnabled = false;
            blackjack.NextRound();

            // Reset the UI representation of the hands.
            myHand.Clear();
            dealerHand.Clear();

            Loading.IsActive = true;
            // Generate hands.
            await Task.Delay(TimeSpan.FromSeconds(0.7));
            myHand.Add(blackjack.player.hand[0]);
            await Task.Delay(TimeSpan.FromSeconds(0.7));        // 700 ms delay between cards.
            DealerCardBack.Visibility = Visibility.Visible;     // Don't show dealer's first card initially.
            await Task.Delay(TimeSpan.FromSeconds(0.7));  
            myHand.Add(blackjack.player.hand[1]);
            await Task.Delay(TimeSpan.FromSeconds(0.7));
            dealerHand.Add(blackjack.dealer.hand[0]);
            Loading.IsActive = false;

            // Call natural blackjack if player gets 21 on deal.
            if (blackjack.player.handValue == 21)
            {
                NaturalBlackjack();
            }
            ButtonsEnabled = true;
        }

        /// <summary>
        /// Exits game on player confirmation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quit_Game(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}