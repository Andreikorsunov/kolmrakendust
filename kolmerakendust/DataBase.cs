using System.Data.SqlClient;

namespace kolmerakendust
{
    class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Using;Integrated Security=True");
        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
