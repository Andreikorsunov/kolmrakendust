using System;
using System.Drawing;
using System.Windows.Forms;

namespace kolmerakendust
{
    public partial class StartOfStartMenu : Form
    {
        public StartOfStartMenu()
        {
            this.Text = "Register/Login Form";
            this.Width = 800;
            this.Height = 300;

            Button Start_btn = new Button
            {
                Text = "Registreerida",
                Size = new System.Drawing.Size(90, 80),
                Location = new System.Drawing.Point(240, 80)
            };
            this.Controls.Add(Start_btn);
            Start_btn.Click += Start_btn_Click;

            Button Start_btn_2 = new Button
            {
                Text = "Logi Sisse",
                Size = new System.Drawing.Size(90, 80),
                Location = new System.Drawing.Point(360, 80)
            };
            Start_btn_2.Click += Start_btn_2_Click;
            this.Controls.Add(Start_btn_2);
        }
        private void Start_btn_Click(object sender, EventArgs e)
        {
            Register vf = new Register();
            vf.Show();
            this.Hide();
        }
        private void Start_btn_2_Click(object sender, EventArgs e)
        {
            Login vf = new Login();
            vf.Show();
            this.Hide();
        }
    }
}