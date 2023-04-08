using _002_ConnectedLayerOOP.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _002_ConnectedLayerOOP.Entities
{
    class UserInfo: IDataEntity
    {
        /// <summary>
        /// Переменные которые хранят данные с БД
        /// </summary>
        private int _id;
        private int _userId;
        private string _fio;
        private string _inn;
        private DateTime _bithDate;
        private string _gender;
        private bool _isChanged = false;

        /* ____________-------------------- Свойства класса --------------------____________ */
        /// <summary>
        /// Свойство поля Id
        /// </summary>
        public int Id 
        { 
            get { return _id; } 
            set
            {
                _id = value;
                IsChanged = true;
            }
        }
        /// <summary>
        /// Свойство поля UserId
        /// </summary>
        public int UserId 
        {
            get { return (_userId); }
            set 
            { 
                _userId = value;
                IsChanged = true;
            } 
        }
        /// <summary>
        /// Свойство поля fio
        /// </summary>
        public string Fio 
        { 
            get { return _fio; } 
            set 
            { 
                _fio = value;
                IsChanged = true;
            }
        }
        /// <summary>
        /// Свойство поля inn
        /// </summary>
        public string Inn
        {
            get { return _inn; }
            set 
            { 
                _inn = value;
                IsChanged = true;
            }
        }
        /// <summary>
        /// Свойство поля bday
        /// </summary>
        public DateTime BirthDate 
        { 
            get { return _bithDate; } 
            set
            {
                _bithDate = value;
                IsChanged = true;
            }
        }
        /// <summary>
        /// Свойство поля gender
        /// </summary>
        public string Gender 
        { 
            get { return _gender; } 
            set 
            { 
                _gender = value;
                IsChanged = true;
            }
        }
        /// <summary>
        /// Свойство поля User
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Свойство поля которая хранит изменения в полях класаа
        /// </summary>
        public bool IsChanged 
        { 
            get { return _isChanged; } 
            set { _isChanged = value; }
        }

        /* ____________-------------------- Методы класса --------------------____________ */
        /// <summary>
        /// Возвращает строку с данными UserInfo
        /// </summary>
        /// <returns>Возвращает строку с данными UserInfo</returns>
        public override string ToString()
        {
            //$"Id: {Id}, UserId:{UserId}, FIO: {Fio}, Inn: {Inn}, BDay: {BirthDate.ToShortDateString()}, Genre: {Gender}" +
            //    $"\t User: {User}"
            return $"UserId:{UserId}, FIO: {Fio}, Inn: {Inn}, BDay: {BirthDate.ToShortDateString()}, Genre: {Gender}" +
                $"\nUser:{User}\n";
        }

    }
}
