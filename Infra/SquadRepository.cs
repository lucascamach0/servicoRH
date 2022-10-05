using MySql.Data.MySqlClient;
using ServicoRH.Domain;

namespace ServicoRH.Infra
{
    public class SquadRepository
    {
        private readonly MySqlData _mySqlConnection;
        public SquadRepository()
        {
            // criação da instancia do sql
            _mySqlConnection = new MySqlData();
        }

        public List<Squad> ObterTodosAsSquads()
        {
            //abrindo conexao com banco
            MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

            //criando comando sql
            MySqlCommand cmd = new MySqlCommand("select * from rh.squad", sqlConnection);

            //executando comando sql no banco
            MySqlDataReader sdr = cmd.ExecuteReader();

            List<Squad> listDeSquads = new List<Squad>();

            //preenchendo o valor retornando no objeto de resposta
            while (sdr.Read())
            {
                Squad squad = new Squad();
                squad.IdSquad = Convert.ToInt32(sdr["idSquad"].ToString());
                squad.Nome = sdr["nome"].ToString();
                listDeSquads.Add(squad);
            }

            return listDeSquads;
        }

        public string InserirSquad(string nomeSquad)
        {
            try
            {
                //abrindo conexao com banco
                MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

                //criando comando sql
                MySqlCommand cmd = new MySqlCommand("insert into rh.squad (nome) values (@squad);", sqlConnection);
                cmd.Parameters.AddWithValue("@squad", nomeSquad);

                //executando comando sql no banco
                MySqlDataReader sdr = cmd.ExecuteReader();

                return "Squad inserida com sucesso!";
            }
            catch (Exception excepetion)
            {

                return "Erro ao inserir squad" + excepetion.ToString();
            }
            
        }

    }
}
