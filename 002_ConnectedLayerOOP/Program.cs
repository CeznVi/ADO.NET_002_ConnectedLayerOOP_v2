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

            Console.WriteLine("Внесем некоторые изменения и выведем на екран данные с измененияем");

            usersInfoStorage.UsersInfo[0].Fio = "!!!!!NEW DATA !!!!";
            usersInfoStorage.ShowInConsoleDataWithChanged();


            //foreach (var item in usersStorage.Users)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("Для продолжение нажмите любую клавишу");
            //Console.ReadKey();
            //Console.Clear();

            //usersInfoStorage.UsersInfo[0].Fio = "!!!!!!!!!!!!!!!!!!NEWWWWWWW";

            //Console.WriteLine("Для продолжение нажмите любую клавишу");
            //Console.ReadKey();
            //Console.Clear();
            //Console.WriteLine("Тест изменений");

        }
    }
}
