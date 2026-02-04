public class Categoria
{
    public int Id {get; private set;}
    public string Nome { get; private set;}
    public string Descricao {get; private set;}


    // Construtor obriga a criar a categoria com todos os dados válidos
    public Categoria(int id, string nome, string descricao)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
    }


}
