using System;
using System.Collections.Generic;
using System.Data.SQLite;
using PetGallery.DB;
using PetGallery.MVVM.Models;

namespace PetGallery.Core
{
    public class CollectionManager : ICollectionManager
    {
        private readonly ISqliteDataAccess _database;

        public CollectionManager(ISqliteDataAccess database)
        {
            _database = database;
        }
        
        public bool CreateCollection(CollectionModel collection)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCollection(CollectionModel collection)
        {
            throw new System.NotImplementedException();
        }

        public List<CollectionModel> GetCollectionsForUser(UserModel user)
        {
            string sql = $"SELECT * FROM Collections WHERE User = '{user.Id}'";

            var result = _database.LoadData<CollectionModel>(sql);
            return result;
        }

        public bool AddImageToCollection(CollectionModel collection, ImageModel image)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveItemFromCollection(CollectionModel collection, ImageModel image)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateImageData(ImageModel image)
        {
            throw new System.NotImplementedException();
        }
    }
}