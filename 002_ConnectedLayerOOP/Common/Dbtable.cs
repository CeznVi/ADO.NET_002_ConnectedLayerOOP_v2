using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _002_ConnectedLayerOOP.Common
{
    class Dbtable
    {
        public string _name;
        private DbRow _headRow;
        public ObservableCollection<IDataEntity> Rows;


        public string Name { get { return _name; } }
        
        public DbRow Head { get { return _headRow;} }

        public Dbtable(string name, DbRow row)
        {
            _name = name;
            _headRow = row;
        }
    }
}
