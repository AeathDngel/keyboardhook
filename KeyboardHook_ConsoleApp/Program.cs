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

namespace KeyboardHook_ConsoleApp
{
    class Program
    {
        public static int[] lastEntered { get; set; }



        public static bool writeToFile { get; set; }

        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x0100;

        private static LowLevelKeyboardProc _proc = HookCallback;

        private static IntPtr _hookID = IntPtr.Zero;


        public static void Main()

        {

            _hookID = SetHook(_proc);

            Application.Run();

            UnhookWindowsHookEx(_hookID);

            writeToFile = false;
            lastEntered = new int[3];
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


        private delegate IntPtr LowLevelKeyboardProc(

            int nCode, IntPtr wParam, IntPtr lParam);


        private static IntPtr HookCallback(

            int nCode, IntPtr wParam, IntPtr lParam)

        {

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)

            {

                int vkCode = Marshal.ReadInt32(lParam);

                String path = @".\StoreKeys.txt";

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine((Keys)vkCode + "\r\n");
                    sw.Close();
                }

                //storeLastEntered(lastEntered);

                checkShortcut();

                if(writeToFile)
                {
                    String pathShortcut = @"Desktop\ShortcutPressed.txt";

                    using (StreamWriter sw = File.AppendText(pathShortcut))
                    {
                        sw.WriteLine((Keys)vkCode + "\r\n");
                        sw.Close();
                    }
                }

                Console.WriteLine((Keys)vkCode);

            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        }

        public static void storeLastEntered(int[] paramArray)
        {
            
        }

        public static void checkShortcut()
        {
            int[] enteredArray = new int[3];

            String path = @".\StoreKeys.txt";
            int numberOfEntries = File.ReadLines(path).Count();
            string[] allLines = (File.ReadAllLines(path));

            if (numberOfEntries > 3)
            {

                enteredArray[0] = int.Parse(allLines[numberOfEntries - 2]);
                enteredArray[1] = int.Parse(allLines[numberOfEntries - 1]);
                enteredArray[2] = int.Parse(allLines[numberOfEntries]);


            }

            if ((Keys)enteredArray[0] == Keys.ControlKey && (Keys)enteredArray[1] == Keys.Shift && (Keys)enteredArray[0] == Keys.S)
            {
                if (writeToFile)
                {
                    writeToFile = false;
                    MessageBox.Show(writeToFile.ToString());
                }
                else if (!writeToFile)
                {
                    writeToFile = true;
                    MessageBox.Show(writeToFile.ToString());
                }
            }
        }

        public bool getWriteToFile()
        {
            if (writeToFile == true)
            {
                return true;
             }
            else
            {
                return false;
            }
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
