public class UsuarioService
{
    private bool SenhaValida(string senha)
    {
        if (senha.Length < 6)
            return false;

        foreach (char c in senha)
        {
            if (char.IsDigit(c))
                return true;
        }
        return false;
    }

    public bool AlterarSenha(Usuario usuario, string senhaAtual, string novaSenha)
    {
        if (usuario.ValidarSenha(senhaAtual) && SenhaValida(novaSenha))
        {
            usuario.AlterarSenhaInterna(novaSenha);
            return true;
        }
        return false;
    }

    public bool EsqueciSenha(Usuario usuario, string email, string novaSenha)
    {
        if (usuario.Email == email && SenhaValida(novaSenha))
        {
            usuario.AlterarSenhaInterna(novaSenha);
            return true;
        }
        return false;
    }
}