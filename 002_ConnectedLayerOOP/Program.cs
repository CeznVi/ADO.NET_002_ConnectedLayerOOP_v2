using _002_ConnectedLayerOOP.Common;
using _002_ConnectedLayerOOP.Storages;
using System;

namespace _002_ConnectedLayerOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            UsersInfoStorage usersInfoStorage = new UsersInfoStorage();
            Console.WriteLine("Информация с таблицы ЮзерИнфо");

            usersInfoStorage.ShowInConsoleAll();
            
            Console.WriteLine("Для продолжение нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Внесем некоторые изменения и выведем на екран данные с измененияем в нашем класе");
            usersInfoStorage.UsersInfo[2].GenerateRandomFio();
            usersInfoStorage.UsersInfo[3].GenerateRandomFio();
            usersInfoStorage.ShowInConsoleDataWithChanged();



        }
    }
}
