using System;
using System.Collections.ObjectModel;
using PetGallery.Core;
using PetGallery.DB;
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

        private CollectionManager _collectionManager;

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
        
        public CollectionModel CurrentCollection { get; set; }
        
        public CollectionViewModel(CollectionModel collection)
        {
            CurrentCollection = collection;
            _collectionManager = new CollectionManager(SqliteDataAccess.Instance); 
            PetImages = new ObservableCollection<ImageModel>(_collectionManager.GetImages(CurrentCollection));

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
            ChooseCollectionMenu = new MyCollectionsViewModel(collection =>
            {
                DetailsView = null;
                _collectionManager.AddImageToCollection(collection, SelectedImage);
                ChooseCollectionMenu = null;
            });
        }

        public void RemoveButtonAction()
        {
            DetailsView = null;
            _collectionManager.RemoveItemFromCollection(CurrentCollection, SelectedImage);
            PetImages.Remove(SelectedImage);
        }
    }
}