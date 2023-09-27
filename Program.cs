using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> opcoesVotacao = new Dictionary<string, int>();
    static bool candidatosRegistrados = false;
    static bool votosRegistrados = false;
    static bool votacaoEncerrada = false; 
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Bem-vindo ao Sistema de Votação");

        while (!votacaoEncerrada) 
        {
            Console.WriteLine("\nOpções:");
            Console.WriteLine("1. Registrar Candidatos");
            Console.WriteLine("2. Votar");
            Console.WriteLine("3. Exibir Resultados");
            Console.WriteLine("4. Encerrar Votação");
            Console.WriteLine("5. Sair");

            Console.Write("Escolha uma opção: ");
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    CadastrarOpcaoVotacao();
                    break;
                case 2:
                    if (candidatosRegistrados && !votacaoEncerrada) 
                    {
                        Votar();
                        votosRegistrados = true;
                    }
                    else if (votacaoEncerrada)
                    {
                        Console.WriteLine("A votação já foi encerrada.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum candidato registrado. Registre candidatos primeiro.");
                    }
                    break;
                case 3:
                    if (votosRegistrados)
                    {
                        ExibirResultados();
                    }
                    else if (votacaoEncerrada)
                    {
                        Console.WriteLine("A votação já foi encerrada.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum candidato escolhido. Por favor, vote antes de exibir resultados.");
                    }
                    break;
                case 4:
                    if (votosRegistrados && !votacaoEncerrada) 
                    {
                        EncerrarVotacao();
                        CalcularVencedor();
                        votacaoEncerrada = true; 
                    }
                    else if (votacaoEncerrada)
                    {
                        Console.WriteLine("A votação já foi encerrada.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum voto registrado. É necessário pelo menos um voto para encerrar a votação.");
                    }
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarOpcaoVotacao()
    {
        Console.Write("Digite o nome da opção de votação: ");
        string opcao = Console.ReadLine();

        if (!opcoesVotacao.ContainsKey(opcao))
        {
            opcoesVotacao[opcao] = 0;
            Console.WriteLine("Opção cadastrada com sucesso!");
            candidatosRegistrados = true;
        }
        else
        {
            Console.WriteLine("Esta opção já existe.");
        }
    }

    static void Votar()
    {
        Console.WriteLine("\nOpções de Votação:");
        foreach (var opcao in opcoesVotacao.Keys)
        {
            Console.WriteLine(opcao);
        }

        Console.Write("Digite o nome da opção em que deseja votar: ");
        string opcaoVoto = Console.ReadLine();

        if (opcoesVotacao.ContainsKey(opcaoVoto))
        {
            opcoesVotacao[opcaoVoto]++;
            Console.WriteLine("Voto registrado com sucesso!");
        }
        else
        {
            Console.WriteLine("Opção de votação inválida.");
        }
    }

    static void ExibirResultados()
    {
        Console.WriteLine("\nResultados da Votação:");
        foreach (var opcao in opcoesVotacao)
        {
            Console.WriteLine($"{opcao.Key}: {opcao.Value} votos");
        }
    }

    static void EncerrarVotacao()
    {
        Console.WriteLine("Votação encerrada.");
    }

    static void CalcularVencedor()
    {
        string vencedor = "";
        int maiorNumeroVotos = -1;

        foreach (var opcao in opcoesVotacao)
        {
            if (opcao.Value > maiorNumeroVotos)
            {
                vencedor = opcao.Key;
                maiorNumeroVotos = opcao.Value;
            }
        }

        Console.WriteLine($"O vencedor da votação é: {vencedor} com {maiorNumeroVotos} votos!");
    }
}

