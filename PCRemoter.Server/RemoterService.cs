using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace PCRemoter.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RemoterService" in both code and config file together.
    public class RemoterService : IRemoterService
    {
        
        public string Controls(string _buttonName)
        {
            Console.WriteLine("Вызов метода \"Control\"");
            switch (_buttonName)
            {
                case "clickRight":
                    MouseEventArgs _mouseEA = new MouseEventArgs(MouseButtons.Right,1,0,0,0);
                    Control _ctrl = new Control();
                    //_ctrl.OnMouseClick(_mouseEA);
                    break;
                case "buttonDown":
                    //SendKeys.Send("{DOWN}");
                    //IntPtr _wHandle = NativeMethods.GetActiveWindow();
                    //string _wTitle = NativeMethods.GetActiveWindowTitle();
                    IntPtr _wHandle = NativeMethods.FindWindow("PPTFrameClass", null);
                    NativeMethods.KeyPress(_wHandle, Keys.Down, false);
                    break;

            }             
               
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
