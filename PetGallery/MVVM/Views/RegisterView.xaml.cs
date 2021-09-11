using System;
using System.Windows;
using System.Windows.Controls;
using PetGallery.MVVM.ViewModels;

namespace PetGallery.MVVM.Views
{
    public partial class RegisterView : UserControl
    {
        private const string EmailBoxText = "Enter@email.com";
        private const string UsernameBoxText = "Enter_username";
        private const string PasswordBoxText = "Password";
        
        public RegisterView()
        {
            InitializeComponent();
            EmailBox.Text = EmailBoxText;
            PasswordBox.Password = PasswordBoxText;
            UsernameBox.Text = UsernameBoxText;
            EmailBox.GotFocus += RemoveEmailText;
            EmailBox.LostFocus += AddEmailText;
            PasswordBox.GotFocus += RemovePasswordText;
            PasswordBox.LostFocus += AddPasswordText;
            UsernameBox.GotFocus += RemoveUsername;
            UsernameBox.LostFocus += AddUsername;
        }

        private void RemoveEmailText(object sender, RoutedEventArgs e)
        {
            if (EmailBox.Text == EmailBoxText) 
            {
                EmailBox.Text = "";
            }
        }

        private void AddEmailText(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailBox.Text))
                EmailBox.Text = EmailBoxText;
        }
        
        private void RemovePasswordText(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == PasswordBoxText) 
            {
                PasswordBox.Password = "";
            }
        }

        private void AddPasswordText(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
                PasswordBox.Password = PasswordBoxText;
        }
        
        private void RemoveUsername(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text == UsernameBoxText) 
            {
                UsernameBox.Text = "";
            }
        }

        private void AddUsername(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text))
                UsernameBox.Text = UsernameBoxText;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as RegisterViewModel)?.SetPassword((sender as PasswordBox)?.SecurePassword);
        }
    }
}