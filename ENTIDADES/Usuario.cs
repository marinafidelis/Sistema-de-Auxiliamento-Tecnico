using System;

// ABSTRAÇÃO: não existe "Usuário" genérico, apenas Cliente ou Técnico.
public abstract class Usuario
{
     // ENCAPSULAMENTO: As propriedades têm 'protected set' para impedir alterações externas
    public string Nome { get; protected set; } 
    public string Email { get; protected set; }
    public int Id { get; protected set; }


private string Senha;

    // CONSTRUTOR: Garante que todo usuário seja criado com dados válidos desde o início.
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

    internal void AlterarSenhaInterna(string novaSenha) //O método é internal porque a regra de negócio está no UsuarioService, que pertence ao mesmo projeto, mas ainda assim o atributo Senha continua encapsulado.
{
    Senha = novaSenha;
}

    public abstract string ObterTipo(); // POLIMORFISMO: Método abstrato que obriga as classes filhas a informarem qual tipo de usuário elas representam.
   
}

//Aqui entra:
//SRP (Responsabilidade Única): Usuário só cuida de dados e comportamento comum.
//LSP (Liskov): Cliente e Técnico podem substituir Usuário sem quebrar o sistema.

