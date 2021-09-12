using System;
using System.ComponentModel;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows;
using PetGallery.Core;
using PetGallery.MVVM.Models;
using PetGallery.MVVM.Views;

namespace PetGallery.MVVM.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        public RelayCommand InfoCommand { get; set; }
        public RelayCommand RegisterCommand { get; set; }
        public RelayCommand LoginCommand { get; set; }

        private string _email;
        private Visibility _isInfoVisible = Visibility.Hidden;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            } 
        }

        private SecureString SecurePassword { get; set; }

        public Visibility IsInfoVisible
        {
            get => _isInfoVisible;
            set
            {
                _isInfoVisible = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel(RelayCommand loginCommand, RelayCommand registerCommand)
        {
            InfoCommand = new RelayCommand(o =>
            {
                IsInfoVisible = IsInfoVisible == Visibility.Visible ? 
                                Visibility.Hidden : Visibility.Visible;
            });
            LoginCommand = new RelayCommand(o =>
            {
                loginCommand.Execute(GetFormData());
            });
            
            RegisterCommand = new RelayCommand(o =>
            {
                registerCommand.Execute(GetFormData());
            });
        }

        private UserModel GetFormData()
        {
            var userData = new UserModel
            {
                Email = Email,
                Password = PasswordHasher.GenerateHash(SecurePassword)
            };
            return userData;
        }

        public void SetPassword(SecureString pwd)
        {
            SecurePassword = pwd.Copy();
            SecurePassword.MakeReadOnly();
        }

        public void Reset()
        {
        }
    }
}