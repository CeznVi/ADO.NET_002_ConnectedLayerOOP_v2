using _002_ConnectedLayerOOP.Common;
using _002_ConnectedLayerOOP.Storages;
using System;

namespace _002_ConnectedLayerOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            UsersStorage usersStorage = new UsersStorage();

            UsersInfoStorage usersInfoStorage = new UsersInfoStorage();


            foreach (var item in usersStorage.Users)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Для продолжение нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Информация с таблицы ЮзерИнфо");

            foreach (var item in usersInfoStorage.UsersInfo)
            {
                item.User = usersStorage.Users.Find(x => x.Id == item.UserId);

                Console.WriteLine(item);
            }


        }
    }
}
