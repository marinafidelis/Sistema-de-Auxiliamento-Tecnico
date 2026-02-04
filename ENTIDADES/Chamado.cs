using System.Collections.Generic;


public class Chamado
{
    //Atributos básicos
    public int Id {get; private set;}
    public string Titulo {get; private set;}
    public string Descricao { get; private set;}


 //enum
    public StatusChamado Status {get; private set;}
    public NivelChamado Nivel {get; private set;}


 //Relacionamento de outras classes
    public Cliente Cliente {get; private set;}
    public Tecnico? Tecnico {get; private set;}  //A propriedade não anulável 'Tecnico' precisa conter um valor não nulo

    public Categoria Categoria {get; private set;}


    //Histórico
    public List<HistoricoChamado> Historico {get; private set;}


    public Chamado(int id, string titulo, string descricao, Cliente cliente, Categoria categoria, NivelChamado nivel)
    {
     Id = id;
    Titulo = titulo;
    Descricao = descricao;
    Cliente = cliente;
    Categoria = categoria;
    Nivel = nivel;
    Status = StatusChamado.Aberto;
    Historico = new List<HistoricoChamado>();
    }


    public void AtribuirTecnico(Tecnico tecnico)
    {
        // Só atribui técnico se ainda não tiver um
        if(Tecnico == null)
        {
            Tecnico = tecnico;
            Status = StatusChamado.EmAndamento;
            Historico.Add(new HistoricoChamado("Técnico atribuído."));
        }
    }


    public void EncerrarChamado()
    {
        Status = StatusChamado.Encerrado;
        Historico.Add(new HistoricoChamado("Chamado encerrado."));
    }


 
}
