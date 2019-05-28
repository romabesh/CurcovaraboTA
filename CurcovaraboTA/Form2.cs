using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurcovaraboTA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string Password;
        
        private void button1_Click(object sender, EventArgs e)
        {
            Password = "1234";

            if (textBox100.Text == Password)
            {
               
            }
            else
            {
                MessageBox.Show("Пароль не верен!");
                textBox100.Clear();
            }
                   

            
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}


