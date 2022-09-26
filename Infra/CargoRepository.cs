using MySql.Data.MySqlClient;
using ServicoRH.Domain;

namespace ServicoRH.Infra
{
    public class CargoRepository
    {
        private readonly MySqlData _mySqlConnection;
        public CargoRepository()
        {
            // criação da instancia do sql
            _mySqlConnection = new MySqlData();
        }

        public List<Cargo> ObterTodosOsCargos()
        {
            //abrindo conexao com banco
            MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

            //criando comando sql
            MySqlCommand cmd = new MySqlCommand("select * from rh.cargo", sqlConnection);

            //executando comando sql no banco
            MySqlDataReader sdr = cmd.ExecuteReader();

            List<Cargo> listDeCargos = new List<Cargo>();

            //preenchendo o valor retornando no objeto de resposta
            while (sdr.Read())
            {
                Cargo cargo = new Cargo();
                cargo.IdCargo = Convert.ToInt32(sdr["idCargo"].ToString());
                cargo.Nome = sdr["nome"].ToString();
                listDeCargos.Add(cargo);
            }

            return listDeCargos;
        }
    }
}
