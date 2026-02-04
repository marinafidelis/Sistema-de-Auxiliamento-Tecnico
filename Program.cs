class Program
{
    static void Main(string[] args)
    {
        Cliente cliente = new Cliente(
            "Davilla",
            "davillavictoria4@gmail.com",
            1,
            "123456",
            "RH"
        );

        Tecnico tecnico = new Tecnico(
            "Caio",
            "caiosilva@gmail.com",
            2,
            "654321",
            "Suporte"
        );

        Categoria categoria = new Categoria(
            1,
            "Hardware",
            "Problemas físicos no computador"
        );

        Chamado chamado = new Chamado(
        1,
        "PC não liga",
        "O computador não dá sinal",
        cliente,
        categoria,
        NivelChamado.Alto
    );

        ChamadoService service = new ChamadoService();

        service.AbrirChamado(chamado);
        service.AtribuirTecnico(chamado, tecnico);
        service.EncerrarChamado(chamado);

        Console.WriteLine("Chamado encerrado!");
        Console.WriteLine("Status: " + chamado.Status);


    }
}