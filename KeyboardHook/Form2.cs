using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Input;


namespace KeyboardHook
{
    public partial class Form2 : Form
    {

        //Get Import code from pinvoke.net for each hook method used.
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int hookId, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        //Create a Low-Level keyboard process
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        //Initialize Low Level keyboard key, and key down
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        //Initialize Low-Level Keyboard procedure and hookID
        private LowLevelKeyboardProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;


        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);


            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam, Form2 form)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                
                form.writeKeys(Convert.ToString((Keys)vkCode));
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }


        public void writeKeys(string keys)
        {
            txtKeys.AppendText(keys);
        }


        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _hookID = SetHook(_proc);
            UnhookWindowsHookEx(_hookID);
            
            
        }     

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }
    }

    


}
