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
        TextBox textBox1, textBox2;
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
            if (check())
            {
                return;
            }

            var login = textBox1.Text;
            var password = textBox2.Text;

            string addToDB = $"INSERT INTO Andmed(nimi, parol) VALUES('{login}', '{password}')";
            
            SqlCommand command = new SqlCommand(addToDB, dataBase.getConnection());

            dataBase.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Sinu konto on loodud");
                Login vf = new Login();
                this.Hide();
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
            var password = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string addToDB = $"SELECT AndmedID, nimi, parol FROM Andmed WHERE nimi = '{login}' AND parol = '{password}'";

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