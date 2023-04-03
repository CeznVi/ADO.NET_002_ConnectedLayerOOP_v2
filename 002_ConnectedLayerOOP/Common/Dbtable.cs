using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _002_ConnectedLayerOOP.Common
{
    class DBTable
    {
        private string _name;
        private DbRow _headRow;             //структура таблицы
        public ObservableCollection<IDataEntity> Rows;

        public string Name
        {
            get { return _name; }
        }
        public DbRow Head
        {
            get { return _headRow; }
        }
        public DBTable(string name, DbRow dbHeadRow)
        {
            _name = name;
            _headRow = dbHeadRow;
        }
    }


}
