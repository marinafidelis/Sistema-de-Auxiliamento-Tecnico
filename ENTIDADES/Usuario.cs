using System;

public abstract class Usuario
{
    public string Nome { get; protected set; }
    public string Email { get; protected set; }
    public int Id { get; protected set; }


private string Senha;


    protected Usuario(string nome, string email, int id, string senha)
    {
        Nome = nome;
        Email = email;
        Id = id;
        Senha = senha;
    }


    public bool ValidarSenha(string senha)
    {
        return Senha == senha;
    }

    internal void AlterarSenhaInterna(string novaSenha)
{
    Senha = novaSenha;
}

    public abstract string ObterTipo();


   
}

