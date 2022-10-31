using MySql.Data.MySqlClient;
using ServicoRH.API.Infra.Interface;
using ServicoRH.Domain;

namespace ServicoRH.Infra
{
    public class CargoRepository : ICargoRepository
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

        public string InserirCargo(string nomeCargo)
        {
            try
            {
                //abrindo conexao com banco
                MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

                //criando comando sql
                MySqlCommand cmd = new MySqlCommand("insert into rh.cargo (nome) values (@Cargo);", sqlConnection);
                cmd.Parameters.AddWithValue("@Cargo", nomeCargo);

                //executando comando sql no banco
                MySqlDataReader sdr = cmd.ExecuteReader();

                return "Cargo inserido com sucesso!";
            }
            catch (Exception excepetion)
            {

                return "Erro ao inserir cargo" + excepetion.ToString();
            }
        }
    }
}
