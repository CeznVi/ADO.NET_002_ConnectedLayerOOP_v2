using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Configuration;
using System.Data;
using _002_ConnectedLayerOOP.Entities;
using System.Linq;
using System.Collections.ObjectModel;

namespace _002_ConnectedLayerOOP.Common
{
    class DbManager
    {
        private string _connectionString;
        protected DbProviderFactory _dbProviderFactory;
        protected DbConnection _dbConnection;
        protected DbCommand _dbCommand;
        protected DbTransaction _dbTransaction;
        protected DbDataReader _dataReader;

        protected Dictionary<Dbtable, ObservableCollection<IDataEntity>> _dataTables;
        //protected List<Dbtable> _dataTables;

        public DbManager()
        {
            _dataTables = new Dictionary<Dbtable, ObservableCollection<IDataEntity>>();

            Init();

        }

        public DbRow this[string tableName]
        {
            get
            {
                foreach (var tableInfo in _dataTables)
                {
                    if(tableInfo.Key.Name == tableName)
                    {
                        return tableInfo.Key.Head;
                    }
                }
                throw new ArgumentException("Table is not exists");
            }
        }


        private void Init()
        {
            try
            {
                switch (ConfigurationManager.AppSettings["ActiveProvider"])
                {
                    case "MSSQL":
                        {
                            string prividerName = ConfigurationManager.AppSettings["ActiveProvider"];
                            DbProviderFactories.RegisterFactory(prividerName, System.Data.SqlClient.SqlClientFactory.Instance);
                            _dbProviderFactory = DbProviderFactories.GetFactory(prividerName);
                            _connectionString = ConfigurationManager.ConnectionStrings["SqlProvider"].ConnectionString;

                            _dbConnection = _dbProviderFactory.CreateConnection();
                            _dbConnection.ConnectionString = _connectionString;
                            _dbCommand = _dbProviderFactory.CreateCommand();
                            _dbCommand.Connection = _dbConnection;

                            GetAllTable();


                            break;
                        }
                    case "Oracle":
                        {

                            break;
                        }
                    case "MYSql":
                        {

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //GetAllTableName();
            //GetDataFromDB();

        }

        //Получаем имена таблиц с БД
        private void GetAllTable() 
        {
            //_dbConnection.ConnectionString = _connectionString;
            _dbConnection.Open();

            _dbCommand.CommandText = "SELECT * FROM INFORMATION_SCHEMA.TABLES";

            List<string> tmplist  = new List<string>();

            using(_dataReader = _dbCommand.ExecuteReader())
            {
                while(_dataReader.Read()) 
                {
                    
                    Dbtable dbtable = new Dbtable(_dataReader["TABLE_NAME"].ToString(), GetTableShema(_dataReader["TABLE_NAME"].ToString()));
                    _dataTables.Add(dbtable, new ObservableCollection<IDataEntity>());
                }

            }
            //DataTable dt = _dbConnection.GetSchema("Tables");

            //foreach (DataRow row in dt.Rows)
            //{
            //    string tablename = (string)row[2];

            //    if (tablename != "sysdiagrams")
            //    {
            //        _dataTables.Add(tablename, new List<IDataEntity>());
            //    }
            //}

            _dbConnection.Close();
        }

        private DbRow GetTableShema(string tableName)
        {
            DbCommand dbCommand = _dbProviderFactory.CreateCommand();
            dbCommand.CommandText = $"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'{tableName}'";

            dbCommand.Connection = _dbConnection;

            DbRow dbRow;
            using(DbDataReader dbR = dbCommand.ExecuteReader())
            {
                dbRow = new DbRow(dbR.FieldCount);
                while(dbR.Read()) 
                { 
                    DbColumn dbColumn = new DbColumn(
                            Convert.ToInt32(dbR["ORDINAL_POSITION"]),
                            dbR["COLUMN_NAME"].ToString(),
                            dbR["IS_NULLABLE"].ToString() == "NO"? false:true
                        );;
                
                    dbRow.AddColumn(dbColumn);
                }

            }


            return null;
        }



        private void GetAllData(string tableName)
        {





            //_dbConnection.ConnectionString = _connectionString;
            //_dbConnection.Open();

            //_dbCommand.CommandText = $"SELECT * FROM {tableName}";

            //if (tableName == "users")
            //{
            //    DbDataReader dbAllUser = _dbCommand.ExecuteReader();
                
            //    while (dbAllUser.Read())
            //    {
            //            User user = new User();
            //            user.Id = int.Parse(dbAllUser["Id"].ToString());
            //            user.Login = dbAllUser["login"].ToString();
            //            user.Email = dbAllUser["email"].ToString();
            //            user.Password = dbAllUser["password"].ToString();
                        
            //        _dataTables[tableName].Add(user);
            //    }
            //}
            //else if (tableName == "usersInfo")
            //{
            //    DbDataReader dbAllUser = _dbCommand.ExecuteReader();

            //    while (dbAllUser.Read())
            //    {
            //        UserInfo userInf = new UserInfo();
            //        userInf.Id = int.Parse(dbAllUser["Id"].ToString());
            //        userInf.UserId = int.Parse(dbAllUser["userId"].ToString());
            //        userInf.Fio = dbAllUser["fio"].ToString();
            //        userInf.Inn = dbAllUser["inn"].ToString();
            //        userInf.BirthDate = ((DateTime)dbAllUser["birthDate"]);
            //        userInf.Gender = dbAllUser["gender"].ToString();
                    
            //        _dataTables[tableName].Add(userInf);
            //    }
            //}

            //_dbConnection.Close();
            ////должен заполнить _dataTables (получаем данные из таблиц и сохраняем в _dataTables)
        }

        /// <summary>
        /// Читает данные из таблиц на основе заранее полученых их названий
        /// </summary>
        //private void GetDataFromDB() 
        //{
        //    foreach (var item in _dataTables)
        //    {
        //        GetAllData(item.Key);
        //    }
        //}


        /////********-------------------------PUBLIC-------------------------********///////
        //public void ShowUsersFromLocalStorage()
        //{
        //    foreach (var item in _dataTables)
        //    {
        //        if(item.Key == "users")
        //        foreach (var data in item.Value)
        //        {
        //            Console.WriteLine(data);
        //        }
        //    }
        //}

        //public void ShowUsersInfoFromLocalStorage()
        //{
        //    foreach (var item in _dataTables)
        //    {
        //        if (item.Key == "usersInfo")
        //            foreach (var data in item.Value)
        //            {
        //                Console.WriteLine(data);
        //            }
        //    }
        //}


    }
}
