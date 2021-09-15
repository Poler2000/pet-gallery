using System.Collections.Generic;
using PetGallery.MVVM.Models;

namespace PetGallery.Core
{
    public interface ICollectionManager
    {
        public bool CreateCollection(CollectionModel collection);
        public void RemoveCollection(CollectionModel collection);

        public List<CollectionModel> GetCollectionsForUser(UserModel user);

        public bool AddImageToCollection(CollectionModel collection, ImageModel image);
        public void RemoveItemFromCollection(CollectionModel collection, ImageModel image);
        public void UpdateImageData(ImageModel image);
    }
}