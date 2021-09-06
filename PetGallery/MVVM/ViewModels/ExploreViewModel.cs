using PetGallery.Core;

namespace PetGallery.MVVM.ViewModels
{
    public class ExploreViewModel : ObservableObject
    {
        private bool _isMenuExpanded;

        public bool IsMenuExpanded
        {
            get => _isMenuExpanded;
            set
            {
                _isMenuExpanded = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand ExpandMenuCommand { get; set; }

        public ExploreViewModel()
        {
            SideMenu = new FilterMenuViewModel();
            ExpandMenuCommand = new RelayCommand(o =>
            {
                IsMenuExpanded = !IsMenuExpanded;
            });
        }

        public ExploreViewModel(string animal)
        {
            SideMenu = new FilterMenuViewModel();
            ExpandMenuCommand = new RelayCommand(o =>
            {
                IsMenuExpanded = !IsMenuExpanded;
            });
        }
        
        private ObservableObject _sideMenu;
        
        public ObservableObject SideMenu
        {
            get => _sideMenu;
            set
            {
                _sideMenu = value;
                OnPropertyChanged();
            }
        }
    }
}