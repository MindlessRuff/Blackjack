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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Blackjack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This method will exit the game when the user clicks exit game button
        /// on the main menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quit_Game(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
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

        /// <summary>
        /// TODO: Set to start mode 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Mode1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GamePage));
        }

        private void Start_Mode2(object sender, RoutedEventArgs e)
        {
            // TODO: MODE 2
        }

        /// <summary>
        /// Closes flyout from Quit Game button if user cancels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Flyout(object sender, RoutedEventArgs e)
        {
            QuitFlyout.Hide();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}