using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Net;
using System.Windows.Forms;
using JumpKick;
using JumpKick.HttpLib;

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
        
        string url1 = "";
        string url2 = "";
        string url3 = "";
        string url3_1 = "";
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
            id = (int.Parse(id) + 300000).ToString();
            pictureBox1.ImageLocation = "";
            pictureBox2.ImageLocation = "";
            pictureBox1.CancelAsync();
            pictureBox2.CancelAsync();
            pictureBox4.CancelAsync();
            string sid = (int.Parse(id) + 1000).ToString();
            url1 = string.Format("http://157.7.147.219/img/anime2/sm_99_{0}_sean1.jpg", id);
            url2 = string.Format("http://157.7.147.219/img/anime2/sm_99_{0}_sean3.jpg", id);
            url3 = string.Format("http://157.7.147.219/img/anime2/sm_99_{0}_sean2.jpg", id);
            url3_1 = string.Format("http://157.7.147.219/img/anime2/sm_99_{0}_sean2_1.jpg", id);
            url4 = string.Format("http://157.7.147.219/img/card/de_card_e_{0}.jpg", sid);
            url5 = string.Format("http://157.7.147.219/img/card/de_card_e_{0}.jpg", id);
            Http.Get(url1).OnSuccess((WebHeaderCollection result, Image img) =>
            {
                pictureBox1.Image = img;

            }, (copied, total) =>
            {
                SetProgressBar(progressBar1, (int)copied, (int)total);
            }).Go();
            Http.Get(url2).OnSuccess((WebHeaderCollection result, Image img) =>
            {
                pictureBox2.Image = img;

            }, (copied, total) =>
                {
                    SetProgressBar(progressBar2, (int)copied, (int)total);
                }).Go();
            Http.Get(url3).OnSuccess((WebHeaderCollection result, Image img) =>
            {
                timer1.Enabled = false;
                pictureBox4.Top = 0;
                count = 0;
                SetPicturebox4Height(pictureBox4.Width / 4 * 3);
                pictureBox4.Image = img;
            }, (copied, total) =>
                {
                    SetProgressBar(progressBar3, (int)copied, (int)total);
                }).OnFail(ex =>
                {
                    Http.Get(url3_1).OnSuccess((WebHeaderCollection result, Image img) =>
                    {
                        pictureBox4.Image = img;
                        animecount = img.Height / (img.Width / 4 * 3);
                        SetPicturebox4Height(pictureBox4.Width / 4 * 3 * animecount);
                    }, (copied, total) =>
                    {
                        SetProgressBar(progressBar3, (int)copied, (int)total);
                    }).Go();

                }).Go();
            Http.Get(url4).OnSuccess((WebHeaderCollection result, Image img) =>
            {
                pictureBox3.Image = img;

            }).Go();
            Http.Get(url5).OnSuccess((WebHeaderCollection result, Image img) =>
            {
                pictureBox5.Image = img;

            }).Go();
        }

        private void SetPicturebox4Height(int height)
        {
            Invoke(new MethodInvoker(delegate
            {
                this.pictureBox4.Height = height;
            }));
        }
        private void SetProgressBar(ProgressBar pb, int value, int max)
        {
            Invoke(new MethodInvoker(delegate
            {
                pb.Maximum = max;
                pb.Value = value;
            }));
        }

        private void pictureBox2_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
        }

        private void pictureBox2_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void pictureBox1_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void pictureBox4_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar3.Value = e.ProgressPercentage;
        }

        private void pictureBox4_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

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
            
        }
    }
}
