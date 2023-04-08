using _002_ConnectedLayerOOP.Common;
using _002_ConnectedLayerOOP.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _002_ConnectedLayerOOP.Storages
{
    class UsersInfoStorage: Common.DbManager
    {
        private List<Entities.UserInfo> _usersInfo;

        public DBTable Table
        {
            get { return this["usersInfo"]; }
        }

        public UsersInfoStorage()
        {
            _usersInfo = new List<Entities.UserInfo>();
            Init();
            LoadAndPairUserData();
        }

        private void Init()
        {

            _dbConnection.Open();

            _dbCommand.CommandText = $"SELECT * FROM {Table.Name}";

            using (_dataReader = _dbCommand.ExecuteReader())
            {
                while (_dataReader.Read())
                {
                    UserInfo userInformation = new UserInfo()
                    {
                        Id = Convert.ToInt32(_dataReader["Id"]),
                        UserId = Convert.ToInt32(_dataReader["userId"]),
                        Fio = _dataReader["fio"].ToString(),
                        Inn = _dataReader["inn"].ToString(),
                        BirthDate = Convert.ToDateTime(_dataReader["birthDate"]),
                        Gender = _dataReader["gender"].ToString(),
                        IsChanged = false,
                    };
                    _usersInfo.Add(userInformation);
                }
            }

            _dbConnection.Close();

        }
        /// <summary>
        /// загружает из базы сущность Юзера и спаривает ее с сущностью ЮзерИнфо
        /// </summary>
        private void LoadAndPairUserData()
        {
            UsersStorage usersStorage = new UsersStorage();
            
            foreach (var item in _usersInfo)
            {
                item.User = usersStorage.Users.Find(x => x.Id == item.UserId);
            }
        }

        public List<UserInfo> UsersInfo
        {
            get
            {
                return _usersInfo;
            }
        }
        /// <summary>
        /// Метод выводит в консоль загруженные данные из БД в сторадж
        /// </summary>
        public void ShowInConsoleAll()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var item in _usersInfo)
            {
                if (item.User != null)
                    Console.WriteLine(item);
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Вывод в консоли записей которые были изменены
        /// </summary>
        public void ShowInConsoleDataWithChanged()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (var item in _usersInfo)
            {
                if(item.IsChanged == true)
                Console.WriteLine(item);
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Сохраняет все измененные данные в базу данных
        /// </summary>
        public void SaveClassDataToBD()
        {

            _dbConnection.Open();

            foreach (var item in _usersInfo)
            {
                if (item.IsChanged == true)
                {
                    _dbCommand.CommandText = $"UPDATE {Table.Name} " +
                        $"SET fio = '{item.Fio}' " +
                        $"WHERE id = '{item.Id}'";


                    if (_dbCommand.ExecuteNonQuery() == 1)
                    {
                        Console.WriteLine("Изменения успешны");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
            }

            _dbConnection.Close();

        }

    }
}
