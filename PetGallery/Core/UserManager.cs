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

        public bool RegisterUserIfNotExist(UserModel userData)
        {
            string sql = $"SELECT * FROM Users WHERE Email = '{userData.Email}'";

            if (_database.LoadData<UserModel>(sql).Count > 0)
            {
                return false;
            }
            
            sql = $"INSERT INTO Users (Login, Email, Password) VALUES ('{userData.Login}', '{userData.Email}', '{userData.Password}')";
            _database.SaveData(sql);
            return LoginUser(userData);
        }

        public bool LoginUser(UserModel userData)
        {
            string sql = $"SELECT * FROM Users WHERE Email = '{userData.Email}' AND Password = '{userData.Password}'";

            var result = _database.LoadData<UserModel>(sql);
            
            if (result.Count != 1)
            {
                return false;
            }
            
            SetUserInfo(result[0]);
            return true;
        }

        private void SetUserInfo(UserModel userData)
        {
            UserInfo.CurrentUser = userData;
        }
    }
}