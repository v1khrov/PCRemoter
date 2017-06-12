using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCRemoter.Server
{
    // Класс для эмуляции нажатия и отпускания кнопок мыши и клавиатуры.
    public static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetCursorPos(int X, int Y);

        static int GetWParamFromButton(MouseButton btn)
        {
            switch (btn)
            {
                case MouseButton.Left: return 0x0001;
                case MouseButton.Middle: return 0x0010;
                case MouseButton.Right: return 0x0002;
                default: throw new Win32Exception("Невозможно преобразовать значение!");
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(
        string lpClassName, // class name 
        string lpWindowName // window name 
        );

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        //получение имени активного окна
        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();

        //получение имени активного окна
        [DllImport("user32.dll")]
        public static extern string GetActiveWindowTitle();



        /// <summary>
        /// Эмуляция нажатия и отпускания кнопок мыши.
        /// </summary>
        /// <param name="hWnd">Дескриптор окна в которое будет послано сообщение.</param>
        /// <param name="btn">Кнопка мыши.</param>
        /// <param name="x">Координата X (относительно экрана).</param>
        /// <param name="y">Координата  Y (относительно экрана).</param>
        public static void MouseClick(IntPtr hWnd, MouseButton btn, int x, int y)
        {
            int xyPoint = NativeMacros.MAKELONG(x, y);
            int wParam = GetWParamFromButton(btn);

            SendMessage(hWnd, (int)btn, wParam, xyPoint);
            SendMessage(hWnd, (int)btn + 1, wParam, xyPoint);
        }

        /// <summary>
        /// Эмуляция отпускания кнопок мыши.
        /// </summary>
        /// <param name="hWnd">Дескриптор окна в которое будет послано сообщение.</param>
        /// <param name="btn">Кнопка мыши.</param>
        /// <param name="x">Координата X (относительно экрана).</param>
        /// <param name="y">Координата  Y (относительно экрана).</param>
        /// <returns>Возвращает результат работы функции SendMessage.</returns>
        public static int MouseUp(IntPtr hWnd, MouseButton btn, int x, int y)
        {
            int xyPoint = NativeMacros.MAKELONG(x, y);
            int wParam = GetWParamFromButton(btn);

            return SendMessage(hWnd, (int)btn + 1, wParam, xyPoint);
        }
        /// <summary>
        /// Нажатие или отпускание определенной клавиши клавиатуры.
        /// </summary>
        //* <param name="hWnd">Дескриптор окна в которое будет послано сообщение.</param>
        ///* <param name=keys>Клавиша.</param>*/
        ///* <param name=up>FALSE если кнопка нажата, иначе TRUE.</param>*/
        /// <returns>Возвращает результат работы функции SendMessage.</returns>
        public static int KeyPress(IntPtr hWnd, Keys keys, bool up)
        {
            int WM_KEY = up ? 0x0101 /* WM_KEYUP */ : 0x0100 /* WM_KEYDOWN */;

            return SendMessage(hWnd, WM_KEY, (int)keys, 1);
        }

        public static int KeyPressInt(IntPtr hWnd, int key, bool up)
        {
            int WM_KEY = up ? 0x0101 /* WM_KEYUP */ : 0x0100 /* WM_KEYDOWN */;

            return SendMessage(hWnd, WM_KEY, key, 1);
        }
    
}

    public struct NativeMacros
    {
        /// <summary>
        /// C++ макрос для GET_X_LPARAM.
        /// </summary>
        public static int GET_X_LPARAM(int x)
        {
            return x & 0xffff;
        }
        /// <summary>
        /// C++ макрос для GET_Y_LPARAM.
        /// </summary>
        public static int GET_Y_LPARAM(int x)
        {
            return (x >> 16) & 0xffff;
        }
        /// <summary>
        /// C++ макрос для MAKELONG.
        /// </summary>
        public static int MAKELONG(int x, int y)
        {
            return (x & 0xffff) | ((y & 0xffff) << 16);
        }
    }

    public enum MouseButton : int
    {
        Left = 0x201, // WM_LBUTTONDOWN
        Right = 0x204, // WM_RBUTTONDOWN
        Middle = 0x207 // WM_MBUTTONDOWN
    }

    public enum MouseEvent
    {
        MOUSEEVENTF_LEFTDOWN = 0x02,
        MOUSEEVENTF_LEFTUP = 0x04,
        MOUSEEVENTF_RIGHTDOWN = 0x08,
        MOUSEEVENTF_RIGHTUP = 0x10,
    }

}
