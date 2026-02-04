using System;


public class HistoricoChamado
{
    public DateTime Data {get; private set;}
    public string Descricao { get; private set;}


    // Sempre que criar um chamado mostrará a data e a hora atual

public HistoricoChamado(string descricao)
    {
        Data = DateTime.Now;
        Descricao = descricao;
    }
}