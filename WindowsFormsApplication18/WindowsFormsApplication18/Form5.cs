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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {

            listBox1.SelectedItems.Add(textBox2.Text.Trim());
        }
    //    هنا استخدمنا هذا الكائن من فورم اخري للوصول الي دالة تمنع العناصر المكرره وكذلك الفراغ الخ....
        Form3 f = new Form3();
        private void Form5_Load(object sender, EventArgs e)
        {
            Height = groupBox1.Top + 40;
            Random r = new Random();
            while (listBox1.Items.Count < 10)
            {
                int k = r.Next(0, 100);
                if (f.chack_numbers(listBox1, k))
                {
                    listBox1.Items.Add(k.ToString());
                }
            }
        }
      public  bool isnumerc(string ele)
        {
            if (ele == "")
                return false;
            for (int i = 0; i < ele.Length; i++)
                if (ele[i] < 48 || ele[i] > 57)
                    return false;
            return true;

        }
        //زر اضافة
        private void addlistbox1_Click(object sender, EventArgs e)
        {
            if (isnumerc(textBox1.Text.Trim()))
            {

                if (f.chack_numbers(listBox1, Convert.ToInt32(textBox1.Text)))
                {
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.Clear();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("العدد مكرر");
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
            else
                MessageBox.Show("ادخل العدد بشكل صحيح");
        }
        //>
        private void one_ele_add_Click(object sender, EventArgs e)
        {
            while (listBox1.SelectedItems.Count> 0)
            {
                if (f.chack_numbers(listBox2, Convert.ToInt32(listBox1.Items[listBox1.SelectedIndex])))
                {

                    listBox2.Items.Add(listBox1.Items[listBox1.SelectedIndex]);
                }
                else
                {
                   
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
            //foreach (var item in listBox1.SelectedItems)
            //{
                
            //    if (f.chack_numbers(listBox2, Convert.ToInt32(item)))
            //    {

            //        listBox2.Items.Add(item);
            //    }
            //    else
            //    {
            //        listBox1.Items.Remove(item.ToString());
                    
            //    }

            //}

           
        }
        //odd
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            if (radioButton1.Checked)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (Convert.ToInt32(listBox1.Items[i]) % 2 != 0)
                        listBox1.SelectedIndex = i;
                }
                if (listBox1.SelectedIndex == -1)
                    MessageBox.Show("لا توجد عناصر فردبة");
            }
        }
        // even
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            if (radioButton2.Checked)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (Convert.ToInt32(listBox1.Items[i]) % 2 == 0)
                        listBox1.SelectedIndex = i;
                }
                if (listBox1.SelectedIndex == -1)
                    MessageBox.Show("لا توجد عناصر زوجية");
            }
        }
        //prim
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            bool f = false;
            if (radioButton3.Checked)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    f = true;
                    int n = Convert.ToInt32(listBox1.Items[i]);
                    for (int j = 2; j < n / 2; j++)
                        if (n % j== 0)
                        {
                            f = false;
                            break;
                        }
                    if (f)
                        listBox1.SelectedIndex = i;
                }
                if (listBox1.SelectedIndex == -1)
                    MessageBox.Show("لا توجد عناصر اولية");
            }
        }
        //>>
        private void add_all_ele_Click(object sender, EventArgs e)
        {
            
            while (listBox1.Items.Count>0)
            {
                if (f.chack_numbers(listBox2, Convert.ToInt32(listBox1.Items[0])))
                {

                    listBox2.Items.Add(listBox1.Items[0]);
                }
                else
                {
                   
                    listBox1.Items.RemoveAt(0);
                }
            }
        }
        //تم استخدام موقت ليمكن الزر ^ من الرجوع الي وضعه السابق اثناء النقر عليه مرتين خلال نص ثانية 
        int count = 0;//يمكن نعمل عن طثانية يتحولريق الموقت بحيث اذا تم انفر المزدوج خلالي نص 
        private DateTime lastclicktime = DateTime.Now;//او من خلال الوقت بانه حسب الوقت الحقيقيواذ نقر مره اخري خلال نص ثانية يتحول
        private void but_v_Click(object sender, EventArgs e)
        {
            this.Height = button11.Top+80;
            but_v.Text = "^";
             //   timer1.Start();
             if ((DateTime.Now-lastclicktime).TotalMilliseconds<=500)//if(coun==2)
            {
                this.Height = groupBox1.Top + 40;
                but_v.Text = "v";
                //timer1.Stop();
                //count = 0;
            }
           // من اجل المتغير ياخذ اخر وقت لكي يحسب في النقر التاليه
             lastclicktime = DateTime.Now;
        }
        //موقت من خلاله 

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            count++;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = i+1; j < listBox1.Items.Count; j++)
                {
                    if (Convert.ToInt32(listBox1.Items[i]) > Convert.ToInt32( listBox1.Items[j]))
                    {
                        string t = listBox1.Items[i].ToString(); ;
                        listBox1.Items[i] = listBox1.Items[j];
                        listBox1.Items[j] = t;
                    }
                }
            }
        }
    // زر الترتيب يرتب العناصر المظلله
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            int s=Convert.ToInt32(listBox1.SelectedItems.Count);
            int []arry=new int[s];
            int k = 0;
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                arry[k++] = Convert.ToInt32(listBox1.SelectedItems[i]);
            }
            for (int i = 0;i<arry.Length ;i++ )
            {
                for (int j =i+1 ; j <arry.Length; j++)
                {
                    if (arry[i] < arry[j])
                    {
                        int t = arry[i];
                        arry[i] = arry[j];
                        arry[j] = t;
                    }
                }
                listBox1.Items[listBox1.SelectedIndex]=arry[i].ToString();
                listBox1.SelectedItems.Remove(listBox1.SelectedItem);
            }






            //for (int i = 0; i < arry.Length; i++)
            //{
            //    listBox1.Items[listBox1.SelectedIndex] =arry[i].ToString();
            //    listBox1.SelectedItems.Remove(listBox1.SelectedItem);
            //}
            //يتم تظليل العناصر بعد الترتيب
            for (int i = 0; i < arry.Length; i++)
            {
                listBox1.SelectedItems.Add(arry[i].ToString());
            }
            //while (listBox1.SelectedIndex != -1)
            //{ 

            //}
                //for (int i = listBox1.SelectedIndex; ; )
                //{
                //    int n = Convert.ToInt32(listBox1.Items[i]);
                //    if (i == -1)
                //        break;
                //    listBox1.SelectedItems.Remove(listBox1.SelectedItem);

                //    for (int j = listBox1.SelectedIndex; i < listBox1.SelectedItems.Count; j++)
                //    {
                //        int n2 = Convert.ToInt32(listBox1.Items[j]);
                //        if (n > n2)
                //        {
                //            string t = n.ToString();
                //            listBox1.Items[i] = listBox1.Items[j];
                //            listBox1.Items[j] = t;
                //        }
                //        listBox1.SelectedItems.Remove(listBox1.SelectedItem);
                //    }
                //}
