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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

      
        private void button4_Click(object sender, EventArgs e)
        {
            text_all_length.Text = all_text.Text.Length.ToString();
        }
        int ind =0 ;
        string index;
        private void button5_Click(object sender, EventArgs e)
        {
            all_text.Visible = true;
            string t = all_text.Text.Trim();
           index = textBox5.Text.Trim();
             ind = t.IndexOf(index);
            if (ind == -1)
                MessageBox.Show("not found text");
            else
            {
                all_text.Select(ind, index.Length);
                all_text.Focus();
            }
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            int start;
            if (textBox5.Text.Trim() != "")
            {
                string txt = textBox5.Text.Trim();
                start = all_text.Text.Trim().LastIndexOf(txt, all_text.SelectionStart -all_text.SelectionLength);
                if (start > -1)
                {
                    all_text.Focus();
                    all_text.Select(start, textBox5.Text.Length);
                }
                else
                    MessageBox.Show("not found");
            }
            else
                MessageBox.Show("حدد النص المراد البحث عنه");
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            text_length.Text = all_text.SelectionLength.ToString();
        }
    
        private void button2_Click_1(object sender, EventArgs e)
        {
            
             string[] stopwords = all_text.Text.Trim().Split(' ');
             int x = 0;
             for (int i = 0; i < stopwords.Length; i++)
             {
                 if (stopwords[i] != " ")
                     x++;

             }
                 word_counts.Text = x.ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            all_text.SelectedText = null;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            all_text.SelectionLength = 0;
        }
        string copy = "";
        private void button13_Click(object sender, EventArgs e)
        {
            copy = all_text.SelectedText;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            all_text.SelectedText = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            all_text.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int x=0;
            for (int i=0;i<all_text.Text.Length;i++)
                if(all_text.Text[i]!=' ')
                    x++;
            button12.Text = x.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {

            int x = 0;
            for (int i = 0; i < all_text.SelectedText.Length; i++)
                if (all_text.SelectedText[i] != ' ')
                    x++;
            button16.Text = x.ToString();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            all_text.Visible = true;
            int start;
            if (textBox5.Text.Trim() != "")
            {
                string txt = textBox5.Text.Trim();
                start = all_text.Text.Trim().IndexOf(txt, all_text.SelectionStart + all_text.SelectionLength);
                if (start > -1)
                {
                    all_text.Focus();
                    all_text.Select(start, textBox5.Text.Length);
                }
                else
                    MessageBox.Show("not found");
            }
            else
                MessageBox.Show("حدد النص المراد البحث عنه");
        }
        string past="";
        int i = 0;
        private void button10_Click_1(object sender, EventArgs e)
        {
            past = all_text.SelectedText;
            i = all_text.SelectionStart;
            MessageBox.Show(i.ToString());
            if (textBox6.Text != "" && all_text.SelectionLength > 0)
            {
                all_text.SelectedText = textBox6.Text.Trim();
            }
            else
                MessageBox.Show("حدد النص اولا");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (past != "")
            {
              
                all_text.Select(i,past.Length);
                all_text.SelectedText = past+" ";
                past = "";
            }
            else
                MessageBox.Show("not found");
        }
        int s ;
       
        private void button17_Click(object sender, EventArgs e)
        {
            s = textBox7.Text.Length-1;
            
               
            textBox7.Text += " "+all_text.SelectedText;
          
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            textBox7.Select(s, copy.Length);
            textBox7.SelectedText = "";
           
        }
        private void button18_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string word = all_text.SelectedText;
            char[] ch = word.ToArray();
            for (int i = 0; i < ch.Length; i++)
                listBox1.Items.Add(ch[i]);
            // all_text.SelectedText.Trim();

        }
        private void button19_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string[] w = all_text.SelectedText.Split(' ');
            for (int i = 0; i < w.Length; i++)
                listBox2.Items.Add(w[i]);
        }
       
        private void All_shreach_Click(object sender, EventArgs e)
        {
         
            string text = textBox2.Text.Trim();
           
            
            int j;
            int m=text.Length;
            int n = all_text.Text.Length;
            string alltext =all_text.Text.Trim();
            for (int i=0;i<n-m;i++)
            {
                 j = 0;
              while (j < m && text[j ] == alltext[i + j ]) 
              j =j + 1;
              if (j == m)
              {


                  all_text.Select(i, text.Length);
                  all_text.SelectionBackColor = Color.Blue;
                  //rech.BackColor = Color.Blue;
               
                 
                  
              }

            }
           
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
