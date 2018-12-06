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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Blackjack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        // These need to be outside of the constructor so they can be acessed be the other methods!!!!!
        Blackjack blackjack = new Blackjack();
        ObservableCollection<String> myHand = new ObservableCollection<string>();
        
        public GamePage()
        {
            this.InitializeComponent();
            myHand.Clear();
            // Add initial cards into the playerHand in UI.
            myHand.Add(blackjack.player.playerHand[0]);
            myHand.Add(blackjack.player.playerHand[1]);
            // Bind the UI to myHand
            PlayerHand.ItemsSource = myHand;
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
            ReturnToTitleFlyout.Hide();
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
        /// Toggles option one depending on which radio button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Toggle_Option_1(object sender, RoutedEventArgs e)
        {
            // TODO: FIGURE OUT OPTION 1 AND CHANGE NAME IN XAML
        }

        // TODO: KEEP OPTIONS CHECKED BETWEEN PAGE CHANGES.

        /// <summary>
        /// Toggles option two depending on which radio button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Toggle_Option_2(object sender, RoutedEventArgs e)
        {
            // TODO: FIGURE OUT OPTION 2 AND CHANGE NAME IN XAML
        }

        
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
                HitButton.IsEnabled = false;
                Logo.Visibility = Visibility.Collapsed;
                BustMessage.Visibility = Visibility;
                await Task.Delay(TimeSpan.FromSeconds(5));
                BustMessage.Visibility = Visibility.Collapsed;
                Logo.Visibility = Visibility;
                HitButton.IsEnabled = true;
                // TODO: DISPLAY BUSTED MESSAGE BEFORE RESETTING HAND.
                blackjack.NextRound();
                myHand.Clear();
                myHand.Add(blackjack.player.playerHand[0]);
                myHand.Add(blackjack.player.playerHand[1]);
            }

        }

        private void Stand(object sender, RoutedEventArgs e)
        {
            blackjack.Stand();
        }

        private void BetAmount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog myMessage = new MessageDialog("BlackJack Rules: The dealer deals the cards and runs all the action at the blackjack table. " +
                "The game starts after the player places their bet.Blackjack games use chips instead of cash.You'll buy your chips from the side menu bar. " +
                "You should buy your chips between hands—don't try to interrupt a hand that's being played to get chips." +
                "You place your bet by putting your chips in the designated spot in front of your seat. " +
                "It's a circle drawn onto the table. Once you and the other players have placed their bets, the dealer starts the game." +
                "The game begins when the dealer deals 2 cards.The dealer deals himself a 2 card hand, but he deals himself one card face up and the other card face down." +
                "This is important, because that face up card gives the player a lot of information about how she should play her hand.Since you're starting with a 2 card hand, " +
                "the highest possible total you could have is 21—that's an ace(which counts as 11) and a ten.Once all the cards are dealt, the dealer peeks to see if he has blackjack. " +
                "If he doesn't, then the players get to decide how to play their hands.");
            myMessage.ShowAsync();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog myMessage2 = new MessageDialog("Brandon, " +
                "Carlo, " +
                "Ferdinand, " +
                "Matt, " +
                "Huy, " +
                "Anush. ");
            myMessage2.ShowAsync();
        }
    }
}