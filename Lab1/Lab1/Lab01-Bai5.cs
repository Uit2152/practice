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
    public partial class Bai5 : Form
    {
        public Bai5()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int numa, numb;
            long GTa = 1, GTb = 1, S1 = 1, S2 = 1;
            double S3=0;
            if(Int32.TryParse(textA.Text, out numa) && Int32.TryParse(textB.Text, out numb))
            {
                for(int i=1;i<=numa;i++)
                    GTa = GTa * i;
                
                for (int i = 1; i <= numb; i++)
                    GTb = GTb * i;

                for (int i = 1; i <= numa; i++)
                    S1 = S1 + i;

                for (int i = 1; i <= numb; i++)
                    S2 = S2 + i;

                for(int i=1; i<=numb; i++)
                {
                    S3 = S3 + Math.Pow(numa, i);
                }

                textBox1.Text = GTa.ToString();//"A! = ";// + GTa.ToString()+ "B! = "+ GTb.ToString();


                
            }
        }
    }
}
