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

        protected Dictionary<DBTable, ObservableCollection<IDataEntity>> _dataTables;

        //protected List<DBTable> _dataTables;

        public DbManager()
        {
            _dataTables = new Dictionary<DBTable, ObservableCollection<IDataEntity>>();

            Init();
        }

        public DBTable this[string tableName]
        {
            get
            {
                foreach (var tableInfo in _dataTables)
                {
                    if (tableInfo.Key.Name == tableName)
                    {
                        return tableInfo.Key;
                    }
                }
                throw new ArgumentException("Table is Not Exists");
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

                            GetAllTables();
                            //foreach (var item in _dataTables.Keys)
                            //{
                            //    GetAllData(item);
                            //}
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
            catch (Exception)
            {
                throw;
            }
        }

        private void GetAllTables()
        {
            //должен заполнить _dataTables (получаем имена таблиц в Бд)
            _dbConnection.Open();

            _dbCommand.CommandText = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
            List<string> tmpList = new List<string>();
            using (_dataReader = _dbCommand.ExecuteReader())
            {
                while (_dataReader.Read())
                {
                    tmpList.Add(_dataReader["TABLE_NAME"].ToString());
                }
            }
            foreach (string tblName in tmpList)
            {
                DBTable dBTable = new DBTable(tblName, GetTableShema(tblName));
                _dataTables.Add(dBTable, new ObservableCollection<IDataEntity>());
            }

            _dbConnection.Close();
        }
        private DbRow GetTableShema(string tableName)
        {
            DbCommand dbCommand = _dbProviderFactory.CreateCommand();
            dbCommand.CommandText = $"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{tableName}'";
            dbCommand.Connection = _dbConnection;

            DbRow dbRow;
            using (DbDataReader dbR = dbCommand.ExecuteReader())
            {
                dbRow = new DbRow(dbR.FieldCount);
                while (dbR.Read())
                {
                    DbColumn dbColumn = new DbColumn(
                            Convert.ToInt32(dbR["ORDINAL_POSITION"]),
                            dbR["COLUMN_NAME"].ToString(),
                            dbR["IS_NULLABLE"].ToString() == "NO" ? false : true
                    );
                    dbRow.AddColumn(dbColumn);
                }
            }
            return dbRow;
        }

        private void GetAllData(DBTable table)
        {
            _dbConnection.Open();

            _dbCommand.CommandText = $"SELECT * FROM {table.Name}";

            using (DbDataReader dbR = _dbCommand.ExecuteReader())
            {
                while (dbR.Read())      //перебираем каждую строку 
                {
                    //_dataTables[table].Add()
                }
            }

            _dbConnection.Close();
        }
    }
}
