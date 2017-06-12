using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using PCRemoter.Server;


namespace PCRemoter.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RemoterService" in both code and config file together.
    public class RemoterService : IRemoterService
    {
        int _step = 7;

        public string Controls(string _buttonName)
        {
            Console.WriteLine("Вызов метода \"Control\"");

            int yScreen = SystemInformation.PrimaryMonitorSize.Height;//Высота экрана
            int xScreen = SystemInformation.PrimaryMonitorSize.Width;//Ширина экрана

            Point currPosition = Cursor.Position; //текущее положение курсора мыши
            

            switch (_buttonName)
            {
                case "mouseDown":
                    Cursor.Position = new Point(currPosition.X, currPosition.Y + _step);
                    break;
                case "mouseDownLeft":
                    Cursor.Position = new Point(currPosition.X - _step, currPosition.Y + _step);
                    break;
                case "mouseDownRight":
                    Cursor.Position = new Point(currPosition.X + _step, currPosition.Y + _step);
                    break;
                case "mouseLeft":
                    Cursor.Position = new Point(currPosition.X - _step, currPosition.Y);
                    break;
                case "mouseRight":
                    Cursor.Position = new Point(currPosition.X + _step, currPosition.Y);
                    break;
                case "mouseUp":
                    Cursor.Position = new Point(currPosition.X, currPosition.Y - _step);
                    break;
                case "mouseUpLeft":
                    Cursor.Position = new Point(currPosition.X - _step, currPosition.Y - _step);
                    break;
                case "mouseUpRight":
                    Cursor.Position = new Point(currPosition.X + _step, currPosition.Y - _step);
                    break;
                case "clickLeft":
                    {
                        //MouseEventArgs _mouseEA = new MouseEventArgs(MouseButtons.Right, 1, currPosition.X, currPosition.Y, 0);
                        //Control _ctrl = new Control();
                        //_ctrl.MouseClick(_mouseEA);
                        NativeMethods.SetCursorPos(currPosition.X, currPosition.Y);
                        NativeMethods.mouse_event((int)MouseEvent.MOUSEEVENTF_LEFTDOWN, currPosition.X, currPosition.Y, 0, 0);
                        NativeMethods.mouse_event((int)MouseEvent.MOUSEEVENTF_LEFTUP, currPosition.X, currPosition.Y, 0, 0);
                    }
                    break;
                case "clickRight":
                    {
                        //MouseEventArgs _mouseEA = new MouseEventArgs(MouseButtons.Right, 1, currPosition.X, currPosition.Y, 0);
                        //Control _ctrl = new Control();
                        //_ctrl.MouseClick(_mouseEA);
                        NativeMethods.SetCursorPos(currPosition.X, currPosition.Y);
                        NativeMethods.mouse_event((int)MouseEvent.MOUSEEVENTF_RIGHTDOWN, currPosition.X, currPosition.Y, 0, 0);
                        NativeMethods.mouse_event((int)MouseEvent.MOUSEEVENTF_RIGHTUP, currPosition.X, currPosition.Y, 0, 0);
                    }
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

        public string SetMouseMoveStep(int _newStep)
        { 
            _step = _newStep;
            //throw new NotImplementedException();
            return "OK";
        }

        public string TestConnection()
        {
            Console.WriteLine("Тестирование соединения");



            return "OK";
        }
    }
}
