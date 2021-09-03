using System.Windows;
using PetGallery.Core;

namespace PetGallery.MVVM.ViewModels
{
    public class RegisterViewModel : ObservableObject
    {
        public RelayCommand InfoCommand { get; set; }
        public RelayCommand RegisterCommand { get; set; }
        public RelayCommand LoginCommand { get; set; }

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
            RegisterCommand = registerCommand;
        }
    }
}