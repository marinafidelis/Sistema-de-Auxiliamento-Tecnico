using System;
using System.Collections.Generic;


class Program
{
    // Lista que armazena todos os usuários cadastrados no sistema (simula um banco de dados)
    static List<Usuario> usuarios = new List<Usuario>();

    // Lista que armazena todos os chamados abertos no sistema
    static List<Chamado> chamados = new List<Chamado>();

    // Método principal — ponto de entrada do programa
    static void Main()
    {
    
        MenuPrincipal();
    }

    // Menu principal que aparece ao iniciar o sistema
    static void MenuPrincipal()
    {
       
        while (true)
        {
            Console.WriteLine("=== SISTEMA DE SUPORTE ===");
            Console.WriteLine("1 - CADASTRAR   2 - LOGIN   0 - SAIR");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? "";

            // Direciona o fluxo conforme a opção escolhida
            if (opcao == "1")
                Cadastrar();
            else if (opcao == "2")
                Login();
            else if (opcao == "0")
                break; 
            else
                Console.WriteLine("Opção inválida!");

            Console.WriteLine();
        }
    }

    // Método responsável por cadastrar novos usuários
    static void Cadastrar()
    {
        Console.WriteLine("=== CADASTRO DE USUÁRIO ===");

        // Coleta nome e email
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";

        // Validação da senha
        string senha;
        while (true)
        {
            Console.Write("Senha: ");
            senha = Console.ReadLine() ?? "";

            Console.Write("Confirmar senha: ");
            string confirmar = Console.ReadLine() ?? "";

            if (senha != confirmar)
                Console.WriteLine("As senhas não batem!");
            else
                break;
        }

        // Escolha do tipo de usuário
        Console.WriteLine("Tipo de usuário: 1 - Cliente   2 - Técnico");
        Console.Write("Escolha: ");
        string tipo = Console.ReadLine() ?? "";

        // Cadastro de cliente
        if (tipo == "1")
        {
            Console.Write("Informe o setor do cliente: ");
            string setor = Console.ReadLine() ?? "";

            // Cria objeto Cliente
            Cliente cliente = new Cliente(nome, email, usuarios.Count + 1, senha, setor);

            usuarios.Add(cliente); // Adiciona na lista
            Console.WriteLine("Cliente cadastrado com sucesso!");
            PaginaCliente(cliente); // Entra na área do cliente
        }
        // Cadastro de técnico
        else if (tipo == "2")
        {
            Console.Write("Informe a especialidade do técnico: ");
            string especialidade = Console.ReadLine() ?? "";

            Tecnico tecnico = new Tecnico(nome, email, usuarios.Count + 1, senha, especialidade);

            usuarios.Add(tecnico);
            Console.WriteLine("Técnico cadastrado com sucesso!");
            PaginaTecnico(tecnico); // Entra na área do técnico
        }
    }

    // Método de login
    static void Login()
    {
        Console.WriteLine("=== LOGIN ===");

        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Senha: ");
        string senha = Console.ReadLine() ?? "";

        Usuario? usuario = usuarios.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        if (usuario == null)
        {
            Console.WriteLine("Email não cadastrado!");
            return;
        }

        // Valida senha usando método da classe Usuario
        if (!usuario.ValidarSenha(senha))
        {
            Console.WriteLine("Senha incorreta!");
            return;
        }

        // Redireciona conforme o tipo do usuário
        if (usuario is Cliente cliente)
            PaginaCliente(cliente);
        else if (usuario is Tecnico tecnico)
            PaginaTecnico(tecnico);
    }

    // Tela da área do cliente
    static void PaginaCliente(Cliente cliente)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== ÁREA DO CLIENTE ===");
            Console.WriteLine("1 - Abrir chamado");
            Console.WriteLine("2 - Ver chamados");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? "";

