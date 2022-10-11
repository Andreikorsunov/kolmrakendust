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
        DataBase database = new DataBase();
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

            var login = textBox1;
            var password = textBox2;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string addToDB = $"SELECT AndmedID, nimi, parol FROM Andmed WHERE nimi = '{login}' AND parol = '{password}'";

            SqlCommand command = new SqlCommand(addToDB, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                MessageBox.Show("Sisse logitud", "Edukalt!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartMenu vf = new StartMenu();
                this.Hide();
                vf.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Seda kontot pole!", "Seda kontot pole!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}