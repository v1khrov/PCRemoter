using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace PCRemoter.Server
{
    class Program
    {

        //получение локального адреса компьютера в сети
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        static void Main(string[] args)
        {
            //базовый адрес
            Uri address = new Uri("http://localhost:5051/");

            //хост службы
            ServiceHost hostRemoter = new ServiceHost(typeof(RemoterService), address);
                        
            try
            {
                // добавление конечной точки (веб-службы)
                hostRemoter.AddServiceEndpoint(typeof(IRemoterService), new NetHttpBinding(), "RemoterService");

                // включение обмена метаданными (wsdl)
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                hostRemoter.Description.Behaviors.Add(smb);

                string localIPAddress = GetLocalIPAddress(); //получаем IP адрес компьютера в сети

                // запуск службы
                hostRemoter.Open();
                Console.WriteLine("Хост-приложение для удаленного управления ПК с помощью PCRemoter для мобильных устройств.");
                Console.WriteLine("(C) 2017, Dmitry Vikhrov. dmvikhrov@gmail.com");
                Console.WriteLine("Служба запущена, адрес компьютера: ");

                Console.Write(localIPAddress);
                Console.WriteLine(" Порт: 5051");

                Console.WriteLine("В приложении на мобильном устройстве введите данные IP адрес и порт и нажмите Подключиться");

                Console.WriteLine("Для остановки нажмите \"Enter\"");
                Console.ReadLine();

                // остановка службы
                hostRemoter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}", e.ToString());

                // прерывание службы
                hostRemoter.Abort();
            }
        }
    }
}
