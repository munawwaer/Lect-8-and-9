using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication18
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
                listBox2.Items.Add(textBox2.Text);
                listBox3.Items.Add(textBox3.Text);
                if(radioButton1.Checked)
                    listBox4.Items.Add(radioButton1.Text);
                else if(radioButton2.Checked)
                    listBox4.Items.Add(radioButton2.Text);

            }
        }
        void sele(object sender, EventArgs e)
        {
            ListBox l = ((ListBox)sender);
            listBox1.SelectedIndex = listBox2.SelectedIndex = listBox3.SelectedIndex=listBox4.SelectedIndex = l.SelectedIndex;
        }
        public void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
                listBox4.Items.RemoveAt(listBox4.SelectedIndex);
            }
            else
                MessageBox.Show("لا يوجد اسم محدد ");

        }

        public void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
             listBox4.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i=listBox1.SelectedIndex;
            if (i != -1)
            {
                 textBox1.Text=listBox1.Items[i].ToString();
                 textBox2.Text=listBox2.Items[i].ToString();
                 textBox3.Text = listBox3.Items[i].ToString();
                 if (listBox1.Items[i].ToString() == "ذكر")
                     radioButton1.Checked = true;
                 else
                     radioButton2.Checked = true;

            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            listBox1.Click += sele;
            listBox2.Click += sele;
            listBox3.Click += sele;
            listBox4.Click += sele;
        }
    }
}
