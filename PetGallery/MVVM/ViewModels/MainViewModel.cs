using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using PetGallery.Core;
using PetGallery.DB;
using PetGallery.MVVM.Models;

namespace PetGallery.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ExploreViewCommand { get; set; }
        public RelayCommand MyCollectionsViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }

        private RelayCommand LoginCommand { get; set; }
        private RelayCommand RegisterCommand { get; set; }

        private ObservableObject _currentView;
        private readonly UserManager _userManager;
        
        public ObservableObject CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        
        private Visibility _menuVisibility = Visibility.Hidden;

        public Visibility MenuVisibility
        {
            get => _menuVisibility;
            set
            {
                _menuVisibility = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            PrepareCommands();
            _userManager = new UserManager(new SqliteDataAccess());
            CurrentView = new LoginViewModel(LoginCommand, RegisterCommand);
        }

        private void PrepareCommands()
        {
            ExploreViewCommand = new RelayCommand(o =>
            {
                CurrentView = new ExploreViewModel();
                string pet = o as string;
                if (pet is not null)
                {
                    (CurrentView as ExploreViewModel)?.Reload(pet);
                }
            });

            MyCollectionsViewCommand = new RelayCommand(o =>
            {
                CurrentView = new MyCollectionsViewModel();
            });
            
            HomeViewCommand = new RelayCommand(o => { CurrentView = new HomeViewModel(ExploreViewCommand); });

            SettingsViewCommand = new RelayCommand(o => { CurrentView = new SettingsViewModel(); });

            LoginCommand = new RelayCommand(o =>
            {
                if (CurrentView is LoginViewModel)
                {
                    if (!(o is UserModel userData))
                    {
                        return;
                    }

                    TryLogin(userData);
                    return;
                }

                CurrentView = new LoginViewModel(LoginCommand, RegisterCommand);
            });

            RegisterCommand = new RelayCommand(o =>
            {
                if (CurrentView is RegisterViewModel)
                {
                    if (!(o is UserModel userData))
                    {
                        return;
                    }

                    TryRegister(userData);
                    return;
                }

                CurrentView = new RegisterViewModel(LoginCommand, RegisterCommand);
            });
        }

        private void TryRegister(UserModel userData)
        {
            if (_userManager.RegisterUserIfNotExist(userData))
            {
                CurrentView = new HomeViewModel(ExploreViewCommand);
                MenuVisibility = Visibility.Visible;
                return;
            }

            MessageBox.Show("Account already exists for this email", "Pet Gallery");
        }

        private void TryLogin(UserModel userData)
        {
            if (_userManager.LoginUser(userData))
            {
                CurrentView = new HomeViewModel(ExploreViewCommand);
                MenuVisibility = Visibility.Visible;
                return;
            }
            MessageBox.Show("Email or password incorrect", "Pet Gallery");
            (CurrentView as LoginViewModel)?.Reset();
        }
    }
}