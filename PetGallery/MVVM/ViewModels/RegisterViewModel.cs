using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows;
using PetGallery.Core;
using PetGallery.MVVM.Models;

namespace PetGallery.MVVM.ViewModels
{
    public class RegisterViewModel : ObservableObject, IDataErrorInfo
    {
        private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        private string _email = "Enter@email.com";
        private SecureString _password;
        private string _username = "Enter_username";
        public RelayCommand InfoCommand { get; }
        public RelayCommand RegisterCommand { get; }
        public RelayCommand LoginCommand { get; }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            } 
        }

        public SecureString SecurePassword
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        
        public void SetPassword(SecureString pwd)
        {
            SecurePassword = pwd.Copy();
            SecurePassword.MakeReadOnly();
            OnPropertyChanged("PasswordTag");
        }

        public bool PasswordTag
        {
            get { return false; }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            } 
        }

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

        public RegisterViewModel(RelayCommand loginCommand, RelayCommand registerCommand)
        {
            InfoCommand = new RelayCommand(o =>
            {
                IsInfoVisible = IsInfoVisible == Visibility.Visible ? 
                    Visibility.Hidden : Visibility.Visible;
            });

            LoginCommand = loginCommand;
            RegisterCommand = new RelayCommand(o =>
            {
                if (!(IsValidEmail() && IsValidUsername() && IsValidPassword()))
                {
                    return;
                }
                registerCommand.Execute(new UserModel
                {
                    Login = Username,
                    Email = Email,
                    Password = PasswordHasher.GenerateHash(SecurePassword)
                });
            });
        }

        private bool IsValidPassword()
        {
            return SecurePassword.Length is (> 7 and < 25);
        }

        private bool IsValidUsername()
        {
            return !(string.IsNullOrEmpty(Username) || Username.Contains(" "));
           
        }

        private bool IsValidEmail()
        {
            return !(string.IsNullOrEmpty(Email) || !EmailRegex.IsMatch(Email));
        }
        
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Email":
                    {
                        if (!IsValidEmail())
                        {
                            return "Please provide a valid email";
                        } 
                        break;
                    }
                    case "Username":
                    {
                        if (!IsValidUsername())
                        {
                            return "Username shouldn't be empty and shouldn't contain whitespaces";
                        }
                        break;
                    }
                    case "PasswordTag":
                    {
                        if (!IsValidPassword())
                        {
                            return "Password should have between 8 and 24 characters";
                        }
                        break;
                    }
                }

                return null;
            }
        }

        public string Error { get; }
    }
}