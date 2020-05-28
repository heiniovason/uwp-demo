using System;

using BookitLoginUWP.ViewModels;
using Windows.ApplicationModel.LockScreen;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BookitLoginUWP.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            
            bool bookingVerified = false;
            if(bookingVerified)
            {
                /***
                 * https://stackoverflow.com/questions/41220975/uwp-turn-off-kiosk-mode
                 * Add to Package.appxmanifest:
                 *     1) <uap:Extension Category="windows.lockScreenCall" />
                 *     2) <uap:Extension Category="windows.aboveLockScreen" />
                 */
                LockApplicationHost lockHost = LockApplicationHost.GetForCurrentView();
                if (lockHost != null)
                {
                    lockHost.RequestUnlock();
                    // Default login as Guest user
                    // Kiosk Assigned Access to application with Guest account
                    // A restricted service should inform current user if the machine booked withing the next 5min
                    // and that they will want to save their work, and leave the spot.
                }
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("False");
                _ = messageDialog.ShowAsync();
            }
        }
    }
}
