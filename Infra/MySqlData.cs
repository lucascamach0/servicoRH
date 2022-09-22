using MySql.Data.MySqlClient;

namespace ServicoRH.Infra
{
    public class MySqlData
    {
        public MySqlConnection AbrirConexaoSQL()
        {

            string conenctionString = "Server=127.0.0.1;Uid=root;Pwd=root123;";

            var sqlConn = new MySqlConnection(conenctionString);

            sqlConn.Open();

            return sqlConn;
        }   

        public void FecharConexaoSQL(MySqlConnection sqlConn)
        {
            sqlConn.Close();
        }
    }
}
