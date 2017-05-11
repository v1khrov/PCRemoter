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

            //IntPtr _wHandle = NativeMethods.FindWindow("PPTFrameClass", null);
            /*if (_wHandle == IntPtr.Zero)
            {
                MessageBox.Show("PowerPoint is not running.");
                Console.WriteLine("ERROR! PowerPoint is not running.");
            }*/
            switch (_buttonName)
            {
                case "clickRight":
                    MouseEventArgs _mouseEA = new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0);
                    Control _ctrl = new Control();
                    //_ctrl.OnMouseClick(_mouseEA);
                    break;
                case "buttonUp":
                    SendKeys.SendWait("{UP}");
                    break;
                case "buttonLeft":
                    SendKeys.SendWait("{LEFT}");
                    break;
                case "buttonRight":
                    SendKeys.SendWait("{RIGHT}");
                    break;
                case "buttonDown":
                    SendKeys.SendWait("{DOWN}");
                    break;
                case "buttonTab":
                    SendKeys.SendWait("{TAB}");
                    break;
                case "buttonEnter":
                    SendKeys.SendWait("{ENTER}");
                    break;
                case "buttonF5":
                    SendKeys.SendWait("{F5}");
                    break;
                case "buttonEsc":
                    SendKeys.SendWait("{ESC}");
                    break;
                case "buttonDelete":
                    SendKeys.SendWait("{DEL}");
                    break;
                case "buttonChangeWindow":
                    SendKeys.SendWait("%{ESC}");
                    break;
                case "buttonF1":
                    SendKeys.SendWait("{F1}");
                    break;
                case "buttonBackspace":
                    SendKeys.SendWait("{BACKSPACE}");
                    break;
                case "buttonWindows":
                    //SendKeys.SendWait("{WINDOWS}");
                    break;
                case "buttonScreenshot":
                    SendKeys.SendWait("{PRTSC}");
                    break;
                default:
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
            
            SendKeys.SendWait(_text);
            return "OK";                      
            
        }

        public string TestConnection()
        {
            Console.WriteLine("Тестирование соединения");
            return "OK";
        }
    }
}
