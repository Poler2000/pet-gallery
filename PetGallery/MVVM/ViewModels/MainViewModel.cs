using System.Windows;
using PetGallery.Core;

namespace PetGallery.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ExploreViewCommand { get; set; }
        public RelayCommand MyCollectionsViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }

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

            PrepareCommands();
        }

        private void PrepareCommands()
        {
            HomeViewCommand = new RelayCommand(o => { CurrentView = new HomeViewModel(); });

            ExploreViewCommand = new RelayCommand(o => { CurrentView = new ExploreViewModel(); });

            MyCollectionsViewCommand = new RelayCommand(o => { CurrentView = new MyCollectionsViewModel(); });

            SettingsViewCommand = new RelayCommand(o => { CurrentView = new SettingsViewModel(); });
        }
    }
}