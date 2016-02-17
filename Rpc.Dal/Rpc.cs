using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Rpc.Dal
{
    public class Rpc : IRpc
    {
        private readonly MongoCollection<LoginProperties> _loginMongoCollection;

        public Rpc()
        {
            var connectionString = Configuration.RpcDb;
            MongoServer server = new MongoClient(connectionString).GetServer();
            var database = server.GetDatabase(MongoUrl.Create(connectionString).DatabaseName);
            _loginMongoCollection = database.GetCollection<LoginProperties>("LoginProperties");
        }

        public bool IsRecordExists(string username)
        {
            var query = Query<LoginProperties>.EQ(u => u.Username, username);
            var res = _loginMongoCollection.FindOne(query);
            return res != null;
        }

        public bool SaveRecord(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;
            try
            {
                var loginObj = new LoginProperties
                {
                    Username = username,
                    Password = password
                };
                var concern = _loginMongoCollection.Insert(loginObj);
                return concern.Ok;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public int GetUsersCount()
        {
            var users = _loginMongoCollection.FindAll().ToList();
            return users.Count();
        }
    }
}
