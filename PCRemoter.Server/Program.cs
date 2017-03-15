using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace PCRemoter.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //базовый адрес
            Uri address = new Uri("http://pcremote:5051/");

            //хост службы
            ServiceHost hostRemoter = new ServiceHost(typeof(RemoterService), address);

            try
            {
                // добавление конечной точки (веб-службы)
                hostRemoter.AddServiceEndpoint(typeof(IRemoterService), new NetHttpBinding(), "PCRemoter Service");

                // включение обмена метаданными (wsdl)
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                hostRemoter.Description.Behaviors.Add(smb);

                // запуск службы
                hostRemoter.Open();
                Console.WriteLine("Служба запущена");

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
