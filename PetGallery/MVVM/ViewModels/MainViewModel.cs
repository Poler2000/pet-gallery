using System;
using System.ComponentModel;
using System.Windows;
using PetGallery.Core;
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
        
        public ObservableObject CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            PrepareCommands();
            CurrentView = new LoginViewModel(LoginCommand, RegisterCommand);
        }

        private void PrepareCommands()
        {
            HomeViewCommand = new RelayCommand(o => { CurrentView = new HomeViewModel(); });

            ExploreViewCommand = new RelayCommand(o => { CurrentView = new ExploreViewModel(); });

            MyCollectionsViewCommand = new RelayCommand(o => { CurrentView = new MyCollectionsViewModel(); });

            SettingsViewCommand = new RelayCommand(o => { CurrentView = new SettingsViewModel(); });

            LoginCommand = new RelayCommand(o =>
            {
                if (CurrentView is LoginViewModel)
                {
                    if (!(o is UserModel userData))
                    {
                        return;
                    }
                    
                    Console.WriteLine(userData.Login);
                    return;
                }

                CurrentView = new LoginViewModel(LoginCommand, RegisterCommand);
            });

            RegisterCommand = new RelayCommand(o =>
            {
                if (CurrentView is RegisterViewModel)
                {
                    Console.WriteLine("Register");
                    return;
                }

                CurrentView = new RegisterViewModel(LoginCommand, RegisterCommand);
            });
        }
    }
}