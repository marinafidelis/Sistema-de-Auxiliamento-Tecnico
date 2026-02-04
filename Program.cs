class Program
{
    static void Main(string[] args)
    {
         // CADASTRO DOS USUÁRIOS: aqui criamos objetos concretos (Cliente e Tecnico)
        Cliente cliente = new Cliente(
           nome: "Davilla",
           email: "davillavictoria@gmail.com",
           id: 1,
           senha: "senha123",
           setor: "Financeiro"
        );

        Tecnico tecnico = new Tecnico(
            nome: "Kaio",
            email: "kaio@gmail.com",
            id: 2,
            senha: "tec456",
            especialidade: "Redes"
        );

        //CRIAÇÃO DA CATEGORIA
        Categoria categoria = new Categoria(
           id: 1,
           nome: "Suporte Técnico",
           descricao: "Problemas relacionados a hardware e software"
        );

       //CLIENTE ABRE UM CHAMADO
        Chamado chamado = new Chamado(
        id: 100,
        titulo: "Computador não liga",
        descricao: "O computador não liga ao apertar o botão",
        cliente: cliente,
        categoria: categoria,
        nivel: NivelChamado.Alto
    );
        // TÉCNICO É ATRIBUÍDO AO CHAMADO
        ChamadoService service = new ChamadoService();

        // Regra de negócio sendo aplicada pelo Service
        chamadoService.AbrirChamado(chamado);
        chamadoService.AtribuirTecnico(chamado, tecnico);

        Console.WriteLine("Técnico atribuído ao chamado.");
        Console.WriteLine($"Status atual: {chamado.Status}");

        //CHAMADO É ENCERRADO
        chamadoService.EncerrarChamado(chamado);

        Console.WriteLine("Chamado encerrado.");
        Console.WriteLine($"Status final: {chamado.Status}");

        // EXIBIR HISTÓRICO DO CHAMADO
         Console.WriteLine("\nHistórico do chamado:");
        foreach (var h in chamado.Historico)
        {
            Console.WriteLine($"{h.Data} - {h.Descricao}");
        }

    }
}