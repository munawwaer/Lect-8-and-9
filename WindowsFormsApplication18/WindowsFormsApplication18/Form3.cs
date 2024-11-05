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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            while (listBox1.Items.Count<10)
            {
                int k=r.Next(0,100);
                if (chack_numbers(listBox1,k))
                {
                    listBox1.Items.Add(k);
                }
            }

        }
        //داله عامله
    public    bool chack_numbers(ListBox list,int key)
        {
            for (int i = 0; i < list.Items.Count; i++)
                if (Convert.ToInt32(list.Items[i]) == key||key>=100)
                    return false;
            return true;
        }
        //زر حذف العنصر المحدد
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
              
        }
        //زر حذف الكل
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        // زر المجموع
        int s = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < listBox1.Items.Count; i++)
                s += Convert.ToInt32(listBox1.Items[0]);
            textBox2.Text = s.ToString();
        }
        //زر المعدل
        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = (s / listBox1.Items.Count).ToString();
        }
        //زر الاضافة
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count >= 20)
                listBox1.Items.RemoveAt(0);
            else if (chack_numbers(listBox1, Convert.ToInt32(textBox1.Text)))
                listBox1.Items.Add(textBox1.Text);
            else
                MessageBox.Show("Erorr  ","تحذير");
        }

    }
}
