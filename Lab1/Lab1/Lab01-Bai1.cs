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
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1, num2, sum;
            if(Int32.TryParse(textBox1.Text, out num1) && Int32.TryParse(textBox2.Text, out num2))
            {
                sum = num1 + num2;
                textBox3.Text = sum.ToString();
            }
            else
            {
                if (!Int32.TryParse(textBox1.Text, out num1))
                    MessageBox.Show("Vui lòng nhập số nguyên","",MessageBoxButtons.OK);
                if( !Int32.TryParse(textBox2.Text, out num2))
                    MessageBox.Show("Vui lòng nhập số nguyên", "", MessageBoxButtons.OK);

            }
        }
    }
}
