using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using TextBox = System.Windows.Forms.TextBox;
using Button = System.Windows.Forms.Button;

namespace kolmerakendust
{
    public partial class Login : Form
    {
        Label lb1, lb2;
        TextBox textBox1, textBox2;
        public Login()
        {
            this.Text = "Login";
            this.Size = new Size(250, 300);
            lb1 = new Label
            {
                Text = "Nimi",
                Size = new System.Drawing.Size(40, 40),
                Location = new System.Drawing.Point(10, 5)
            };
            lb2 = new Label
            {
                Text = "Parool",
                Size = new System.Drawing.Size(40, 40),
                Location = new System.Drawing.Point(10, 55)
            };
            textBox1 = new TextBox
            {
                Size = new System.Drawing.Size(90, 50),
                Location = new System.Drawing.Point(10, 20)
            };
            textBox2 = new TextBox
            {
                Size = new System.Drawing.Size(90, 50),
                Location = new System.Drawing.Point(10, 70)
            };
            Button login = new Button
            {
                Text = "Logi sisse",
                Size = new System.Drawing.Size(80, 60),
                Location = new System.Drawing.Point(15, 110)
            };
            this.Controls.Add(login);
            login.Click += button1_Click;
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(lb1);
            this.Controls.Add(lb2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Using;Integrated Security=True;Pooling=False");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Andmed Where nimi='" + textBox1.Text + "' and parol = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();

                StartMenu f2 = new StartMenu();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Palun kontrolli sisestatud andmete õigsust!");
            }
        }
    }
}