//---------------------------------------------------------------------------------------
            //List<string> sele = new List<string>();
            //foreach (var s in listBox1.SelectedItems)
            //{
            //    sele.Add(s.ToString());
            //}
            //sele.Sort();
            //for(int i=0;i<sele.Count;i++)
            //{
            //    MessageBox.Show(sele[i]);
            //}
            //int incorm = 0;

            //for (int i = 0; i < listBox1.Items.Count ; i++)
            //{ 

            //var item=listBox1.Items[i].ToString();
            //    if(!listBox1.SelectedItems.Contains(item))
            //    {
            //    listBox1.Items[i]=item;
            //    }
            //    else
            //    {
            //        if (incorm < sele.Count)
            //        {
            //            listBox1.Items[i] = sele[incorm];
            //            incorm++;
            //        }
            //    }

            //}
            
            }
        
        
        //عكس العناصر
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            revers(listBox1,e);
        }
        void revers(object sender, EventArgs e)
        {
            ListBox list = ((ListBox)sender);
            int s = list.Items.Count;
            for (int i = 0; i < s / 2; i++)
            {
                string n = list.Items[i].ToString();
                list.Items[i] = list.Items[s - i - 1];
                list.Items[s - i - 1] = n;
            }
        }
        //حذف عنصر مظلل
        void delete_elemint(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                if (listBox1.SelectedIndex != -1)
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else if (sender == button3)
            {
                if (listBox2.SelectedIndex != -1)
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            else
                MessageBox.Show("لا يوجد عنصر مظلل");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Click += delete_elemint;
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Click += delete_elemint;

        }
        //حذف جميع العناصر المظظللة
        void delete_elemints(object sender, EventArgs e)
        {
            if (sender == button2)
                listBox1.Items.Clear();
            else if (sender == button4)
                listBox2.Items.Clear();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {

            button2.Click += delete_elemints;
           
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button4.Click += delete_elemints;
        }

       
        //زر تظليل عنصر معين
        private void button5_Click_1(object sender, EventArgs e)
        {
            listBox1.SelectedItems.Add(textBox2.Text);
        }
        //زر حذف التظليل لعنصر محدد
        private void button6_Click(object sender, EventArgs e)
        {

           listBox1.SelectedItems.Remove(textBox3.Text);
        }
        // حذف التظليل بالاندكس
        private void button7_Click(object sender, EventArgs e)
        {
            // الطريقة الاولي
        //listBox1.SetSelected(Convert.ToInt32( textBox4.Text),false);
           
            // الطريقة الثانية يشترط انه الاندكس لازم يكون صحيح
           // int y = Convert.ToInt32(textBox4.Text);
              // listBox1.SelectedItems.Remove(listBox1.Items[y].toString());

           // الطريقة الثالثة هذه تمر علسيجميع العناصر المظلله وغيره
              //int i =listBox1.SelectedIndex;
              //while (i<listBox1.SelectedItems.Count)
              //{
              //    if (i == Convert.ToInt32(textBox4.Text.Trim()))
              //    {
              //        listBox1.SelectedItems.Remove(listBox1.Items[i].ToString());
              //        break;
              //    }
              //}

       //     هذه الطريقة الافضل لانه تمر علا العناصر المظظله فقط
          int i =listBox1.SelectedIndex;
          while (listBox1.SelectedIndex!=-1)
          {
              if (i == Convert.ToInt32(textBox4.Text.Trim()))
              {
                  listBox1.SelectedItems.Remove(listBox1.Items[i].ToString());
                  break;
              }
              else
              { // هنا نحتفظ بالاندكس السابق عشان نرجع نظلله بعد ما نخلي المتغير اي ياخذ الذي بعدة
                  int t = i;
                  // هنا نحذف التظليل للعنصر المظلل عشان نخلي  المتغير ياخذ الذي بعده
                  listBox1.SelectedItems.Remove(listBox1.Items[i].ToString());
                 
                  i = listBox1.SelectedIndex;
                  //هنا رجعنا ظللننا العدد السابق 
                  listBox1.SelectedItems.Add(listBox1.Items[t].ToString());
              }
            }
          }

        
        //زر تظليل كامل
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
                listBox1.SelectedIndex = i;
        }
        //زر عدد العناصر الغير مظللة
        private void button10_Click(object sender, EventArgs e)
        {
            textBox7.Text = Convert.ToInt32(listBox1.Items.Count - listBox1.SelectedItems.Count).ToString();
        }
        //زر عدد العناصر المظلله
        private void button9_Click(object sender, EventArgs e)
        {
          //  textBox6.Text = listBox1.SelectedItems.Count.ToString();
            //اجابة النشاط
            int x = 0;
          while(listBox1.SelectedIndex!=-1)
            {
               listBox1.SelectedItems.Remove(listBox1.SelectedItem);
                x++;
            }
          textBox6.Text = x.ToString();
        }
        //زر عدد العناصر كامل
        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text = listBox1.Items.Count.ToString();
        }
        //زر حذف التظليل كامل
        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }
        //زر اغلاق
        private void button11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            radioButton4_CheckedChanged(listBox2,e);
           
        }
       // زر عكس العناصر بالقائمة الثانية
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            revers(listBox2, e);
        }

      
        //نقل العناصر بشكل معكوس للقائمة الاخري
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            revers(listBox1, e);
            while (listBox1.Items.Count > 0)
            {
                if (f.chack_numbers(listBox2, Convert.ToInt32(listBox1.Items[0])))
                {

                    listBox2.Items.Add(listBox1.Items[0]);
                }
                else
                {
                  
                    listBox1.Items.RemoveAt(0);
                }
            }
        }
        //حذف جميع العناصر المظللة
       
       
       
    }
}
