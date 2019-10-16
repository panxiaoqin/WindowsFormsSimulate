using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsSimulate
{
    public class SimulateMouse
    {
        /// <summary>
        /// 模拟鼠标
        /// </summary>
        /// <param name="dwFlags">控制类型之一或它们的组合 </param>
        /// <param name="dx">根据MOUSEEVENTF_ABSOLUTE标志，指定y方向的绝对位置或相对位置 </param>
        /// <param name="dy">根据MOUSEEVENTF_ABSOLUTE标志，指定y方向的绝对位置或相对位置 </param>
        /// <param name="cButtons">没有使用（模拟滚动）</param>
        /// <param name="dwExtraInfo">没有使用</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref Point lpPoint);
        private const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        private const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        private const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起 
        private const int MOUSEEVENTF_WHEEL = 0x0800;  //表明鼠标轮被移动移动的数量由dwData给出
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标 
        public static SizeF ScreenSize = new SizeF(1920, 1080);
        public static Point GetMouseLocation()
        {
            Point defPnt = new Point();
            GetCursorPos(ref defPnt);
            return defPnt;
        }

        public static Point TransformPoint(Point point)
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            if (ScreenSize.Width == rect.Width)
            {
                return point;
            }
            float x = (rect.Width / ScreenSize.Width) * point.X;
            float y = (rect.Height / ScreenSize.Height) * point.Y;
            return new Point((int)x, (int)y);
        }

        public static void MouseTo(Point point)
        {
            point = TransformPoint(point);
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            int left = point.X * 65536 / rect.Width;
            int top = point.Y * 65536 / rect.Height;
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, left, top, 0, 0);
        }

        public static void MouseLeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void MouseRightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        public static void MouseMiddleClick()
        {
            mouse_event(MOUSEEVENTF_MIDDLEDOWN | MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
        }

        public static void MouseDoubleClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        public static void MouseEvent(int value)
        {
            mouse_event(value, 0, 0, 0, 0);
        }
        public static int GetMouseEventByType(string type)
        {
            switch (type)
            {
                case "leftdown":
                    return MOUSEEVENTF_LEFTDOWN;
                case "leftup":
                    return MOUSEEVENTF_LEFTUP;
                case "rightdown":
                    return MOUSEEVENTF_RIGHTDOWN;
                case "rightup":
                    return MOUSEEVENTF_RIGHTUP;
                case "middledown":
                    return MOUSEEVENTF_MIDDLEDOWN;
                case "middleup":
                    return MOUSEEVENTF_MIDDLEUP;
                case "left":
                    return MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP;
                case "right":
                    return MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP;
                case "middle":
                    return MOUSEEVENTF_MIDDLEDOWN | MOUSEEVENTF_MIDDLEUP;
            }
            return 0;
        }

        public static void MouseWheelMove(int range)
        {
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -range, 0);
        }

        public static void MouseToAnimation(Point point)
        {
            point = TransformPoint(point);
            Point nowpoint = GetMouseLocation();
            float x = point.X - nowpoint.X;
            float y = point.Y - nowpoint.Y;
            float k = y / x;
            float b = point.Y - k * point.X;
            int start = nowpoint.X;
            int end = point.X;
            const int add = 3;
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            if (start > end)
            {
                for (int i = start; i > end; i -= add)
                {
                    int left = i;
                    int top = Convert.ToInt32((k * i + b));
                    left = left * 65536 / rect.Width;
                    top = top * 65536 / rect.Height;
                    mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, left, top, 0, 0);
                    Thread.Sleep(1);
                }
            }
            else
            {
                for (int i = start; i < end; i += add)
                {
                    int left = i;
                    int top = Convert.ToInt32((k * i + b));
                    left = left * 65536 / rect.Width;
                    top = top * 65536 / rect.Height;
                    mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, left, top, 0, 0);
                    Thread.Sleep(1);
                }
            }
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, point.X * 65536 / rect.Width, point.Y * 65536 / rect.Height, 0, 0);
        }

        public static void MouseWheelAnimation(int range)
        {
            const int add = 3;
            if (range > 0)
            {
                for (int i = 0; i < range; i += add)
                {
                    mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -add, 0);
                    Thread.Sleep(1);
                }
            }
            else
            {
                for (int i = 0; i > range; i -= add)
                {
                    mouse_event(MOUSEEVENTF_WHEEL, 0, 0, add, 0);
                    Thread.Sleep(1);
                }
            }
        }
    }
}
