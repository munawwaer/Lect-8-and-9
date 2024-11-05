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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("/");
            comboBox1.Items.Add("*");
            comboBox1.SelectedIndex = 0;
            listBox1.Click += sele;
            listBox2.Click += sele;
            listBox3.Click += sele;
            listBox4.Click += sele;
        }
        //دالة التاشير
        void sele(object sender, EventArgs e)
        {
            ListBox l = ((ListBox)sender);
            listBox1.SelectedIndex = listBox2.SelectedIndex = listBox3.SelectedIndex = listBox4.SelectedIndex = l.SelectedIndex;
        }
     //دالة لتجنب الادخال الخاطي
          bool isnumerc(string ele)
        {
            if (ele == "")
                return false;
            for (int i = 0; i < ele.Length; i++)
                if (ele[i] < 48 || ele[i] > 57)
                    return false;
            return true;

        }
        //زر حساب
        private void button1_Click(object sender, EventArgs e)
        {
            string op = comboBox1.Text;
            if (isnumerc(textBox1.Text.Trim()) && isnumerc(textBox2.Text.Trim()))
            {
                switch (op)
                {
                    case "+":
                        textBox3.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text)).ToString();
                        break;
                    case "-":
                        textBox3.Text = (Convert.ToInt32(textBox1.Text) - Convert.ToInt32(textBox2.Text)).ToString();
                        break;
                    case "*":
                        textBox3.Text = (Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text)).ToString();
                        break;
                    case "/":
                        if (textBox2.Text != "0")
                            textBox3.Text = (Convert.ToInt32(textBox1.Text) / Convert.ToInt32(textBox2.Text)).ToString();
                        else
                        {
                            MessageBox.Show("لا يمكن القسمة على صفر");
                            textBox2.Text = "";
                            textBox2.Focus();
                            return;
                        }

                        break;
                }

            }
            else
            {
                MessageBox.Show("ERorr");
                return;
            }
            listBox1.Items.Add(textBox1.Text);
            listBox2.Items.Add(comboBox1.Text);
            listBox3.Items.Add(textBox2.Text);
            listBox4.Items.Add(textBox3.Text);

        }
        //زر حذف
        private void button2_Click(object sender, EventArgs e)
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
        //زر تنظيف
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
             listBox4.Items.Clear();
        }
        //زر تعديل
        int i;
        private void button4_Click(object sender, EventArgs e)
        {
            int i=listBox1.SelectedIndex;
            if (i != -1)
            {
                textBox1.Text = listBox1.Items[i].ToString();
                comboBox1.Text = listBox2.Items[i].ToString();
                textBox2.Text = listBox3.Items[i].ToString();
                textBox3.Text = listBox4.Items[i].ToString();

            }
            else
                MessageBox.Show("جدد عنصر");
        }
        //زر حفظ التعديل
        private void button6_Click(object sender, EventArgs e)
        {
            if (i != -1)
            {
                 listBox1.Items[i] =textBox1.Text ;
                 listBox2.Items[i] = comboBox1.Text;
                 listBox3.Items[i] = textBox2.Text ;
                 listBox4.Items[i] =textBox3.Text ;

            }
            else
                MessageBox.Show("جدد عنصر");
        }

    }
}
