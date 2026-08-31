using AutoCheck.ConsoleApp.Models;

namespace AutoCheck.ConsoleApp.Services;

public class MotorVistoria
{
    public int CalcularPontuacao(Veiculo veiculo)
    {
        int pontuacao = 0;

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Bom")
            {
                pontuacao += 10;
            }
            else if (item.Status == "Regular")
            {
                pontuacao += 5;
            }
            else if (item.Status == "Ruim")
            {
                pontuacao += 0;
            }
        }

        return pontuacao;
    }

    public double CalcularPercentual(Veiculo veiculo)
    {
        int pontuacaoObtida = CalcularPontuacao(veiculo);
        int pontuacaoMaxima = veiculo.VistoriaRealizada.Count * 10;

        if (pontuacaoMaxima == 0)
        {
            return 0;
        }

        double percentual = ((double)pontuacaoObtida / pontuacaoMaxima) * 100;

        return percentual;
    }

    public string ClassificarVeiculo(double percentual)
    {
        if (percentual >= 90)
        {
            return "Aprovado com Excelência";
        }
        else if (percentual >= 60)
        {
            return "Aprovado com Apontamentos";
        }
        else
        {
            return "Reprovado na Vistoria";
        }
    }

    public void ExibirRelatorio(Veiculo veiculo)
    {
        int pontuacao = CalcularPontuacao(veiculo);
        int pontuacaoMaxima = veiculo.VistoriaRealizada.Count * 10;
        double percentual = CalcularPercentual(veiculo);
        string classificacao = ClassificarVeiculo(percentual);

        Console.WriteLine();
        Console.WriteLine("===================================================================");
        Console.WriteLine("                 AUTOCHECK .NET - MOTOR DE VISTORIA");
        Console.WriteLine("===================================================================");

        Console.WriteLine();
        Console.WriteLine("> DADOS DO VEÍCULO:");
        Console.WriteLine($"  - Tipo: {veiculo.GetType().Name}");
        Console.WriteLine($"  - Marca: {veiculo.Marca}");
        Console.WriteLine($"  - Modelo: {veiculo.Modelo}");
        Console.WriteLine($"  - Ano: {veiculo.Ano}");
        Console.WriteLine($"  - Quilometragem: {veiculo.Quilometragem:N0} km");

        if (veiculo is Carro carro)
        {
            Console.WriteLine($"  - Atributo Específico: {carro.QuantidadePortas} Portas");
        }
        else if (veiculo is Moto moto)
        {
            Console.WriteLine($"  - Atributo Específico: {moto.Cilindradas} cilindradas");
        }
        else if (veiculo is Caminhao caminhao)
        {
            Console.WriteLine($"  - Atributo Específico: {caminhao.QuantidadeEixos} Eixos | Cap. Carga: {caminhao.CapacidadeCargaToneladas:F1} toneladas");
        }

        Console.WriteLine();
        Console.WriteLine($"> AVALIAÇÃO DOS ITENS INSPECIONADOS ({veiculo.VistoriaRealizada.Count} ITENS):");

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            int pontos = 0;
            string simbolo = "[ ]";

            if (item.Status == "Bom")
            {
                pontos = 10;
                simbolo = "[OK]";
            }
            else if (item.Status == "Regular")
            {
                pontos = 5;
                simbolo = "[ ! ]";
            }
            else if (item.Status == "Ruim")
            {
                pontos = 0;
                simbolo = "[ X ]";
            }

            Console.WriteLine($"  {simbolo} {item.Nome} -------- Status: {item.Status} ({pontos} pts)");
        }

        Console.WriteLine();
        Console.WriteLine("> RESUMO DA PONTUAÇÃO:");
        Console.WriteLine($"  - Pontuação Atingida: {pontuacao} de {pontuacaoMaxima} pontos possíveis");
        Console.WriteLine($"  - Percentual de Aprovação: {percentual:F1}%");
        Console.WriteLine($"  - Classificação Final: [ {classificacao.ToUpper()} ]");

        ExibirPendencias(veiculo);
    }

    private void ExibirPendencias(Veiculo veiculo)
    {
        Console.WriteLine();
        Console.WriteLine("> RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:");

        bool possuiPendencias = false;

        Console.WriteLine();
        Console.WriteLine("  ITENS CRÍTICOS / REPROVADOS:");

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Ruim")
            {
                Console.WriteLine($"    - {item.Nome}: Reparo ou substituição obrigatória.");
                possuiPendencias = true;
            }
        }

        Console.WriteLine();
        Console.WriteLine("  ITENS DE ATENÇÃO:");

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Regular")
            {
                Console.WriteLine($"    - {item.Nome}: Realizar revisão preventiva.");
                possuiPendencias = true;
            }
        }

        Console.WriteLine();

        if (!possuiPendencias)
        {
            Console.WriteLine("  Nenhuma pendência mecânica identificada.");
        }
        else
        {
            Console.WriteLine("  Recomendações: priorizar os itens críticos e realizar revisão dos itens de atenção.");
        }

        Console.WriteLine();
        Console.WriteLine("-------------------------------------------------------------------");
    }
}