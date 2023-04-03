using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _002_ConnectedLayerOOP.Common
{
    class DbRow : IEnumerable
    {
        private readonly List<DbColumn> _columns;
        private int _countColumns;
        public DbRow(int countColumns)
        {
            if (countColumns <= 0) throw new ArgumentException("Incorrect Column count value");
            _countColumns = countColumns;
            _columns = new List<DbColumn>(countColumns);
        }

        public void AddColumn(DbColumn column)
        {
            if (_columns.Count + 1 < _countColumns)
            {
                _columns.Add(column);
            }
            else
            {
                throw new ArgumentException("Many columns");
            }
        }
        public DbColumn GetColumn(int index)
        {
            return _columns[index];
        }

        public IEnumerator GetEnumerator()
        {
            return _columns.GetEnumerator();
        }

        public DbColumn this[int index]
        {
            get
            {
                return GetColumn(index);
            }
        }

        public DbColumn this[string nameColum]
        {
            get
            {
                foreach (var oneCol in _columns)
                {
                    if (oneCol.Name == nameColum)
                    {
                        return oneCol;
                    }
                }
                throw new ArgumentException("Incorrect Name Column");
            }
        }

    }

}
