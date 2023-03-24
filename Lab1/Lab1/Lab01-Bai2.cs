using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1, num2, num3;
            if(Double.TryParse(textBox1.Text, out num1) && Double.TryParse(textBox3.Text, out num3) && Double.TryParse(textBox2.Text, out num2))
            {
                textBox4.Text = Math.Max(Math.Max(num1, num2), num3).ToString();
                textBox5.Text = Math.Min(Math.Min(num1, num2), num3).ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Text = null;
                textBox5.Text = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           this.Close();
        
        }
    }
}
