using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;
using Button = System.Windows.Forms.Button;

namespace kolmerakendust
{
    public partial class Recover : Form
    {
        DataBase dataBase = new DataBase();
        Label lb1;
        TextBox tb1, tb2;
        Button btn;
        public Recover()
        {
            this.Size = new Size(800, 600);
            this.Text = "Unustan parooli";
            DataBase dataBase = new DataBase();
            lb1 = new Label
            {
                Text = "Email",
                Size = new System.Drawing.Size(40, 40),
                Location = new System.Drawing.Point(10, 5),
            };
            tb1 = new TextBox
            {
                Size = new System.Drawing.Size(90, 50),
                Location = new System.Drawing.Point(10, 20)
            };
            tb2 = new TextBox
            {
                Size = new System.Drawing.Size(90, 50),
                Location = new System.Drawing.Point(10, 110),
                Enabled = false,
            };
            Button btn = new Button
            {
                Text = "Saada parool",
                Size = new System.Drawing.Size(75, 50),
                Location = new System.Drawing.Point(15, 50)
            };
            btn.Click += btn_Click;
            this.Controls.Add(tb1);
            this.Controls.Add(tb2);
            this.Controls.Add(lb1);
            this.Controls.Add(btn);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT email, parol FROM Andmed WHERE email = '"+tb1.Text+"'", dataBase.getConnection());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tb2.Text = dr[1].ToString();
            }
            else
            {
                MessageBox.Show("Seda emaili pole olemas");
                tb2.Text = "";
            }
            dataBase.closeConnection();
        }
    }
}