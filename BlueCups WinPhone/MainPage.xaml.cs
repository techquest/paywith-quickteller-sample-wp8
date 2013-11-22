using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BlueCups.Resources;
using Quickteller.Sdk.Wp8;

namespace BlueCups
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Put your developer.interswitchng.com client id and secret key here
        private const string CLIENT_ID = "XXXXXXXXXXXXXXXXXX";
        private const string CLIENT_SECRET = "XXXXXXXXXXXXXXXXX";

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnTechQuest_Click(object sender, RoutedEventArgs e)
        {
            PerformPaymentOperation(3000);
        }

        private void btnInfoTech_Click(object sender, RoutedEventArgs e)
        {
            PerformPaymentOperation(2500);
        }

        private void btnSettlement_Click(object sender, RoutedEventArgs e)
        {
            PerformPaymentOperation(2000);
        }

        private void PerformPaymentOperation(long amount)
        {
            var quicktellerPayment = new QuicktellerPayment(this, "10402", amount, "0000000001", CLIENT_ID, CLIENT_SECRET);
            quicktellerPayment.OnPaymentCompleted += (string code, string message) =>
            {
                NavigationService.Navigate(new Uri("/PaymentSuccessful.xaml", UriKind.Relative));
            };

            quicktellerPayment.OnPaymentException += (Exception exception) =>
            {
                NavigationService.Navigate(new Uri("/PaymentFailed.xaml?error=" + exception.Message, UriKind.Relative));
            };

            quicktellerPayment.DoPaymentAsync();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}