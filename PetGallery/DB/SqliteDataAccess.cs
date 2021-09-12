using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using PetGallery.MVVM.Models;
using Dapper;

namespace PetGallery.DB
{
    public class SqliteDataAccess : ISqliteDataAccess
    {
        private static string GetConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public List<T> LoadData<T>(string sql)
        {
            using IDbConnection cnn = new SQLiteConnection(GetConnectionString());
            var output = cnn.Query<T>(sql, new DynamicParameters());
            return output.ToList();
        }

        public void SaveData<T>(T model, string sql)
        {
            using IDbConnection cnn = new SQLiteConnection(GetConnectionString());
            cnn.Execute(sql, model);
        }

        public void UpdateData<T>(T model, string sql)
        {
            using IDbConnection cnn = new SQLiteConnection(GetConnectionString());
            cnn.Execute(sql, model);
        }
    }
}