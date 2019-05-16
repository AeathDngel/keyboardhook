using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardHook
{
    public partial class Form1 : Form
    {
        private string hook = "";
        private int counter = 0; //state of keyboardhook 0 = paused 1 =running

        public Form1()
        {
            InitializeComponent();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {


            MessageBox.Show(e.KeyChar.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Keyboard hook Zonica
            hook += e.KeyCode.ToString(); //capture keycode that was pressed
            label1.Text = String.Empty;
            label1.Text += hook;





        }
    }
}

