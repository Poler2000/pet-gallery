using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PetGallery.Core;
using PetGallery.MVVM.Models;

namespace PetGallery.MVVM.ViewModels
{
    public class ExploreViewModel : ObservableObject
    {
        private List<ImageModel> _petImages;

        public List<ImageModel> PetImages
        {
            get => _petImages;
            set
            {
                _petImages = value;
                OnPropertyChanged();
            }
        }
        
        private ImageModel _selectedImage;

        public ImageModel SelectedImage
        {
            get => _selectedImage;
            set
            {
                _selectedImage = value;
                DetailsView = new ImageDetailsViewModel(_selectedImage);
                OnPropertyChanged();
            }
        }

        private ImageDetailsViewModel _detailsView;

        public ImageDetailsViewModel DetailsView
        {
            get => _detailsView;
            set
            {
                _detailsView = value;
                OnPropertyChanged();
            }
        }
        
        public ExploreViewModel()
        {
            SideMenu = new FilterMenuViewModel(this);

        }

        public ExploreViewModel(string animal)
        {
            SideMenu = new FilterMenuViewModel(this);
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

        public async void Reload(string selectedPet = "Cat", BreedModel selectedBreed = null, int selectedLimit = 10)
        {
            var imageModels = await (selectedPet == "Cat"
                ? ImageProcessor.GetCats(selectedLimit, selectedBreed?.Id)
                : ImageProcessor.GetDogs(selectedLimit, selectedBreed?.Id));
            Application.Current.Dispatcher.Invoke(() =>
            {
                PetImages = imageModels;
            });
        }
    }
}