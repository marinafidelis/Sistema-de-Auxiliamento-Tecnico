using System;
using System.Collections.Generic;

// Classe principal do programa (camada de apresentação / console)
class Program
{
    // Lista que armazena todos os usuários cadastrados no sistema
    // Aqui ocorre POLIMORFISMO: a lista é de Usuario, mas pode guardar Cliente ou Tecnico
    static List<Usuario> usuarios = new List<Usuario>();

    // Lista que armazena todos os chamados abertos no sistema
    static List<Chamado> chamados = new List<Chamado>();


    // Ponto de entrada do programa
    static void Main()
    {
        // Responsável apenas por iniciar o fluxo do sistema
        MenuPrincipal();
    }

    // Menu inicial do sistema
    static void MenuPrincipal()
    {
        // Loop infinito para manter o sistema em execução
        while (true)
        {
            Console.WriteLine("1 - CADASTRAR   2 - LOGIN ");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? "";

            // Direciona o fluxo conforme a escolha do usuário
            if (opcao == "1")
            {
                Cadastrar(); // Responsável apenas pelo cadastro
            }
            else if (opcao == "2")
            {
                Login(); // Responsável apenas pelo login
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }

            Console.WriteLine(); // Linha em branco para melhorar a leitura no console
        }
    }

    // Função responsável SOMENTE pelo cadastro de usuários
    static void Cadastrar()
    {
        Console.WriteLine("=== CADASTRO DE USUÁRIO ===");

        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? ""; // uso de ??"" para garantir que nunca será null

        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";

        // Validação de senha (confirmação)
        string senha;
        while (true)
        {
            Console.Write("Senha: ");
            senha = Console.ReadLine() ?? "";

            Console.Write("Confirmar senha: ");
            string confirmar = Console.ReadLine() ?? "";

            // Garante que o usuário só avance se as senhas forem iguais
            if (senha != confirmar)
                Console.WriteLine("As senhas não batem!");
            else
                break;
        }

        // Escolha do tipo de usuário
        Console.WriteLine("Tipo de usuário: 1 - Cliente   2 - Técnico");
        Console.Write("Escolha: ");
        string tipo = Console.ReadLine() ?? "";

        if (tipo == "1")
        {
            Console.Write("Informe o setor do cliente: ");
            string setor = Console.ReadLine() ?? "";

            // Criação do objeto Cliente
            // usuarios.Count + 1 simula um ID incremental simples
            Cliente cliente = new Cliente(
                nome, email, usuarios.Count + 1, senha, setor
            );

            usuarios.Add(cliente); // Adicionado como Usuario (polimorfismo)
            Console.WriteLine("Cliente cadastrado com sucesso!");

            // Após cadastro, o cliente já é direcionado para sua área
            PaginaCliente(cliente);
        }
        else if (tipo == "2")
        {
            Console.Write("Informe a especialidade do técnico: ");
            string especialidade = Console.ReadLine() ?? "";

            // Criação do objeto Tecnico
            Tecnico tecnico = new Tecnico(
                nome, email, usuarios.Count + 1, senha, especialidade
            );

            usuarios.Add(tecnico); // Adicionado como Usuario (polimorfismo)
            Console.WriteLine("Técnico cadastrado com sucesso!");

            // Após cadastro, o técnico já é direcionado para sua área
            PaginaTecnico(tecnico);
        }
    }

    // Função responsável SOMENTE pelo login
    static void Login()
    {
        Console.WriteLine("=== LOGIN ===");

        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Senha: ");
        string senha = Console.ReadLine() ?? "";

        // Busca o usuário pelo email (sem diferenciar Cliente ou Técnico)
        Usuario? usuario = usuarios.Find(
            u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
        );

        // Caso o email não exista no sistema
        if (usuario == null)
        {
            Console.WriteLine("Email não cadastrado!");
            return;
        }

        // Validação da senha usando encapsulamento
        if (!usuario.ValidarSenha(senha))
        {
            Console.WriteLine("Senha incorreta!");
            return;
        }

        // POLIMORFISMO + LSP:
        // O sistema decide em tempo de execução se é Cliente ou Técnico
        if (usuario is Cliente cliente)
            PaginaCliente(cliente);
        else if (usuario is Tecnico tecnico)
            PaginaTecnico(tecnico);
    }

    // Página exclusiva do Cliente
    static void PaginaCliente(Cliente cliente)
    {
        Console.WriteLine("=== ÁREA DO CLIENTE ===");
        Console.WriteLine();

        Console.WriteLine("1 - Abrir chamado");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
        string opcao = Console.ReadLine() ?? "";

        if (opcao == "1")
        {
            Console.WriteLine();
            Console.WriteLine("=== FORMULÁRIO DE CHAMADO ===");

            // Exibição de dados do cliente (somente leitura)
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"Email: {cliente.Email}");
            Console.WriteLine($"Setor: {cliente.Setor}");

            Console.Write("Título do chamado: ");
            string titulo = Console.ReadLine() ?? "";

            Console.Write("Descreva o problema: ");
            string descricao = Console.ReadLine() ?? "";

            // Categoria criada de forma fixa (pode futuramente virar escolha do usuário)
            Categoria categoria = new Categoria(
                1,
                "Geral",
                "Chamados gerais"
            );

            // Nível padrão definido como baixo
            NivelChamado nivel = NivelChamado.Baixo;

            // Criação do chamado associando cliente, categoria e nível
            Chamado chamado = new Chamado(
                chamados.Count + 1,
                titulo,
                descricao,
                cliente,
                categoria,
                nivel
            );

            chamados.Add(chamado);

            Console.WriteLine();
            Console.WriteLine("Chamado aberto com sucesso!");
            Console.WriteLine($"Status do chamado: {chamado.Status}");
        }
    }

    // Página exclusiva do Técnico
    static void PaginaTecnico(Tecnico tecnico)
    {
        Console.WriteLine("=== ÁREA DO TÉCNICO ===");
        Console.WriteLine($"Nome: {tecnico.Nome}");
        Console.WriteLine($"Especialidade: {tecnico.Especialidade}");
        Console.WriteLine();

        // Caso não existam chamados abertos
        if (chamados.Count == 0)
        {
            Console.WriteLine("Nenhum chamado disponível no momento.");
            return;
        }

        // Simulação: pega o primeiro chamado aberto da lista
        Chamado chamado = chamados[0];

        Console.WriteLine("=== CHAMADO RECEBIDO ===");
        Console.WriteLine($"Cliente: {chamado.Cliente.Nome}");
        Console.WriteLine($"Setor: {chamado.Cliente.Setor}");
        Console.WriteLine($"Título: {chamado.Titulo}");
        Console.WriteLine($"Descrição: {chamado.Descricao}");
        Console.WriteLine($"Status atual: {chamado.Status}");
        Console.WriteLine();

        Console.WriteLine("1 - Atender chamado");
        Console.WriteLine("2 - Encerrar chamado");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
        string opcao = Console.ReadLine() ?? "";

        if (opcao == "1")
        {
            // Associa o técnico ao chamado e altera o status
            chamado.AtribuirTecnico(tecnico);
            Console.WriteLine("Chamado agora está em atendimento.");
            Console.WriteLine($"Status: {chamado.Status}");
        }
        else if (opcao == "2")
        {
            // Encerra o chamado
            chamado.EncerrarChamado();
            Console.WriteLine("Chamado encerrado com sucesso!");
            Console.WriteLine($"Status: {chamado.Status}");

            // Remove o chamado da lista após encerramento
            chamados.Remove(chamado);
        }
    }
}
