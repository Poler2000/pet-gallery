using System;
using System.Windows;
using System.Windows.Controls;
using PetGallery.MVVM.ViewModels;

namespace PetGallery.MVVM.Views
{
    public partial class LoginView : UserControl
    {
        public const string EmailBoxText = "Enter email";
        private const string PasswordBoxText = "Password";
        
        public LoginView()
        {
            InitializeComponent();
            EmailBox.Text = EmailBoxText;
            PasswordBox.Password = PasswordBoxText;
            EmailBox.GotFocus += RemoveEmailText;
            EmailBox.LostFocus += AddEmailText;
            PasswordBox.GotFocus += RemovePasswordText;
            PasswordBox.LostFocus += AddPasswordText;
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
        
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as LoginViewModel)?.SetPassword((sender as PasswordBox)?.SecurePassword);
        }
    }
}