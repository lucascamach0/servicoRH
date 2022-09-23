using ServicoRH.Domain;
using MySql.Data.MySqlClient;

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

    }
}
