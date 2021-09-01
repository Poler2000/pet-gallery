using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using PetGallery.MVVM.Models;

namespace PetGallery.DB
{
    public class SqliteDataAccess
    {
        public static void RegisterUser(UserModel user)
        {
            
        }

        /*public static List<UserModel> GetAllUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(GetConnectionString()))
            {
                //var output = cnn.Query<UserModel>
            }
        }*/

        private static string GetConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}