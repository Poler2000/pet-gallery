using System.Collections.ObjectModel;
using PetGallery.Core;
using PetGallery.MVVM.Models;

namespace PetGallery.MVVM.ViewModels
{
    public class CollectionViewModel : ObservableObject, ICardCollection
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
        
        private ObservableObject _chooseCollectionMenu;
        
        public ObservableObject ChooseCollectionMenu
        {
            get => _chooseCollectionMenu;
            set
            {
                _chooseCollectionMenu = value;
                OnPropertyChanged();
            }
        }
        
        public CollectionViewModel(int id)
        {
            throw new System.NotImplementedException();
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
            ChooseCollectionMenu = new MyCollectionsViewModel(x =>
            {
                ChooseCollectionMenu = null;
                throw new System.NotImplementedException();
            });
        }

        public void RemoveButtonAction()
        {
            throw new System.NotImplementedException();
        }
    }
}