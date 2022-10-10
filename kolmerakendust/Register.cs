using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace kolmerakendust
{
    public partial class Register : Form
    {
        public Register()
        {
            this.Text = "Register";
            this.Size = new Size(250, 300);
            Label lb1 = new Label
            {
                Text = "Nimi",
                Size = new System.Drawing.Size(40, 40),
                Location = new System.Drawing.Point(10, 5)
            };
            Label lb2 = new Label
            {
                Text = "Parool",
                Size = new System.Drawing.Size(40, 40),
                Location = new System.Drawing.Point(10, 55)
            };
            TextBox textBox1 = new TextBox
            {
                Size = new System.Drawing.Size(90, 50),
                Location = new System.Drawing.Point(10, 20)
            };
            TextBox textBox2 = new TextBox
            {
                Size = new System.Drawing.Size(90, 50),
                Location = new System.Drawing.Point(10, 70)
            };
            Button reg = new Button
            {
                Text = "Registreerida",
                Size = new System.Drawing.Size(80, 60),
                Location = new System.Drawing.Point(15, 110)
            };
            this.Controls.Add(reg);
            reg.Click += Register_Click;
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(lb1);
            this.Controls.Add(lb2);
        }
        private void Register_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Using;Integrated Security=True;Pooling=False");
            MySqlCommand command = new MySqlCommand("INSERT INTO 'Andmed' ('id',nimi,parol) VALUES ('','')");
        }
    }
}