using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowsFormsSimulate
{
    public class SimulateKeyboard
    {
        /// <summary>
        /// 模拟键盘
        /// </summary>
        /// <param name="bVk">虚拟键值</param>
        /// <param name="bScan">一般为0</param>
        /// <param name="dwFlags">0为按下,2为释放</param>
        /// <param name="dwExtraInfo">一般情况下设成为 0</param>
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static void PressDownKey(byte key)
        {
            keybd_event(key, 0, 0, 0);
        }

        public static void PressUpKey(byte key)
        {
            keybd_event(key, 0, 2, 0);
        }

        public static void PressKey(byte key)
        {
            keybd_event(key, 0, 0, 0);
            keybd_event(key, 0, 2, 0);
        }

        public static void PressKey(string key)
        {
            List<string> allkey = new List<string>();//FString.SplitString(key);
            foreach (string temp in allkey)
            {
                string[] arr = temp.Split('|');
                if (arr.Length == 1)
                {
                    PressKey(GetKeyByte(temp));
                    Thread.Sleep(50);
                }
                else
                {
                    if (arr.Length == 2)
                    {
                        if (arr[0] == "sleep")
                        {
                            Thread.Sleep(Convert.ToInt32(arr[1]));
                            continue;
                        }
                    }
                    foreach (string temp1 in arr)
                    {
                        PressDownKey(GetKeyByte(temp1));
                        Thread.Sleep(10);
                    }
                    foreach (string temp1 in arr)
                    {
                        PressUpKey(GetKeyByte(temp1));
                        Thread.Sleep(10);
                    }
                }
            }
        }

        public static byte GetKeyByte(string key)
        {
            if (key.Length == 3)
            {
                if (key == "{,}")
                {
                    key = ",";
                }
                else if (key == "{;}")
                {
                    key = ";";
                }
            }
            switch (key)
            {
                case "backspace": return 8;
                case "tab": return 9;
                case "enter": return 13;
                case "shift": return 16;
                case "ctrl": return 17;
                case "alt": return 18;
                case "capslock": return 20;
                case "space": return 32;
                case "delete": return 46;
                case "0": return 48;
                case "1": return 49;
                case "2": return 50;
                case "3": return 51;
                case "4": return 52;
                case "5": return 53;
                case "6": return 54;
                case "7": return 55;
                case "8": return 56;
                case "9": return 57;
                case "A": return 65;
                case "B": return 66;
                case "C": return 67;
                case "D": return 68;
                case "E": return 69;
                case "F": return 70;
                case "G": return 71;
                case "H": return 72;
                case "I": return 73;
                case "J": return 74;
                case "K": return 75;
                case "L": return 76;
                case "M": return 77;
                case "N": return 78;
                case "O": return 79;
                case "P": return 80; ;
                case "Q": return 81;
                case "R": return 82;
                case "S": return 83;
                case "T": return 84;
                case "U": return 85;
                case "V": return 86;
                case "W": return 87;
                case "X": return 88;
                case "Y": return 89;
                case "Z": return 90;
                case "lwin": return 91;
                case "rwin": return 92;
                case "f1": return 112;
                case "f2": return 113;
                case "f3": return 114;
                case "f4": return 115;
                case "f5": return 116;
                case "f6": return 117;
                case "f7": return 118;
                case "f8": return 119;
                case "f9": return 120;
                case "f10": return 121;
                case "f11": return 122;
                case "f12": return 123;
                case ";": return 186;
                case "=": return 187;
                case ",": return 188;
                case "-": return 189;
                case ".": return 190;
                case "/": return 191;
                case "`": return 192;
                case "[": return 219;
                case "\\": return 220;
                case "]": return 221;
                case "'": return 222;
            }
            return 0;
        }
    }
}
