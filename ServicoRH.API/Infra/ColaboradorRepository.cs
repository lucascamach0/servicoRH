using MySql.Data.MySqlClient;
using ServicoRH.Domain;
using ServicoRH.DTO;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Infra
{
    public class ColaboradorRepository : IColaboradorRepository
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

        public string BuscarSquadPorCpf(string cpf)
        {
            string resultado = "";

            MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

            MySqlCommand cmd = new MySqlCommand(@"select rh.squad.nome
            from rh.colaborador 
            join rh.squad on rh.squad.idSquad = rh.colaborador.idSquad
            where cpf = @cpf", sqlConnection);
            cmd.Parameters.AddWithValue("@cpf", cpf);

            MySqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                resultado = sdr["nome"].ToString();
            }

            return resultado;
        }

        public List<Colaborador> BucarTodosOsColaboradorPorSquad(string squad)
        {

            MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

            MySqlCommand cmd = new MySqlCommand(@"select rh.colaborador.cpf, 
            rh.colaborador.nome, 
            rh.colaborador.datanascimento, 
            rh.colaborador.salario, 
            rh.colaborador.dataadmissao, 
            rh.cargo.nome as nomeCargo,
            rh.squad.nome as nomeSquad 
            from rh.colaborador
            join rh.cargo on rh.cargo.idCargo = rh.colaborador.idCargo 
            join rh.squad on rh.squad.idSquad = rh.colaborador.idSquad 
            where squad.nome = @squad.nome", sqlConnection);
            cmd.Parameters.AddWithValue("@squad.nome", squad);

            MySqlDataReader sdr = cmd.ExecuteReader();

            List<Colaborador> listaDeColaboradores = new List<Colaborador>();

            while (sdr.Read())
            {
                Colaborador colaborador = new Colaborador();

                colaborador.Nome = sdr["nome"].ToString();
                colaborador.Cpf = sdr["cpf"].ToString();
                colaborador.DataNascimento = new DateTime();
                colaborador.DataAdmissao = new DateTime();
                colaborador.Salario = Convert.ToDouble(sdr["salario"].ToString());
                colaborador.Cargo = sdr["nomeCargo"].ToString();
                colaborador.Squad = sdr["nomeSquad"].ToString();

                listaDeColaboradores.Add(colaborador);
            }

            return listaDeColaboradores;
        }

        public List<Colaborador> BuscarColaboradorPorSalario(double salario)
        {
            MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

            MySqlCommand cmd = new MySqlCommand(@"select rh.colaborador.nome,
            rh.colaborador.salario,
            rh.cargo.nome
            from rh.colaborador
            join rh.cargo on rh.cargo.idCargo = rh.colaborador.idCargo 
            where salario >= @salario", sqlConnection);
            cmd.Parameters.AddWithValue("salario", salario);

            MySqlDataReader sdr = cmd.ExecuteReader();

            List<Colaborador> listaDeColaboradores = new List<Colaborador>();

            while (sdr.Read())
            {
                Colaborador colaborador = new Colaborador();

                colaborador.Nome = sdr["nome"].ToString();
                colaborador.Salario = Convert.ToDouble(sdr["salario"].ToString());
                colaborador.Cargo = sdr["nome"].ToString();

                listaDeColaboradores.Add(colaborador);
            }

            return listaDeColaboradores;
        }

        public string InserirColaborador(InserirColaboradorDTO colaborador)
        {
            try
            {
                //abrindo conexao com banco
                MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

                //criando comando sql
                MySqlCommand cmd = new MySqlCommand("insert into rh.colaborador(cpf,nome,datanascimento,salario,dataadmissao,idCargo,idSquad) values(@cpf, @nome, @datanascimento,@salario,@dataadmissao,@idCargo,@idSquad);", sqlConnection);
                cmd.Parameters.AddWithValue("@cpf", colaborador.Cpf);
                cmd.Parameters.AddWithValue("@nome", colaborador.Nome);
                cmd.Parameters.AddWithValue("@datanascimento", colaborador.DataNascimento);
                cmd.Parameters.AddWithValue("@salario", colaborador.Salario);
                cmd.Parameters.AddWithValue("@dataadmissao", colaborador.DataAdmissao);
                cmd.Parameters.AddWithValue("@idCargo", colaborador.Cargo);
                cmd.Parameters.AddWithValue("@idSquad", colaborador.Squad);

                //executando comando sql no banco
                MySqlDataReader sdr = cmd.ExecuteReader();

                return "Colaborador inserido com sucesso";
            }
            catch (Exception excepetion)
            {

                return "Erro ao inserir o colaborador" + excepetion.ToString();
            }


        }

        public string AlterarSalarioColaborador(AlterarSalarioColaboradorDTO colaborador)
        {
            try
            {
                MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

                MySqlCommand cmd = new MySqlCommand(@"update rh.colaborador
                set salario = @salario
                where cpf = @cpf", sqlConnection);

                cmd.Parameters.AddWithValue("@cpf", colaborador.Cpf);
                cmd.Parameters.AddWithValue("@salario", colaborador.Salario);

                MySqlDataReader sdr = cmd.ExecuteReader();


                return "Alteração realizada com sucesso";

            }
            catch (Exception excepetion)
            {

                return "Erro ao realizar alteração" + excepetion.ToString();
            }
        }

        public string DeletarColaborador(string cpf)
        {
            try
            {
                MySqlConnection sqlConnection = _mySqlConnection.AbrirConexaoSQL();

                MySqlCommand cmd = new MySqlCommand(@"DELETE FROM rh.colaborador WHERE cpf = @cpf", sqlConnection);

                cmd.Parameters.AddWithValue("@cpf", cpf);

                MySqlDataReader sdr = cmd.ExecuteReader();

                return "Colaborador excluído com sucesso";

            }
            catch (Exception excepetion)
            {

                return "Erro ao realizar exclusão" + excepetion.ToString();
            }
        }

    }
}
