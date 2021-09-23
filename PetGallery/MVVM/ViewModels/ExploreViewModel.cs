using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PetGallery.Core;
using PetGallery.MVVM.Models;

namespace PetGallery.MVVM.ViewModels
{
    public class ExploreViewModel : ObservableObject, ICardCollection
    {
        private ObservableCollection<ImageModel> _petImages;

        public ObservableCollection<ImageModel> PetImages
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
                DetailsView = new ImageDetailsViewModel(this, _selectedImage);
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
                PetImages = new ObservableCollection<ImageModel>(imageModels);
            });
        }

        public void  PreviousImage()
        {
            var index = PetImages.IndexOf(SelectedImage);
            if (index > 0)
            {
                SelectedImage = PetImages[index - 1];
            }
        }

        public void NextImage()
        {
            var index = PetImages.IndexOf(SelectedImage);
            if (index < PetImages.Count - 1)
            {
                SelectedImage = PetImages[index + 1];
            }
            
        }

        public void AddButtonAction()
        {
            throw new NotImplementedException();
        }

        public void RemoveButtonAction()
        {
            DetailsView = null;
            PetImages.Remove(SelectedImage);
        }
    }
}