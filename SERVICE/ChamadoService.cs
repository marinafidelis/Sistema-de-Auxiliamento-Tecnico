// Biblioteca que permite trabalhar com listas genéricas (List<T>)
using System.Collections.Generic;


// Biblioteca que permite realizar consultas e filtros em coleções (LINQ)
using System.Linq;




// responsável pelas regras de negócio dos chamados
public class ChamadoService
{
    // Lista que armazena todos os chamados do sistema
    private List<Chamado> chamados;


    // Construtor inicializa a lista
    public ChamadoService()
    {
        chamados = new List<Chamado>();
    }


    // Abre (cadastra) um novo chamado
    public void AbrirChamado(Chamado chamado)
    {
        chamados.Add(chamado);
    }


    public void AtribuirTecnico(Chamado chamado, Tecnico tecnico)
    {
        chamado.AtribuirTecnico(tecnico);
    }


    public void EncerrarChamado(Chamado chamado)
    {
        chamado.EncerrarChamado();
    }


    // Lista chamados filtrando pelo status
    public List<Chamado> ListarPorStatus(StatusChamado status)
    {
        return chamados
            .Where(c => c.Status == status).ToList();
    }


    // Lista chamados filtrando pelo técnico
    public List<Chamado> ListarPorTecnico(Tecnico tecnico)
    {
        return chamados
            .Where(c => c.Tecnico == tecnico).ToList();
    }
}
