namespace ServicoRH.Domain
{
    public class Colaborador
    {
        public int IdColaborador { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Salario { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
    }
}
