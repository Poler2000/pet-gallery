using System;
using System.Windows;
using PetGallery.Core;
using PetGallery.MVVM.Models;

namespace PetGallery.MVVM.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        public RelayCommand InfoCommand { get; set; }
        public RelayCommand RegisterCommand { get; set; }
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand LoginCommandCallback { get; set; }
        public RelayCommand RegisterCommandCallback { get; set; }
        
        public string Username { get; set; }
        public string Password { get; set; }

        private Visibility _isInfoVisible = Visibility.Hidden;
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
                Email = Username,
                Password = Password
            };
            return userData;
        }
    }
}