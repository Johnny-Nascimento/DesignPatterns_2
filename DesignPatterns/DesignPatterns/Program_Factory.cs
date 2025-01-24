using Microsoft.Data.SqlClient;
using System.Data;

namespace MyApp_Factory
{
    public class ConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            IDbConnection conexao = new SqlConnection();
            conexao.ConnectionString = "User Id=root;Password=;Server=localhost;Database=banco";
            conexao.Open();

            return conexao;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IDbConnection conexao = new ConnectionFactory().GetConnection();

            using (IDbCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "select * from tabela";
            }

            conexao.Close();
        }
    }
}