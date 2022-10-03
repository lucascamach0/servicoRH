using MySql.Data.MySqlClient;
using ServicoRH.Domain;

namespace ServicoRH.Infra
{
    public class ColaboradorRepository
    {
        private readonly MySqlData _mySqlConnection;
        public ColaboradorRepository()
        {
            _mySqlConnection = new MySqlData();
        }

        public Colaborador BuscarColaboradorPorCpf(string cpf)
        {
            //criando objeto de retorno
            Colaborador colaboradorResult = new Colaborador();

            //abrindo conexao com banco
            MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

            //criando comando sql
            MySqlCommand cmd = new MySqlCommand("select * from rh.colaborador where cpf = @cpf", sqlConnection);
            cmd.Parameters.AddWithValue("@cpf", cpf);

            //executando comando sql no banco
            MySqlDataReader sdr = cmd.ExecuteReader();

            //preenchendo o valor retornando no objeto de resposta
            while (sdr.Read())
            {
                colaboradorResult.IdColaborador = Convert.ToInt32(sdr["idcolaborador"].ToString());
                colaboradorResult.Nome = sdr["nome"].ToString();
                colaboradorResult.Cpf = sdr["cpf"].ToString();
                colaboradorResult.DataNascimento = new DateTime();
                colaboradorResult.DataAdmissao = new DateTime();
                colaboradorResult.Salario = Convert.ToDouble(sdr["salario"].ToString());
            }

            //retornando objeto completo
            return colaboradorResult;
        }

        public string BuscarCargoDoColaborador(string cpf)
        {
            //implementar dever de casa
            string resultado = "";

            MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

            MySqlCommand cmd = new MySqlCommand(@"select rh.cargo.nome
            from rh.colaborador
            join rh.cargo on rh.cargo.idCargo = rh.colaborador.idCargo
            where cpf = @cpf ", sqlConnection);
            cmd.Parameters.AddWithValue("@cpf", cpf);

            MySqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                resultado = sdr["nome"].ToString();
            }

            return resultado;
        }


    }
}
