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
        // These need to be outside of the constructor so they can be accessed be the other methods
        Blackjack blackjack = new Blackjack();
        // SaveGame save = new SaveGame();
        ObservableCollection<String> myHand = new ObservableCollection<string>();
        ObservableCollection<String> dealerHand = new ObservableCollection<string>();
        ObservableCollection<String> splitHand = new ObservableCollection<string>();

        // The following bools and event will control all user buttons
        // whenever the ButtonsEnabled or Split bools are changed in a function.
        // SOURCE: https://stackoverflow.com/questions/23641688/changing-a-label-when-a-bool-variable-turns-true
        private bool buttonsEnabled = false;
        private bool splitButtonEnabled = true;
        private bool hintButtonEnabled = false;
        public event PropertyChangedEventHandler PropertyChanged;   // Event handler to handle all events

        private int playerHandValue = 0;      // This int works in the same way ButtonsEnabled does, used in HandValue on event.
        private int dealerHandValue = 0;
        private int splitHandValue = 0;
        private int UIchips = 200;
        private int currentBet = 0;

        /// <summary>
        /// Page Constructor
        /// </summary>
        public GamePage()
        {
            this.InitializeComponent();

            // Bind the UI hands to the player and dealer hands.
            PlayerHand.ItemsSource = myHand;
            DealerHand.ItemsSource = dealerHand;
            WaitForBet();
        }

        /// <summary>
        /// This property will update and control the textblock
        /// with the player's hand value. Necessary for UI to update.
        /// </summary>
        public int PlayerHandValue
        {
            get { return playerHandValue; }
            set
            {
                playerHandValue = value;
                OnPropertyChanged("PlayerHandValue");
            }
        }

        /// <summary>
        /// This property will update and control the textblock
        /// with the dealer's hand value. Necessary for UI to update.
        /// </summary>
        public int DealerHandValue
        {
            get { return dealerHandValue; }
            set
            {
                dealerHandValue = value;
                OnPropertyChanged("DealerHandValue");
            }
        }

        /// <summary>
        /// This will only be utilized when the player decides to split to keep track
        /// of the second hand value
        /// </summary>
        public int SplitHandValue
        {
            get { return splitHandValue; }
            set
            {
                splitHandValue = value;
                OnPropertyChanged("SplitHandValue");
            }
        }

        /// <summary>
        /// Controls the display of chips in the UI.
        /// </summary>
        public int UIChips
        {
            get { return UIchips; }
            set
            {
                UIchips = value;
                OnPropertyChanged("UIChips");
            }
        }

        /// <summary>
        /// Controls the display of the user's current bet in UI.
        /// </summary>
        public int CurrentBet
        {
            get { return currentBet; }
            set
            {
                currentBet = value;
                OnPropertyChanged("CurrentBet");
            }
        }

        /// <summary>
        /// Creates a bool that can be changed using an event handler.
        /// Bound to all user buttons, other than hint and split, that need to be toggled.
        /// </summary>
        public bool ButtonsEnabled
        {
            get { return buttonsEnabled; }
            set
            {
                buttonsEnabled = value;
                OnPropertyChanged("ButtonsEnabled");
            }
        }

        /// <summary>
        /// Creates a bool that can be changed using an event handler.
        /// Bound to the split button that will only be toggled with two equal-faced cards on deal.
        /// </summary>
        public bool SplitButtonEnabled
        {
            get { return splitButtonEnabled; }
            set
            {
                splitButtonEnabled = value;
                OnPropertyChanged("SplitButtonEnabled");
            }
        }

        /// <summary>
        /// Toggles hint button as necessary when event is raised
        /// </summary>
        public bool HintButtonEnabled
        {
            get { return hintButtonEnabled; }
            set
            {
                hintButtonEnabled = value;
                OnPropertyChanged("HintButtonEnabled");
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
        /// This method waits for a bet to be placed before enabling the buttons
        /// </summary>
        private void WaitForBet()
        {
            CurrentBet = 0;
            UIChips = blackjack.availableChips; // Update chip values with winnings
            // Display a message prompting user to bet and display the bet button.
            PlayerBlackjackMessage.Text = "Place Your Bet";
            PlayerBlackjackMessage.Visibility = Visibility.Visible;
            BetButton.Visibility = Visibility.Visible;
            SplitStack.Visibility = Visibility.Collapsed;
            // Fix other buttons.
            ButtonsEnabled = false;
            HintButtonEnabled = false;
            //SplitButtonEnabled = false;
            HitButton.Content = "Hit";
            StandButton.Content = "Stand";
            // Reset variables.
            PlayerHandValue = 0;
            DealerHandValue = 0;
            SplitHandValue = 0;
            // Start a new round in the backend.
            blackjack.NextRound();

            // Reset the UI representation of the hands.
            myHand.Clear();
            dealerHand.Clear();
            splitHand.Clear();
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
            //SplitButtonEnabled = false;
            HintButtonEnabled = false;
            try
            {  
                // If split and left hand is no longer in play, hit the split hand.
                if (blackjack.split && (blackjack.player.busted || blackjack.stand))
                {
                    blackjack.Hit(blackjack.splitPlayer);
                    splitHand.Add(blackjack.splitPlayer.hand[blackjack.splitPlayer.hand.Count - 1]);   // Add card to UI hand
                    SplitHandValue = blackjack.splitPlayer.handValue;
                    // When the split hand busts, call stand automatically.
                    if (blackjack.splitPlayer.busted && !blackjack.player.busted)
                    {
                        Stand(this, e);
                        return;
                    }
                }
                // Hit the player hand if no split or left hand is finished during a split.
                else
                {
                    blackjack.Hit(blackjack.player);
                    myHand.Add(blackjack.player.hand[blackjack.player.hand.Count - 1]);   // Add card to UI hand
                    PlayerHandValue = blackjack.player.handValue;
                    // Change hit button when left hand busts.
                    if (blackjack.player.busted && blackjack.split)
                    {
                        splitHand.Add(blackjack.splitPlayer.hand[1]);       // "Deal" 2nd split card.
                        SplitHandValue = blackjack.splitPlayer.handValue;
                        HintButtonEnabled = true;
                        HitButton.Content = "Hit-Right";
                        StandButton.Content = "Stand-Right";
                    }
                }
            }
            // TODO: Figure out what exceptions can be raised and handle.
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            // If bust, reinitialize UI hand to the now-reset Blackjack.cs hand. Called on a split only if both hands have busted.
            if ((!blackjack.split && blackjack.player.busted) || (blackjack.splitPlayer.busted && blackjack.player.busted))
            {
                await Task.Delay(TimeSpan.FromSeconds(0.5));

                // Display busted message.
                BustMessage.Visibility = Visibility;

                // Reveal dealer's 2nd card.
                DealerCardBack.Visibility = Visibility.Collapsed;
                dealerHand.Add(blackjack.dealer.hand[1]);
                DealerHandValue = blackjack.dealer.handValue;

                Loading.IsActive = true;                        // Loading ring on
                await Task.Delay(TimeSpan.FromSeconds(3));      // 3 Sec Delay
                BustMessage.Visibility = Visibility.Collapsed;

                Loading.IsActive = false;                       // Loading ring off

                WaitForBet();
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
            if (blackjack.split && !blackjack.stand && !blackjack.player.busted)        // If hand is split, and stand clicked for the first time.
            {
                blackjack.stand = true;
                splitHand.Add(blackjack.splitPlayer.hand[1]);       // "Deal" 2nd split card.
                SplitHandValue = blackjack.splitPlayer.handValue;
                HintButtonEnabled = true;                           // Enable the hit button for the split hand after left hand stands
                HitButton.Content = "Hit-Right";
                StandButton.Content = "Stand-Right";              
                return;
            }

            ButtonsEnabled = false;      // Disable user buttons.
            //SplitButtonEnabled = false;
            HintButtonEnabled = false;
            // Reveal dealer's 2nd card.
            DealerCardBack.Visibility = Visibility.Collapsed;
            dealerHand.Add(blackjack.dealer.hand[1]);
            DealerHandValue = blackjack.dealer.handValue;

            blackjack.Stand();

            // Check for dealer natural blackjack.
            if (blackjack.dealer.naturalBlackjack)
            {
                // Change message and display.
                PlayerBlackjackMessage.Text = "Dealer Blackjack";
                PlayerBlackjackMessage.Visibility = Visibility.Visible;

                // Delay before dealing new cards.
                Loading.IsActive = true;                        // Loading ring on
                await Task.Delay(TimeSpan.FromSeconds(3));      // 3 Sec Delay
                PlayerBlackjackMessage.Visibility = Visibility.Collapsed;

                Loading.IsActive = false;                       // Loading ring off

            }

            // Dealer hits until busting or hard > 17, will only run if player hasn't busted.
            else if (!blackjack.player.busted || (blackjack.split && !blackjack.splitPlayer.busted))
            {
                
                // Try-catch block will attempt until failure, adding a new card to the
                // UI hand while cards exist in the Player class hand
                bool success = false;   // Tracks if card was successfully added to allow retrying of block.
                do
                {
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));                                  // 1 Sec Delay between dealer cards.
                        dealerHand.Add(blackjack.dealer.hand[dealerHand.Count]);
                        int temp = blackjack.dealer.Card_Value(blackjack.dealer.hand[dealerHand.Count-1]);     // Get value of last card added.
                        // If it returned as a one, need to remove one from numOnes or the UI hand value will be 10 lower than it should be.
                        if (temp == 1)                  
                        {
                            blackjack.dealer.numOnes -= 1;
                        }
                        DealerHandValue += temp;        // Add the value to UI hand.
                        // Correct UI hand value for aces if necessary.
                        if (blackjack.dealer.numOnes > 0 && dealerHandValue > 10)
                        {
                            DealerHandValue -= 10;
                            blackjack.dealer.numOnes -= 1;
                        }

                        success = true;
                    }
                    catch (ArgumentOutOfRangeException)     // Exception is thrown when there are no more cards to add to dealer UI hand from blackjack dealer hand.
                    {
                        DealerHandValue = blackjack.dealer.handValue;
                        // Change display message based on hand values and display.
                        PlayerBlackjackMessage.Text = blackjack.CalculateWinner();
                        PlayerBlackjackMessage.Visibility = Visibility.Visible;

                        // Delay before dealing new cards.
                        Loading.IsActive = true;                        // Loading ring on
                        await Task.Delay(TimeSpan.FromSeconds(3));      // 3 Sec Delay

                        PlayerBlackjackMessage.Visibility = Visibility.Collapsed;
                        Loading.IsActive = false;                       // Loading ring off
                        success = false;
                    }
                } while (success);
            }
            WaitForBet();
        }

        /// <summary>
        /// This method handles the logic for when a player hits the DoubleDown button
        /// Gives double the userBet after dealing one card to the player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleDown(object sender, RoutedEventArgs e)
        {
            ButtonsEnabled = false;
            HintButtonEnabled = false;

            UIChips = UIChips - CurrentBet;
            CurrentBet = CurrentBet * 2;    // Double current bet in the UI.

            blackjack.DoubleDown();
            Hit(this, e);
            ButtonsEnabled = false;


            if (!blackjack.player.busted)
                Stand(this, e);
        }

        /// <summary>
        /// This method handles the Split button and will create an extra split hand
        /// to display when the user is able to split a pair
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Split(object sender, RoutedEventArgs e)
        {
            //SplitButtonEnabled = false;
            buttonsEnabled = false;
            blackjack.Split();
            // Enable the split hand in the UI.
            SplitHand.ItemsSource = splitHand;
            // Double current bet in UI.
            UIChips = UIChips - CurrentBet;
            CurrentBet = CurrentBet * 2;
            // Split the cards.
            splitHand.Add(myHand[1]);
            myHand.RemoveAt(1);
            // Enable the split stack in the UI and calculate the value.
            SplitHandValue = blackjack.player.Card_Value(blackjack.splitPlayer.hand[0]);
            SplitStack.Visibility = Visibility.Visible;
            // Add the initially dealt card to player UI hand.
            myHand.Add(blackjack.player.hand[1]);
            PlayerHandValue = blackjack.player.handValue;

            HitButton.Content = "Hit-Left";
            StandButton.Content = "Stand-Left";
            buttonsEnabled = true;
        }

        private async void Surrender(object sender, RoutedEventArgs e)
        {
            ButtonsEnabled = false;
            CurrentBet = CurrentBet / 2;
            blackjack.Surrender();
            PlayerBlackjackMessage.Text = "You Surrendered!";
            PlayerBlackjackMessage.Visibility = Visibility.Visible;

            // Delay before dealing new cards.
            Loading.IsActive = true;                        // Loading ring on
            await Task.Delay(TimeSpan.FromSeconds(3));      // 3 Sec Delay

            PlayerBlackjackMessage.Visibility = Visibility.Collapsed;
            Loading.IsActive = false;                       // Loading ring off

            DealerCardBack.Visibility = Visibility.Collapsed;
            WaitForBet();
        }

        /// <summary>
        /// A natural blackjack occurs when the initial two cards dealt
        /// to the player are 21. This method prints a message, automatically stands,
        /// and pays out 1.5x the initial bet. If dealer also has natural blackjack (not just 21!) -> push.
        /// </summary>
        private async void NaturalBlackjack()
        {
            ButtonsEnabled = false;  // Disable user buttons.
            

            // Change the message text and display to user.
            if (blackjack.dealer.naturalBlackjack)
            {
                PlayerBlackjackMessage.Text = "Push!";
            }
            else
            {
                PlayerBlackjackMessage.Text = "Blackjack!";
            }
            PlayerBlackjackMessage.Visibility = Visibility;

            // Reveal dealer's hand
            DealerCardBack.Visibility = Visibility.Collapsed;
            dealerHand.Add(blackjack.dealer.hand[1]);
            DealerHandValue = blackjack.dealer.handValue;

            Loading.IsActive = true;                    // Loading ring on
            await Task.Delay(TimeSpan.FromSeconds(3));  // 3 Sec Delay
            Loading.IsActive = false;                   // Loading ring off
            PlayerBlackjackMessage.Visibility = Visibility.Collapsed;

            WaitForBet();
        }


        /// <summary>
        /// Starts a new round in the UI.
        /// </summary>
        private async void NextRoundUI()
        {
            blackjack.playerBet = CurrentBet;      // Set current bet in blackjack class for payout calculation.
            // Generate hands.
            await Task.Delay(TimeSpan.FromSeconds(0.7));
            myHand.Add(blackjack.player.hand[0]);
            PlayerHandValue = blackjack.player.Card_Value(blackjack.player.hand[0]);            // Update player UI hand value.

            await Task.Delay(TimeSpan.FromSeconds(0.7));                                        // 700 ms delay between cards.
            DealerCardBack.Visibility = Visibility.Visible;                                     // Don't show dealer's first card initially.
            await Task.Delay(TimeSpan.FromSeconds(0.7));  

            myHand.Add(blackjack.player.hand[1]);
            PlayerHandValue = blackjack.player.handValue;                                       // Update player UI hand value with 2nd card.
            await Task.Delay(TimeSpan.FromSeconds(0.7));

            dealerHand.Add(blackjack.dealer.hand[0]);
            DealerHandValue = blackjack.dealer.Card_Value(blackjack.dealer.hand[0]);            // Update dealer UI hand value with 1st card only.

            // Call natural blackjack if player gets 21 on deal.
            if (blackjack.player.handValue == 21)
            {
                NaturalBlackjack();
                return;
            }

            // Check for Split by comparing the card ranks.
            if (myHand[0][7] == myHand[1][7])
            {
                SplitButtonEnabled = true;
            }
            HintButtonEnabled = true;
            ButtonsEnabled = true;
        }

        /// Displays a hint to the user, based on which hand is in play.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Hint_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog myMessage2;
            // If hand is split, and split hand is in play, display a hint for the split hand.
            if (blackjack.split && (blackjack.player.busted || blackjack.stand))
            {
                myMessage2 = new MessageDialog($"{Strategy.Hints(blackjack.splitPlayer.hand[0], blackjack.splitPlayer.hand[1], blackjack.dealer.hand[1])}");
            }
            else
            {
                myMessage2 = new MessageDialog($"{Strategy.Hints(blackjack.player.hand[0], blackjack.player.hand[1], blackjack.dealer.hand[1])}");
            }
            await myMessage2.ShowAsync();
        }


        private async void BetButton_Click(object sender, RoutedEventArgs e)
        {
            if (UIChips >= 20)
            {
                CurrentBet += 20;
                UIChips -= 20;
                DealButton.Visibility = Visibility.Visible;
            }
            else
            {
                MessageDialog myMessage = new MessageDialog("Not enough chips to place a bet, try getting more chips from the settings menu.");
                await myMessage.ShowAsync();
            }
        }

        /// <summary>
        /// Hides the deal button and starts the round after user has bet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DealButton_Click(object sender, RoutedEventArgs e)
        {
            DealButton.Visibility = Visibility.Collapsed;
            PlayerBlackjackMessage.Visibility = Visibility.Collapsed;
            BetButton.Visibility = Visibility.Collapsed;
            NextRoundUI();
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
        /// Controls all the menu options on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RulesListBox.IsSelected)
            {
                MessageDialog myMessage = new MessageDialog("BlackJack Rules: The dealer deals the cards and runs all the action at the blackjack table.\n" +
                    "The game starts after the player places their bet. Blackjack games use chips instead of cash. You'll buy your chips from the side menu bar.\n" +
                    "You should buy your chips between hands, don't try to interrupt a hand that's being played to get chips.\n" +
                    "Once you and any other players have placed your bets, the dealer starts the game.\n" +
                    "The game begins when the dealer deals 2 cards. The dealer deals himself a 2 card hand, but he deals himself one card face up and the other card face down.\n" +
                    "This is important, because that face up card gives the player a lot of information about how she should play her hand. Since you're starting with a 2 card hand, " +
                    "the highest possible total you could have is 21 - that's an ace (which counts as 11) and a ten.");
                await myMessage.ShowAsync();
            }
            else if (MoreChips.IsSelected)
            {
                if (UIchips <= 100)
                {
                    MessageDialog myMessage = new MessageDialog("So you used up all your chips? Don't worry here's another 100. Enjoy.");
                    await myMessage.ShowAsync();
                    UIChips += 100;
                    blackjack.availableChips += 100;
                }
                else
                {
                    MessageDialog myMessage2 = new MessageDialog("You have more than enough chips!!");
                    await myMessage2.ShowAsync();
                }

            }
            else if (InfoBox.IsSelected)
            {
                MessageDialog myMessage2 = new MessageDialog(
                    "Brandon, " +
                    "Carlo, " +
                    "Ferdinand, " +
                    "Matt, " +
                    "Huy, " +
                    "Anush. ");
                await myMessage2.ShowAsync();

            }
            else if (ReturnPage.IsSelected)
            {
                Frame.Navigate(typeof(MainPage));
            }
        }
    }
}