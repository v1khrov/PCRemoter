using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PCRemoter.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRemoterService" in both code and config file together.
    [ServiceContract]
    public interface IRemoterService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string Hello();

        //Тестирование соединение с отправкой сообщения клиента клиенту
        [OperationContract]
        string Echo(string _message);

        //Тестирование соединения
        [OperationContract]
        string TestConnection();

        //Имитация органов управления ОС Windows (нажатий кнопок, движений мыши)
        [OperationContract]
        string Controls(string _buttonName);

        //Отправка строки (группы символов) в ОС Windows
        [OperationContract]
        string SendTextToWindow(string _text);
        
        //Установка шага движения курсора мыши
        [OperationContract]
        string SetMouseMoveStep(int _newStep);
    }
}
