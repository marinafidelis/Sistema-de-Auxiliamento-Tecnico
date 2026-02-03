
public class Cliente : Usuario
{
    public string Setor {get; protected set;}




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


