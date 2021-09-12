using System.Collections.Generic;

namespace PetGallery.DB
{
    public interface ISqliteDataAccess
    {
        List<T> LoadData<T>(string sql);
        void SaveData<T>(T model, string sql);
        void UpdateData<T>(T model, string sql);
    }
}