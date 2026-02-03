public class Tecnico : Usuario
{
    public string Especialidade { get; protected set; }

    public Tecnico(string nome, string email, int id, string senha, string especialidade)
        : base(nome, email, id, senha)
    {
        Especialidade = especialidade;
    }

    public override string ObterTipo()
    {
        return "Técnico";
    }
}
