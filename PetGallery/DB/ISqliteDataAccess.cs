using System.Collections.Generic;

namespace PetGallery.DB
{
    public interface ISqliteDataAccess
    {
        List<T> LoadData<T>(string sql);
        void SaveData(string sql);
    }
}