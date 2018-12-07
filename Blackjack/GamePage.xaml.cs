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
        ObservableCollection<String> myHand = new ObservableCollection<string>();

        // The bool and event will control all user buttons
        // whenever the ButtonsEnabled bool is changed in a function.
        // SOURCE: https://stackoverflow.com/questions/23641688/changing-a-label-when-a-bool-variable-turns-true
        private bool _buttons_enabled = true;
        public event PropertyChangedEventHandler PropertyChanged;
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
        /// Page Constructor
        /// </summary>
        public GamePage()
        {
            this.InitializeComponent();
            myHand.Clear();
            // Add initial cards into the playerHand in UI.
            myHand.Add(blackjack.player.playerHand[0]);
            myHand.Add(blackjack.player.playerHand[1]);
            // Bind the UI to myHand
            PlayerHand.ItemsSource = myHand;
            // If first two cards add to 21, call blackjack to print msg and handle logic.
            // Then pass logic to NextRoundUI method.
            if (blackjack.player.handValue == 21)
            {
                NaturalBlackjack();
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
            QuitFlyout.Hide();
        }

        /// <summary>
        /// Pressing settings button will bring up the options menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            CoolMenu.IsPaneOpen = !CoolMenu.IsPaneOpen;
        }

        /// <summary>
        /// Called when the Hit button in the gamePage is pressed by the user.
        /// Adds a card and checks for bust. Also starts a new round when necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Hit(object sender, RoutedEventArgs e)
        {
            try
            {
                blackjack.Hit();    // Hit in blackjack class
            }
            // TODO: Figure out what exceptions can be raised and handle.
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            myHand.Add(blackjack.player.playerHand[blackjack.player.playerHand.Count - 1]);   // Add last card if hit was successful.
            System.Diagnostics.Debug.WriteLine(myHand[myHand.Count - 1]);
            // If bust, reinitialize UI hand to the now-reset Blackjack.cs hand.
            if (blackjack.busted)
            {
                ButtonsEnabled = false;  // Disable user buttons.
                // Display busted message.
                Logo.Visibility = Visibility.Collapsed;
                BustMessage.Visibility = Visibility;
                await Task.Delay(TimeSpan.FromSeconds(5));  // 5 Sec Delay
                BustMessage.Visibility = Visibility.Collapsed;
                Logo.Visibility = Visibility;
                // TODO: WAIT FOR DEALER TO FINISH BEFORE STARTING NEXT ROUND.
                NextRoundUI();
                ButtonsEnabled = true; // Re-Enable buttons after dealing cards.
            }
        }

        private void Stand(object sender, RoutedEventArgs e)
        {
            blackjack.Stand();
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
            // Display blackjack message.
            Logo.Visibility = Visibility.Collapsed;
            PlayerBlackjackMessage.Visibility = Visibility;
            await Task.Delay(TimeSpan.FromSeconds(5));  // 5 Sec Delay
            PlayerBlackjackMessage.Visibility = Visibility.Collapsed;
            Logo.Visibility = Visibility;
            // TODO: WAIT FOR DEALER TO FINISH BEFORE STARTING NEXT ROUND.
            NextRoundUI();
            ButtonsEnabled = true; // Re-Enable buttons after dealing cards.
        }


        /// <summary>
        /// Starts a new round in the UI.
        /// </summary>
        private void NextRoundUI()
        {
            blackjack.NextRound();
            myHand.Clear();
            myHand.Add(blackjack.player.playerHand[0]);
            myHand.Add(blackjack.player.playerHand[1]);
            // Call natural blackjack if player gets 21 on deal.
            if (blackjack.player.handValue == 21)
            {
                NaturalBlackjack();
            }

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
    }
}