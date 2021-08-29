using System.Windows;
using PetGallery.Core;

namespace PetGallery.MVVM.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        public RelayCommand InfoCommand { get; set; }

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

        public LoginViewModel()
        {
            InfoCommand = new RelayCommand(o =>
            {
                IsInfoVisible = IsInfoVisible == Visibility.Visible ? 
                                Visibility.Hidden : Visibility.Visible;
            });
        }
    }
}