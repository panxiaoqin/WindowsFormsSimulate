using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsSimulate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            //HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Shift, Keys.S);
            ////注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            //HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Ctrl, Keys.B);
            ////注册热键Alt+D，Id号为102。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。
            //HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.Alt, Keys.D);

            bindData();
        }

        public void bindData()
        {
            List<BindData> listMouse = new List<BindData>();
            listMouse.Add(new BindData("没有", 0));
            listMouse.Add(new BindData("左键", 1));
            listMouse.Add(new BindData("右键", 2));
            cbo_mouse.DataSource = listMouse;
            cbo_mouse.DisplayMember = "Name";
            cbo_mouse.ValueMember = "Value";
            cbo_mouse.SelectedIndex = 0;


            List<BindData> listTime = new List<BindData>();
            for (int i = 1; i <= 5; i++)
            {
                listTime.Add(new BindData($"0.0{i}秒", 10 * i));
            }

            listTime.Add(new BindData("0.1秒", 100));
            listTime.Add(new BindData("0.2秒", 200));
            listTime.Add(new BindData("0.5秒", 500));
            for (int i = 1; i <= 10; i++)
            {
                listTime.Add(new BindData($"{i}秒", i * 1000));
            }
            cbo_time.DataSource = listTime;
            cbo_time.DisplayMember = "Name";
            cbo_time.ValueMember = "Value";
            cbo_time.SelectedIndex = 5;

            List<BindData> hKey = new List<BindData>();
            int value = (int)Keys.F1;
            for (int i = 1; i <= 12; i++)
            {
                hKey.Add(new BindData($"F{i}", (value + i - 1)));
            }
            cbo_hkey.DataSource = hKey;
            cbo_hkey.DisplayMember = "Name";
            cbo_hkey.ValueMember = "Value";
            cbo_hkey.SelectedIndex = 7;

            List<BindData> listKey = new List<BindData>();
            listKey.Add(new BindData("没有", 0));
            listKey.Add(new BindData("Space", (int)Keys.Space));
            listKey.Add(new BindData("Enter", (int)Keys.Enter));
            cbo_key.DataSource = listKey;
            cbo_key.DisplayMember = "Name";
            cbo_key.ValueMember = "Value";
            cbo_key.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ////注销Id号为100的热键设定
            //HotKey.UnregisterHotKey(Handle, 100);
            ////注销Id号为101的热键设定
            //HotKey.UnregisterHotKey(Handle, 101);
            ////注销Id号为102的热键设定
            //HotKey.UnregisterHotKey(Handle, 102);
            HotKey.UnregisterHotKey(Handle, 100);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        //case 100:    //按下的是Shift+S
                        //    //此处填写快捷键响应代码 
                        //    break;
                        //case 101:    //按下的是Ctrl+B
                        //    //此处填写快捷键响应代码
                        //    break;
                        //case 102:    //按下的是Alt+D
                        //    //此处填写快捷键响应代码
                        //    break;
                        case 100:
                            if (timer1.Enabled)
                            {
                                timer1.Stop();
                                cbo_mouse.Enabled = true;
                                cbo_key.Enabled = true;
                                cbo_hkey.Enabled = true;
                                cbo_time.Enabled = true;
                            }
                            else
                            {
                                timer1.Start();
                                cbo_mouse.Enabled = false;
                                cbo_key.Enabled = false;
                                cbo_hkey.Enabled = false;
                                cbo_time.Enabled = false;
                            }
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        public class BindData
        {
            public string Name { get; set; }

            public int Value { get; set; }

            public BindData(string name, int value)
            {
                Name = name;
                Value = value;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BindData temp1 = (BindData)cbo_mouse.SelectedItem;
            BindData temp2 = (BindData)cbo_key.SelectedItem;
            if (temp1.Value == 1)
            {
                SimulateMouse.MouseLeftClick();
            }
            else if (temp1.Value == 2)
            {
                SimulateMouse.MouseLeftClick();
            }

            if (temp2.Value != 0)
            {
                SimulateKeyboard.PressKey((byte)temp2.Value);
            }
        }

        private void cbo_hkey_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData temp = (BindData)cbo_hkey.SelectedItem;
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.None, (Keys)temp.Value);
        }

        private void cbo_time_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData temp = (BindData)cbo_time.SelectedItem;
            timer1.Interval = temp.Value;
        }
    }
}
