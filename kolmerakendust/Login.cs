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
        DataBase dataBase = new DataBase();
        Label lb1, lb2;
        TextBox textBox1, textBox2;
        public Login()
        {
            this.Text = "Login";
            this.Size = new Size(220, 270);
            lb1 = new Label
            {
                Text = "Login",
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
                Size = new System.Drawing.Size(75, 50),
                Location = new System.Drawing.Point(15, 110)
            };
            Button reg = new Button
            {
                Text = "Tahan registreerida",
                Size = new System.Drawing.Size(75, 50),
                Location = new System.Drawing.Point(100, 110)
            };
            Button rec = new Button
            {
                Text = "Unustan parooli",
                Size = new System.Drawing.Size(75, 50),
                Location = new System.Drawing.Point(50, 170)
            };
            this.Controls.Add(reg);
            this.Controls.Add(login);
            this.Controls.Add(rec);
            login.Click += button1_Click;
            reg.Click += button2_Click;
            rec.Click += button3_Click;
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(lb1);
            this.Controls.Add(lb2);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Register vf = new Register();
            vf.ShowDialog();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Recover vf = new Recover();
            vf.ShowDialog();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string addToDB = $"SELECT AndmedID, nimi, parol FROM Andmed WHERE nimi = '{login}' AND parol = '{password}'";

            SqlCommand command = new SqlCommand(addToDB, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                MessageBox.Show("Sisse logitud", "Edukalt!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartMenu vf = new StartMenu();
                this.Close();
                vf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seda kontot pole!", "Seda kontot pole!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}