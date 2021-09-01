using System.Windows;
using PetGallery.Core;

namespace PetGallery.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
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
            CurrentView = new LoginViewModel();
        }
    }
}