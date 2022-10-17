using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace kolmerakendust
{
    public partial class Register : Form
    {
        DataBase dataBase = new DataBase();
        TextBox textBox1, textBox2, textBox3, textBox4, textBox5, textBox6;
        public Register()
        {
            this.Text = "Register";
            this.Size = new Size(250, 400);
            Label lb1 = new Label{ Text = "Login",Size = new System.Drawing.Size(40, 40),Location = new System.Drawing.Point(10, 5)};
            Label lb2 = new Label{ Text = "Parool",Size = new System.Drawing.Size(40, 40),Location = new System.Drawing.Point(10, 55)};
            Label lb3 = new Label { Text = "Eesnimi", Size = new System.Drawing.Size(40, 40), Location = new System.Drawing.Point(10, 105) };
            Label lb4 = new Label { Text = "Email", Size = new System.Drawing.Size(40, 40), Location = new System.Drawing.Point(10, 155) };
            Label lb5 = new Label { Text = "Sugu", Size = new System.Drawing.Size(40, 40), Location = new System.Drawing.Point(10, 205) };
            Label lb6 = new Label { Text = "Vanus", Size = new System.Drawing.Size(40, 40), Location = new System.Drawing.Point(10, 255) };
            textBox1 = new TextBox{ Size = new System.Drawing.Size(90, 50),Location = new System.Drawing.Point(10, 20)};
            textBox2 = new TextBox{ Size = new System.Drawing.Size(90, 50),Location = new System.Drawing.Point(10, 70)};
            textBox3 = new TextBox { Size = new System.Drawing.Size(90, 50), Location = new System.Drawing.Point(10, 120) };
            textBox4 = new TextBox { Size = new System.Drawing.Size(90, 50), Location = new System.Drawing.Point(10, 170) };
            textBox5 = new TextBox { Size = new System.Drawing.Size(90, 50), Location = new System.Drawing.Point(10, 220) };
            textBox6 = new TextBox { Size = new System.Drawing.Size(90, 50), Location = new System.Drawing.Point(10, 270) };
            Button reg = new Button
            {
                Text = "Registreerida",
                Size = new System.Drawing.Size(80, 50),
                Location = new System.Drawing.Point(15, 300)
            };
            Button login = new Button
            {
                Text = "Tahan sisse logida",
                Size = new System.Drawing.Size(80, 50),
                Location = new System.Drawing.Point(115, 300)
            };
            this.Controls.Add(login);
            login.Click += Login_Click;
            this.Controls.Add(reg);
            reg.Click += Register_Click;
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox3);
            this.Controls.Add(textBox4);
            this.Controls.Add(textBox5);
            this.Controls.Add(textBox6);
            this.Controls.Add(lb1);
            this.Controls.Add(lb2);
            this.Controls.Add(lb3);
            this.Controls.Add(lb4);
            this.Controls.Add(lb5);
            this.Controls.Add(lb6);
        }
        private void Login_Click(object sender, EventArgs e)
        {
            Login vf = new Login();
            vf.ShowDialog();
            this.Close();
        }
        private void Register_Click(object sender, EventArgs e)
        {
            if (check())
            {
                return;
            }
            var login = textBox1.Text;
            var password = textBox2.Text;
            var name = textBox3.Text;
            var mail = textBox4.Text;
            var sugu = textBox5.Text;
            var vanus = textBox6.Text;

            string addToDB = $"INSERT INTO Andmed(nimi, parol, knimi, email, sugu, vanus) VALUES('{login}', '{password}', '{name}'," +
                $"'{mail}','{sugu}','{vanus}')";
            
            SqlCommand command = new SqlCommand(addToDB, dataBase.getConnection());

            dataBase.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Sinu konto on loodud");
                Login vf = new Login();
                this.Close();
                vf.Show();
            }
            else
            {
                MessageBox.Show("Konto pole loodud");
            }
            dataBase.closeConnection();
        }
        private Boolean check()
        {
            var login = textBox1.Text;
            var mail = textBox4.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string addToDB = $"SELECT AndmedID, nimi, email FROM Andmed WHERE nimi = '{login}' OR email = '{mail}'";

            SqlCommand command = new SqlCommand(addToDB, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Konto on juba olemas!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}