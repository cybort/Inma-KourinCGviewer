using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        int count = 0;
        int animecount = 1;
        bool pic1 = true;
        bool pic2 = true;
        bool pic3 = true;
        string url1 = "";
        string url2 = "";
        string url3 = "";
        string url4 = "";
        string url5 = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowPic(textBox1.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            
            {
                textBox1.Text = ((int.Parse(textBox1.Text))-4).ToString();
                ShowPic(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = ((int.Parse(textBox1.Text)) + 4).ToString();
                ShowPic(textBox1.Text);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowPic(string id)
        {
            id = (int.Parse(id)+300000).ToString();
            pictureBox1.ImageLocation = "";
            pictureBox2.ImageLocation = "";
            pictureBox1.CancelAsync();
            pictureBox2.CancelAsync();
            pictureBox4.CancelAsync();
            string sid = (int.Parse(id) + 1000).ToString();
            url1 = string.Format("http://157.7.147.219/img/anime2/sm_99_{0}_sean1.jpg",id);
            url2 = string.Format("http://157.7.147.219/img/anime2/sm_99_{0}_sean3.jpg", id);
            url3 = string.Format("http://157.7.147.219/img/anime2/sm_99_{0}_sean2.jpg", id);
            url4 = string.Format("http://157.7.147.219/img/card/de_card_e_{0}.jpg", sid);
            url5 = string.Format("http://157.7.147.219/img/card/de_card_e_{0}.jpg", id);
            if (pic1 == true)
            {
                pic1 = false;
                label1.Text = "false";
                pictureBox1.ImageLocation = @url1;
                
            }
            if (pic2 == true)
            {
                pic2 = false;
                pictureBox2.ImageLocation = @url2;
            }
            pictureBox3.ImageLocation = @url4;
            pictureBox5.ImageLocation = @url5;
        }

        private void pictureBox2_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                pic2 = true;
            }
            else pic2 = true;
        }

        private void pictureBox2_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;

        }

        private void pictureBox1_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (e.UserState != null)
            {
                MessageBox.Show(e.UserState.ToString());
            }
        }

        private void pictureBox4_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar3.Value = e.ProgressPercentage;
        }

        private void pictureBox4_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                string id = textBox1.Text;
                id = (int.Parse(id) + 300000).ToString();
                string url = String.Format("http://157.7.147.219/img/anime2/sm_99_{0}_sean2_1.jpg", id);
                pictureBox4.ImageLocation = @url;
            }
            if (e.Cancelled == true)
            {
                pic3 = true;
            }
            else
            {
                pic3 = true;
                animecount = pictureBox4.Image.Size.Height / (pictureBox4.Image.Size.Width / 4 * 3);
                pictureBox4.Height = pictureBox4.Width / 4 * 3 * animecount;
            }
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                pic1 = true;
                label1.Text = "true";
             //   MessageBox.Show("取消啦");
            }
            else { pic1 = true; label1.Text = "true"; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowPic(textBox1.Text);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled == false) timer1.Enabled = true;
            else
            {
                timer1.Enabled = false;
                pictureBox4.Top = 0;
                count = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == animecount) { pictureBox4.Top = 0; count = 0; }
            else pictureBox4.Top -= pictureBox4.Height/animecount;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            pictureBox4.Top = 0;
            count = 0;
            if (pic3 == true)
            {
                pic3 = false;
                pictureBox4.Height = pictureBox4.Width / 4 * 3;
                pictureBox4.ImageLocation = @url3;
            }
        }
    }
}
