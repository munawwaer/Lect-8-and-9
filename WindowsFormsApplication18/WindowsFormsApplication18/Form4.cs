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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        ListBox listitems = new ListBox();
        ListBox listindex = new ListBox();
        string copy = "";
        // متغير من خلالة يعطي تنبية للمستخدم اذا ضغط اكثر من ضغطه للزر لصق
        bool t = false;
        //زر نسخ
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                copy = textBox1.SelectedText;
                t = true;
            }
            else
                MessageBox.Show("لا يوجد نص محدد للنسخ ");
            // لا يتم نسخ البيانات الي القائمه كونه عملية نسخ وليس قص 
            // listindex.Items.Add(textBox1.SelectionStart);
            // listitems.Items.Add(textBox1.SelectedText);
        }
        //زر قص في حال كان العمليات اكثر من عشر يتم حذف العمليه الاقدم
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                t = true;
                copy = textBox1.SelectedText;
                if (listindex.Items.Count >= 10)
                {
                    listindex.Items.RemoveAt(0);
                    listitems.Items.RemoveAt(0);
                }
                listindex.Items.Add(textBox1.SelectionStart);
                listitems.Items.Add(textBox1.SelectedText);
                textBox1.SelectedText = "";
            }
            else
                MessageBox.Show("لا يوجد نص محدد");
        }
        // زر اضافة لا يستطيع ان يكرر عملية الاضافه اكثر من مره لنفس النص يعنص عندا يقص او ينسخ معه مره وحده يضغط علا الزر اذا عاد الضغطه يعطية تنبية
        private void button3_Click(object sender, EventArgs e)
        {
            if (copy != null && t == true)
            {
                textBox2.Text += " " + copy;
                t = false;
            }
            else
                MessageBox.Show("لايوجد نص محدد ");
        }
        //زر تراجع لا يعمل هذا الزر الا مع الفص لانه يتم عملية حف المقطع من النص 
        private void button4_Click(object sender, EventArgs e)
        {
            if (listitems.Items.Count < 0 || listindex.Items.Count == 0)
                MessageBox.Show("لا يمكن عملية التراجع");
            else
            {
                int i = listitems.Items.Count - 1;
                //نقوم باخذ الفهرس الموقع للنص المحذف عشان نلاجعه مكانه
                int index = Convert.ToInt32(listindex.Items[i]);
                //تقوم باخ الموشر الي موقع النص الذي حذف منه
                textBox1.SelectionStart = index;
                //نقوم باسناد النص الي المربع الاول بمعني تراجع
                textBox1.SelectedText = listitems.Items[i].ToString();
                //نبدل بدل المقطع الذي رجعنه من المربع الثاني الي المربع الاول بفراغ
                textBox2.Text = textBox2.Text.Replace(listitems.Items[i].ToString(), string.Empty);
                //نحذف الفهرس والمقطع من القوائم
                listitems.Items.RemoveAt(i);
                listindex.Items.RemoveAt(i);
            }
        }
        // زر خروج
        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