            if (opcao == "1")
                AbrirChamado(cliente);
            else if (opcao == "2")
                ListarChamadosCliente(cliente);
            else if (opcao == "0")
                break;
            else
                Console.WriteLine("Opção inválida!");
        }
    }

    // Abre um novo chamado
    static void AbrirChamado(Cliente cliente)
    {
        Console.WriteLine("\n=== FORMULÁRIO DE CHAMADO ===");

        // Mostra dados do cliente
        Console.WriteLine($"Nome: {cliente.Nome}");
        Console.WriteLine($"Email: {cliente.Email}");
        Console.WriteLine($"Setor: {cliente.Setor}");

        Console.Write("Título do chamado: ");
        string titulo = Console.ReadLine() ?? "";

        Console.Write("Descreva o problema: ");
        string descricao = Console.ReadLine() ?? "";

        // Escolha do nível de urgência
        Console.WriteLine("Escolha o nível do chamado: 1 - Baixo, 2 - Médio, 3 - Alto");
        string opcaoNivel = Console.ReadLine() ?? "";

        NivelChamado nivel = opcaoNivel == "2" ? NivelChamado.Medio :
                             opcaoNivel == "3" ? NivelChamado.Alto :
                             NivelChamado.Baixo;

        // Categoria padrão
        Categoria categoria = new Categoria(1, "Geral", "Chamados gerais");

        // Cria o chamado
        Chamado chamado = new Chamado(chamados.Count + 1, titulo, descricao, cliente, categoria, nivel);

        chamados.Add(chamado);

        Console.WriteLine($"Chamado aberto com sucesso! ID: {chamado.Id}");
        Console.WriteLine($"Status do chamado: {chamado.Status}");
    }

    // Lista chamados do cliente logado
    static void ListarChamadosCliente(Cliente cliente)
    {
        Console.WriteLine("\n=== SEUS CHAMADOS ===");

        bool temChamados = false;

        foreach (var chamado in chamados)
        {
            // Mostra apenas chamados do cliente atual
            if (chamado.Cliente.Id == cliente.Id)
            {
                temChamados = true;
                Console.WriteLine($"ID: {chamado.Id} | Título: {chamado.Titulo} | Status: {chamado.Status}");

                if (chamado.Tecnico != null)
                    Console.WriteLine($"Técnico responsável: {chamado.Tecnico.Nome}");
                else
                    Console.WriteLine("Técnico ainda não atribuído");

                Console.WriteLine("-----------------------------------");
            }
        }

        if (!temChamados)
            Console.WriteLine("Nenhum chamado encontrado.");
    }

    // Área do técnico
    static void PaginaTecnico(Tecnico tecnico)
    {
        while (true)
        {
            Console.WriteLine("\n=== ÁREA DO TÉCNICO ===");
            Console.WriteLine($"Nome: {tecnico.Nome}");
            Console.WriteLine($"Especialidade: {tecnico.Especialidade}");

            Console.WriteLine("1 - Ver próximos chamados");
            Console.WriteLine("0 - Sair");
            string opcao = Console.ReadLine() ?? "";

            if (opcao == "1")
            {
                // Procura o primeiro chamado não encerrado
                Chamado? chamado = chamados.Find(c => c.Status != StatusChamado.Encerrado);

                if (chamado == null)
                {
                    Console.WriteLine("Nenhum chamado disponível no momento.");
                    continue;
                }

                // Exibe dados do chamado
                Console.WriteLine($"ID: {chamado.Id}");
                Console.WriteLine($"Cliente: {chamado.Cliente.Nome}");
                Console.WriteLine($"Título: {chamado.Titulo}");

                Console.WriteLine("1 - Atender chamado");
                Console.WriteLine("2 - Encerrar chamado");
                string opcaoChamado = Console.ReadLine() ?? "";

                // Atribui técnico
                if (opcaoChamado == "1")
                    chamado.AtribuirTecnico(tecnico);

                // Encerra chamado
                else if (opcaoChamado == "2")
                    chamado.EncerrarChamado();
            }
            else if (opcao == "0")
                break;
        }
    }
}
