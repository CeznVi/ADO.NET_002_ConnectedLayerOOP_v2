using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _002_ConnectedLayerOOP.Common
{
    class DbRow: IEnumerable
    {
        private readonly List<DbColumn> _columns;

        public DbRow(int countColumns)
        {
            if(countColumns <= 0) throw new ArgumentException("Incorrect Column count value");

            _columns = new List<DbColumn>(countColumns);
        }

        public void AddColumn(DbColumn column) 
        { 
            _columns.Add(column);
        
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
            get { return GetColumn(index); }
        }


        public DbColumn this[string nameColumn]
        {
            get 
            {
                foreach (var oneCol in _columns)
                {
                    if(oneCol.Name == nameColumn)
                        return oneCol;
                }
                throw new ArgumentException("Incorect Name Column");
            }
        }
    }
}
