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

namespace KeyboardHook
{
    public partial class Form2 : Form
    {
       

       

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }     

        private void button1_Click(object sender, EventArgs e)
        {
            if(btnMouseControl.Text == "Disallow Mouse Control with Arrow Keys")
            {
                btnMouseControl.Text = "Allow Mouse Control with Arrow Keys";
            }
            else
            {
                btnMouseControl.Text = "Disallow Mouse Control with Arrow Keys";
            }
            
        }
    }

    


}
