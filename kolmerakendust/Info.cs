using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kolmerakendust
{
    public partial class Info : Form
    {
        DataGridView dataGridView1 = new DataGridView();

        DataBase database = new DataBase();

        public Info()
        {
            CreateColumns();
            RefreshDataGri(dataGridView1);
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("UserID", "ID");
            dataGridView1.Columns.Add("knimi", "Esinimi");
            dataGridView1.Columns.Add("email", "Email");
            dataGridView1.Columns.Add("sugu", "Sugu");
            dataGridView1.Columns.Add("vanus", "Vanus");
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4));
        }
        private void RefreshDataGri(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string AddToDB = $"SELECT * FROM UserL";

            SqlCommand command = new SqlCommand(AddToDB, database.getConnection());
            
            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }
    }
}