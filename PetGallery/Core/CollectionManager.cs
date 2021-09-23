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
            string sql = $"INSERT INTO Collections (Title, User) VALUES ('{collection.Title}', '{collection.User}')";
            
            _database.SaveData(collection, sql);
            return true;
        }

        public void RemoveCollection(CollectionModel collection)
        {
            string sql = $"DELETE FROM CollectionItems WHERE Collection = '{collection.Id}'";
            
            _database.UpdateData(collection, sql);

            sql = $"DELETE FROM Collections WHERE Id = '{collection.Id}'";
            
            _database.UpdateData(collection, sql);
        }

        public List<CollectionModel> GetCollectionsForUser(UserModel user)
        {
            string sql = $"SELECT * FROM Collections WHERE User = '{user.Id}'";

            var result = _database.LoadData<CollectionModel>(sql);
            return result;
        }

        public bool AddImageToCollection(CollectionModel collection, ImageModel image)
        {
            string sql = $"INSERT INTO Images (Title, Comment, Url, Path)" +
                         $"SELECT '{image.Title}', '{image.Comment}', '{image.Url}', '{image.Path}'";
            _database.SaveData(image, sql);
            
            sql = $"SELECT Id FROM Images WHERE Url = '{image.Url}'";
            var result = _database.LoadData<int>(sql);

            sql = $"INSERT INTO CollectionItems (Collection, Item) VALUES ('{collection.Id}', '{result[0]}')";
            _database.SaveData(image, sql);
            return true;
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