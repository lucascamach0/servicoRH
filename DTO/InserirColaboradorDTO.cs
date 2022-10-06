namespace ServicoRH.DTO
{
    public class InserirColaboradorDTO
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Salario { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public int Cargo { get; set; }
        public int Squad { get; set; }
    }
}
