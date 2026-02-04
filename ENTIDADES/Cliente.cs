
// HERANÇA: herda todos os atributos e comportamentos comuns definidos na classe abstrata Usuario.
public class Cliente : Usuario
{
    public string Setor {get; protected set;}



// CONSTRUTOR: O construtor do Cliente chama o construtor da classe base (Usuario), garantindo que os dados comuns sejam inicializados corretamente.
    public Cliente(string nome, string email, int id, string senha, string setor)
    : base(nome,email,id,senha)
    {
        Setor = setor;
    }


    // O Cliente informa ao sistema que seu tipo é "Cliente". (polimorfismo)
    public override string ObterTipo()
    {
        return "Cliente";
    }
}

//FOI USADO:
//L — Liskov Substitution Principle: Cliente pode substituir Usuario sem quebrar o sistema.
//S — Single Responsibility: Cliente só tem responsabilidades de cliente (ex: setor).