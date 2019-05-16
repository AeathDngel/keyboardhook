using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Drawing;

namespace KeyboardHook_ConsoleApp
{
    class Program
    {
        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x0100;

        private static LowLevelKeyboardProc _proc = HookCallback;

        private static IntPtr _hookID = IntPtr.Zero;


        public static void Main()

        {

            _hookID = SetHook(_proc);

            Application.Run();

            UnhookWindowsHookEx(_hookID);

            
        }


        private static IntPtr SetHook(LowLevelKeyboardProc proc)

        {

            using (Process curProcess = Process.GetCurrentProcess())

            using (ProcessModule curModule = curProcess.MainModule)

            {

                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,

                    GetModuleHandle(curModule.ModuleName), 0);

            }

        }
        
        

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

           private static string[]  scut = new string[3];
           private static int counter = 0;
           private static bool write = false;
           private static string line = "";

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
             

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)

            {

                int vkCode = Marshal.ReadInt32(lParam);

            
                if(counter == 0)
                {
                    scut[0] = vkCode.ToString();
                    counter++;


                }else if(counter == 1)
                {
                    scut[1] = vkCode.ToString();
                    counter++;
                }
                else if(counter == 2)
                {
                    scut[2] = vkCode.ToString();
                    counter = 0;
                    if(scut[0] == "160" && scut[1] == "162" && scut[2] =="83"){
                        MessageBox.Show("ShiftCtrlS");
                        write = true;
                    }else if(scut[0] == "162" && scut[1] == "83" && scut[2] =="160"){
                        MessageBox.Show("ShiftCtrlS");
                        write = true;
                    }else if(scut[0] == "83" && scut[1] == "160" && scut[2] =="162"){
                        MessageBox.Show("ShiftCtrlS");
                        write = true;
                    }
                }
               
                
                //
              
                    
                 //
                //
                //VERANDER HIER OM NA FILES TO TE WRITE
                //
                //      |
                //      V
                Console.WriteLine((Keys)vkCode);

                //
                if ((Keys)vkCode == Keys.Left)
                {
                    Cursor.Position = new Point(Cursor.Position.X - 10, Cursor.Position.Y);
                }
                else if ((Keys)vkCode == Keys.Right)
                {
                    Cursor.Position = new Point(Cursor.Position.X + 10, Cursor.Position.Y);
                }
                else if ((Keys)vkCode == Keys.Up)
                {
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 10);
                }
                else if ((Keys)vkCode == Keys.Down)
                {
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 10);
                }

                line += (Keys)vkCode;

                if(write){

                    //MessageBox.Show(line);
                    using (System.IO.StreamWriter file = 
                      new System.IO.StreamWriter(@".\saved.txt", true))//put in correct path
                      {
                         file.WriteLine(line+"\r\n");
                      }
                    line = String.Empty;

                    write = false;
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        }

       


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr SetWindowsHookEx(int idHook,

            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool UnhookWindowsHookEx(IntPtr hhk);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,

            IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr GetModuleHandle(string lpModuleName);

    }
}
