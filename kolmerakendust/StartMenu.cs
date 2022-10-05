using System;
using System.Drawing;
using System.Windows.Forms;

namespace kolmerakendust
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            this.Text = "Mängu valik";
            this.Width = 800;
            this.Height = 300;

            Button Start_btn = new Button
            {
                Text = "Pildid",
                Size = new System.Drawing.Size(90, 80),
                Location = new System.Drawing.Point(240, 80)
            };
            this.Controls.Add(Start_btn);
            Start_btn.Click += Start_btn_Click;

            Button Start_btn_2 = new Button
            {
                Text = "Math Mäng",
                Size = new System.Drawing.Size(90, 80),
                Location = new System.Drawing.Point(360, 80)
            };
            Start_btn_2.Click += Start_btn_2_Click;
            this.Controls.Add(Start_btn_2);

            Button Start_btn_3 = new Button
            {
                Text = "Matching",
                Size = new System.Drawing.Size(90, 80),
                Location = new System.Drawing.Point(480, 80)
            };
            Start_btn_3.Click += Start_btn_3_Click;
            this.Controls.Add(Start_btn_3);
        }
        private void Start_btn_Click(object sender, EventArgs e)
        {
            Pildid vf = new Pildid();
            vf.Show();
        }
        private void Start_btn_2_Click(object sender, EventArgs e)
        {
            MathMang vf = new MathMang();
            vf.Show();
        }
        private void Start_btn_3_Click(object sender, EventArgs e)
        {
            Matching vf = new Matching();
            vf.Show();
        }
    }
}