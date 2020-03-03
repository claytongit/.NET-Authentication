using systemLogin.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace systemLogin.Services
{
    public class UserService
    {
        private readonly IMongoCollection<UserModel> _userModel;

        public UserService(IUserdatabase config)
        {
            var client = new MongoClient(config.Connection);
            var database = client.GetDatabase(config.DatabaseName);

            _userModel = database.GetCollection<UserModel>(config.UserColetionName);
        }

        public UserModel Post(UserModel newUser)
        {
            _userModel.InsertOne(newUser);
            return newUser;
        }

        public List<UserModel> Get()
        {
            return _userModel.Find(user => true).ToList();
        }

        public UserModel Get(string username, string password)
        {
            var users = new List<UserModel>();

            return users.Find(user => true);
        }


    }
}