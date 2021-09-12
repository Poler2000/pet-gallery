using System;
using PetGallery.DB;
using PetGallery.MVVM.Models;

namespace PetGallery.Core
{
    public class UserManager
    {
        private readonly ISqliteDataAccess _database;

        public UserManager(ISqliteDataAccess database)
        {
            _database = database;
        }

        public bool RegisterUserIfNotExist(UserModel userdata)
        {
            string sql = $"SELECT * FROM Users WHERE Email = '{userdata.Email}'";

            if (_database.LoadData<UserModel>(sql).Count > 0)
            {
                return false;
            }
            
            sql = $"INSERT INTO Users (Login, Email, Password) VALUES ('{userdata.Login}', '{userdata.Email}', '{userdata.Password}')";
            
            _database.SaveData(userdata, sql);
            return true;
        }

        public bool LoginUser(UserModel userdata)
        {
            string sql = $"SELECT * FROM Users WHERE Email = '{userdata.Email}' AND Password = '{userdata.Password}'";
            Console.WriteLine(sql);

            return _database.LoadData<UserModel>(sql).Count == 1;
        }
    }
}