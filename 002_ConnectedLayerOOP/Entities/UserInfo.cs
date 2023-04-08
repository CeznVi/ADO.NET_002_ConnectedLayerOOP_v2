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
        private string _bithDate;
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
        public string Inn { get; set; }


        /// <summary>
        /// Свойство поля bday
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Свойство поля gender
        /// </summary>
        public string Gender { get; set; }
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


        public override string ToString()
        {
            return $"Id: {Id}, UserId:{UserId}, FIO: {Fio}, Inn: {Inn}, BDay: {BirthDate.ToShortDateString()}, Genre: {Gender}" +
                $"\t User: {User}";
        }

    }
}
