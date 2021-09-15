using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using PetGallery.Core;
using PetGallery.DB;
using PetGallery.MVVM.Models;

namespace PetGallery.MVVM.ViewModels
{
    public class MyCollectionsViewModel : ObservableObject
    {
        private List<CollectionModel> _myCollections;
        private CollectionModel _selectedCollection;
        private CollectionManager _collectionManager;

        public List<CollectionModel> MyCollections
        {
            get => _myCollections;
            set
            {
                _myCollections = value;
                OnPropertyChanged();
            }
        }

        public CollectionModel SelectedCollection
        {
            get => _selectedCollection;
            set
            {
                _selectedCollection = value;
                OnPropertyChanged();
            }
        }
        
        public MyCollectionsViewModel()
        {
            _collectionManager = new CollectionManager(SqliteDataAccess.Instance);
            MyCollections = _collectionManager.GetCollectionsForUser(UserInfo.CurrentUser);
        }
    }
}