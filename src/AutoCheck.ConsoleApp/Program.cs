using AutoCheck.ConsoleApp.Models;
using AutoCheck.ConsoleApp.Services;

List<Veiculo> vistorias = new List<Veiculo>();

MotorVistoria motor = new MotorVistoria();

bool continuar = true;

while (continuar)
{
    Console.Clear();

    Console.WriteLine("===================================================================");
    Console.WriteLine("                 AUTOCHECK .NET - MOTOR DE VISTORIA");
    Console.WriteLine("===================================================================");
    Console.WriteLine();
    Console.WriteLine("1 - Realizar Nova Vistoria");
    Console.WriteLine("2 - Exibir Relatório das Vistorias");
    Console.WriteLine("0 - Sair");
    Console.WriteLine();

    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine() ?? "";

    if (opcao == "1")
    {
        RealizarNovaVistoria(vistorias);
    }
    else if (opcao == "2")
    {
        ExibirRelatorios(vistorias, motor);
    }
    else if (opcao == "0")
    {
        continuar = false;
        Console.WriteLine();
        Console.WriteLine("Sistema encerrado.");
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Opção inválida.");
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
    }
}

static void RealizarNovaVistoria(List<Veiculo> vistorias)
{
    Console.Clear();

    Console.WriteLine("===================================================================");
    Console.WriteLine("                     NOVA VISTORIA");
    Console.WriteLine("===================================================================");
    Console.WriteLine();

    Console.WriteLine("1 - Carro");
    Console.WriteLine("2 - Moto");
    Console.WriteLine("3 - Caminhão");
    Console.WriteLine();

    Console.Write("Escolha o tipo de veículo: ");
    string tipo = Console.ReadLine() ?? "";

    Console.Write("Marca: ");
    string marca = Console.ReadLine() ?? "";

    Console.Write("Modelo: ");
    string modelo = Console.ReadLine() ?? "";

    Console.Write("Ano: ");
    int ano = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Quilometragem: ");
    int quilometragem = int.Parse(Console.ReadLine() ?? "0");

    Veiculo veiculo;

    if (tipo == "1")
    {
        Console.Write("Quantidade de portas: ");
        int portas = int.Parse(Console.ReadLine() ?? "0");

        veiculo = new Carro(
            marca,
            modelo,
            ano,
            quilometragem,
            portas);
    }
    else if (tipo == "2")
    {
        Console.Write("Cilindradas: ");
        int cilindradas = int.Parse(Console.ReadLine() ?? "0");

        veiculo = new Moto(
            marca,
            modelo,
            ano,
            quilometragem,
            cilindradas);
    }
    else if (tipo == "3")
    {
        Console.Write("Quantidade de eixos: ");
        int eixos = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Capacidade de carga em toneladas: ");
        double capacidade = double.Parse(Console.ReadLine() ?? "0");

        veiculo = new Caminhao(
            marca,
            modelo,
            ano,
            quilometragem,
            eixos,
            capacidade);
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Tipo de veículo inválido.");
        Console.WriteLine("Pressione ENTER para voltar ao menu.");
        Console.ReadLine();
        return;
    }

    Console.WriteLine();
    Console.WriteLine("===================================================================");
    Console.WriteLine("                    CHECKLIST DE VISTORIA");
    Console.WriteLine("===================================================================");
    Console.WriteLine();

    List<string> checklist = veiculo.ObterChecklistObrigatorio();

    foreach (string item in checklist)
    {
        string status = "";

        while (status != "Bom" && status != "Regular" && status != "Ruim")
        {
            Console.Write($"{item} - Status (Bom/Regular/Ruim): ");
            status = Console.ReadLine() ?? "";

            if (status != "Bom" && status != "Regular" && status != "Ruim")
            {
                Console.WriteLine("Status inválido. Digite Bom, Regular ou Ruim.");
            }
        }

        veiculo.AdicionarItemVistoriado(item, status);
    }

    vistorias.Add(veiculo);

    Console.WriteLine();
    Console.WriteLine("Vistoria registrada com sucesso!");
    Console.WriteLine("Pressione ENTER para voltar ao menu.");
    Console.ReadLine();
}

static void ExibirRelatorios(List<Veiculo> vistorias, MotorVistoria motor)
{
    Console.Clear();

    if (vistorias.Count == 0)
    {
        Console.WriteLine("===================================================================");
        Console.WriteLine("                 RELATÓRIO DE VISTORIAS");
        Console.WriteLine("===================================================================");
        Console.WriteLine();
        Console.WriteLine("Nenhuma vistoria realizada até o momento.");
    }
    else
    {
        Console.WriteLine($"Total de vistorias realizadas: {vistorias.Count}");

        for (int i = 0; i < vistorias.Count; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"[{i + 1}/{vistorias.Count}] PROCESSANDO VISTORIA");

            motor.ExibirRelatorio(vistorias[i]);
        }
    }

    Console.WriteLine();
    Console.WriteLine("Pressione ENTER para voltar ao menu.");
    Console.ReadLine();
}