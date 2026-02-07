using System.Collections.Generic;

// Classe que representa um chamado no sistema
public class Chamado
{
    // Atributos básicos do chamado
    public int Id { get; private set; }           
    public string Titulo { get; private set; }    
    public string Descricao { get; private set; } 

    // Enumerações
    public StatusChamado Status { get; private set; } // Status atual do chamado 
    public NivelChamado Nivel { get; private set; }   // Nível de prioridade do chamado (Baixo, Médio, Alto)

    // Relacionamento com outras classes (associação)
    public Cliente Cliente { get; private set; }       // Cliente que abriu o chamado
    public Tecnico? Tecnico { get; private set; }      // Técnico responsável, opcional inicialmente (null)
    public Categoria Categoria { get; private set; }  

    public List<HistoricoChamado> Historico { get; private set; }

    // Construtor da classe Chamado
    public Chamado(int id, string titulo, string descricao, Cliente cliente, Categoria categoria, NivelChamado nivel)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Cliente = cliente;
        Categoria = categoria;
        Nivel = nivel;

        Status = StatusChamado.Aberto; // Status inicial sempre aberto
        Historico = new List<HistoricoChamado>(); // Lista vazia de histórico
    }

    // Método para atribuir um técnico ao chamado
    public void AtribuirTecnico(Tecnico tecnico)
    {
        // Só atribui técnico se ainda não tiver um
        if (Tecnico == null)
        {
            Tecnico = tecnico;                  
            Status = StatusChamado.EmAndamento;  // Atualiza status para EmAndamento
            Historico.Add(new HistoricoChamado("Técnico atribuído.")); // Registra ação no histórico
        }
    }

    public void EncerrarChamado()
    {
        Status = StatusChamado.Encerrado;            // Atualiza status para Encerrado
        Historico.Add(new HistoricoChamado("Chamado encerrado.")); // Registra ação no histórico
    }
}
