using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Count() != 0 && this.textBox2.Text.Count() != 0 && this.textBox3.Text.Count() != 0 && this.textBox4.Text.Count() != 0 && this.comboBox1.SelectedText.Count() != 0)
            {
                Fraccion ff1 = new Fraccion(Convert.ToInt64(this.textBox1.Text), Convert.ToInt64(this.textBox2.Text));
                Fraccion ff2 = new Fraccion(Convert.ToInt64(this.textBox3.Text), Convert.ToInt64(this.textBox4.Text));
                Fraccion ffresult = new Fraccion();
                char operation = Convert.ToChar(this.comboBox1.SelectedText);


                Problema p1 = new Problema();
                ffresult = p1.problema(ff1, ff2, operation);

                this.textBox5.Text = Convert.ToString(ffresult.num);
                this.textBox6.Text = Convert.ToString(ffresult.den);
            }
        }
    }
}
