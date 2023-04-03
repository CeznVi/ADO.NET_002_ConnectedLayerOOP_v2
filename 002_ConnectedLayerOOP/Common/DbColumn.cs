using System;
using System.Collections.Generic;
using System.Text;

namespace _002_ConnectedLayerOOP.Common
{
    class DbColumn
    {
        private int _cId;
        private string _name;
        private bool _notNull;

        public DbColumn(int cId, string name, bool notNull)
        {
            _cId = cId;
            _name = name;
            _notNull = notNull;
        }

        public int CId
        {
            get { return _cId; }

        }

        public string Name { get { return _name; } }

        public bool NotNull { get { return _notNull;} }

    }
}
