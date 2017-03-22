using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace PCRemoter.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RemoterService" in both code and config file together.
    public class RemoterService : IRemoterService
    {
        public string Control(string _buttonName)
        {
            Console.WriteLine("Вызов метода \"Control\"");
                        
            return "OK";
        }

        public void DoWork()
        {
            Console.WriteLine("Работает");
        }

        public string Echo(string _message)
        {
            Console.WriteLine("Вызов метода \"Echo\"");
            return _message;
        }

        public string Hello()
        {
            Console.WriteLine("Вызов метода \"Hello\"");
            return "Здравствуйте!";
        }

        public string TestConnection()
        {
            Console.WriteLine("Запрос на тестирование соединения");
            return "OK";
        }
    }
}
