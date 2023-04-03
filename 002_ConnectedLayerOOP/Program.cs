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
            foreach (var item in usersStorage.Users)
            {
                Console.WriteLine(item);
            }

        }
    }
}
