using _002_ConnectedLayerOOP.Common;
using _002_ConnectedLayerOOP.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _002_ConnectedLayerOOP.Storages
{
    class UsersStorage : Common.DbManager
    {
        private List<Entities.User> _users;

        public DBTable Table
        {
            get { return this["users"]; }
        }
        public UsersStorage()
        {
            /*_users = new List<User>(_dataTables[Table].Count);
            foreach (IDataEntity item in _dataTables[Table])
            {
                if(item is User)
                {
                    _users.Add((User)item);
                }
            }*/

            _users = new List<User>();
            Init();
        }

        private void Init()
        {
            _dbConnection.Open();

            _dbCommand.CommandText = $"SELECT * FROM {Table.Name}";

            using (_dataReader = _dbCommand.ExecuteReader())
            {
                while (_dataReader.Read())
                {
                    User user = new User()
                    {
                        Id = Convert.ToInt32(_dataReader["Id"]),
                        Login = _dataReader["login"].ToString(),
                        Email = _dataReader["email"].ToString(),
                        Password = _dataReader["password"].ToString()
                    };
                    _users.Add(user);
                }
            }

            _dbConnection.Close();
        }

        public List<User> Users
        {
            get
            {
                return _users;
            }
        }
    }

}
