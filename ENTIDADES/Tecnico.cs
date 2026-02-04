//HERANÇA: Tecnico é um tipo específico de Usuario.
public class Tecnico : Usuario
{
    public string Especialidade { get; protected set; } // ENCAPSULAMENTO: Especialidade é uma característica exclusiva do Técnico.

 // CONSTRUTOR: Inicializa tanto os atributos herdados, quanto os atributos específicos do Técnico.
    public Tecnico(string nome, string email, int id, string senha, string especialidade)
        : base(nome, email, id, senha)
    {
        Especialidade = especialidade;  
    }
 // POLIMORFISMO: Sobrescreve o método abstrato definido em Usuario. permitindo que o sistema identifique dinamicamente o tipo do usuário.
    public override string ObterTipo()
    {
        return "Técnico";
    }
}
