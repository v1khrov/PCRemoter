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
            IntPtr _wHandle = NativeMethods.FindWindow("PPTFrameClass", null);
            if (_wHandle == IntPtr.Zero)
            {
                MessageBox.Show("PowerPoint is not running.");
                Console.WriteLine("ERROR! PowerPoint is not running.");
            }
            switch (_buttonName)
            {
                case "clickRight":
                    MouseEventArgs _mouseEA = new MouseEventArgs(MouseButtons.Right,1,0,0,0);
                    Control _ctrl = new Control();
                    //_ctrl.OnMouseClick(_mouseEA);
                    break;
                case "buttonUp":
                    NativeMethods.SetForegroundWindow(_wHandle);
                    SendKeys.SendWait("{UP}");
                    break;
                case "buttonLeft":
                    NativeMethods.SetForegroundWindow(_wHandle);
                    SendKeys.SendWait("{LEFT}");
                    break;
                case "buttonRight":
                    NativeMethods.SetForegroundWindow(_wHandle);
                    SendKeys.SendWait("{RIGHT}");
                    break;
                case "buttonDown":
                    //SendKeys.Send("{DOWN}");
                    //IntPtr _wHandle = NativeMethods.FindWindow(null, "PUSHMYBUTTONS");
                    //string _wTitle = NativeMethods.GetActiveWindowTitle();                    
                    //IntPtr _wHandle = NativeMethods.FindWindow("Notepad", null);
                    NativeMethods.SetForegroundWindow(_wHandle);
                    SendKeys.SendWait("{DOWN}");
                    //NativeMethods.KeyPress(_wHandle, Keys.Down, false);
                    //NativeMethods.KeyPressInt(_wHandle, 0x28, true);
                    break;
                case "buttonTab":
                    NativeMethods.SetForegroundWindow(_wHandle);
                    SendKeys.SendWait("{TAB}");
                    break;
                case "buttonEnter":
                    NativeMethods.SetForegroundWindow(_wHandle);
                    SendKeys.SendWait("{ENTER}");
                    break;
                case "buttonF5":
                    NativeMethods.SetForegroundWindow(_wHandle);
                    SendKeys.SendWait("{F5}");
                    break;
                case "buttonEsc":
                    NativeMethods.SetForegroundWindow(_wHandle);
                    SendKeys.SendWait("{ESC}");
                    break;
                case "buttonDelete":
                    NativeMethods.SetForegroundWindow(_wHandle);
                    SendKeys.SendWait("{DEL}");
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

        public string SendTextToWindow(string _text)
        {
            Console.WriteLine("Вызов метода \"SendTextToWindow\"");
            IntPtr _wHandle = NativeMethods.FindWindow("PPTFrameClass", null);
            if (_wHandle == IntPtr.Zero)
            {
                MessageBox.Show("PowerPoint is not running.");
                Console.WriteLine("ERROR! PowerPoint is not running.");
                return "ERROR";
            }
            else
            {
                NativeMethods.SetForegroundWindow(_wHandle);
                SendKeys.SendWait(_text);
                return "OK";
            }            
            
        }

        public string TestConnection()
        {
            Console.WriteLine("Запрос на тестирование соединения");
            return "OK";
        }
    }
}
