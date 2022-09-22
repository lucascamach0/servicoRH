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
            MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

            MySqlCommand cmd = new MySqlCommand("select * from rh.colaborador where cpf = @cpf", sqlConnection);

            cmd.Parameters.AddWithValue("@cpf", cpf);

            MySqlDataReader sdr = cmd.ExecuteReader();

            Colaborador colaborador = new Colaborador();

            while (sdr.Read())
            {
                colaborador.IdColaborador = Convert.ToInt32(sdr["idcolaborador"].ToString());
                colaborador.Nome = sdr["nome"].ToString();
                colaborador.Cpf = sdr["cpf"].ToString();
                colaborador.DataNascimento = new DateTime();
                colaborador.DataAdmissao = new DateTime();
                colaborador.Salario = Convert.ToDouble(sdr["salario"].ToString());
            }

            return colaborador;
        }

    }
}
