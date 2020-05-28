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
            string userInput = LoginTextBox.Text;
            const string secretAnswer = "secret";
            if(userInput== secretAnswer)
            {
                string msg = string.Format("\"{0}\" is the correct answer!", userInput);
                MessageDialog messageDialog = new MessageDialog(msg);
                _ = messageDialog.ShowAsync();
                //if (lockHost != null)
                //{
                //    lockHost.RequestUnlock();
                //}
            }
            else
            {
                string msg = string.Format("\"{0}\" is the wrong answer!", userInput);
                MessageDialog messageDialog = new MessageDialog(msg);
                _ = messageDialog.ShowAsync();
            }
        }
    }
}
