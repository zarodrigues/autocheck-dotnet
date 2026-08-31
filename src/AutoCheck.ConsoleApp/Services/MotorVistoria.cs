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
            return "Aprovado com Excelencia";
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
        Console.WriteLine("> DADOS DO VEICULO:");
        Console.WriteLine($"  - Tipo: {veiculo.GetType().Name}");
        Console.WriteLine($"  - Marca: {veiculo.Marca}");
        Console.WriteLine($"  - Modelo: {veiculo.Modelo}");
        Console.WriteLine($"  - Ano: {veiculo.Ano}");
        Console.WriteLine($"  - Quilometragem: {veiculo.Quilometragem:N0} km");

        if (veiculo is Carro carro)
        {
            Console.WriteLine($"  - Atributo Especifico: {carro.QuantidadePortas} Portas");
        }
        else if (veiculo is Moto moto)
        {
            Console.WriteLine($"  - Atributo Especifico: {moto.Cilindradas} cilindradas");
        }
        else if (veiculo is Caminhao caminhao)
        {
            Console.WriteLine($"  - Atributo Especifico: {caminhao.QuantidadeEixos} Eixos | Cap. Carga: {caminhao.CapacidadeCargaToneladas:F1} toneladas");
        }

        Console.WriteLine();
        Console.WriteLine($"> AVALIACAO DOS ITENS INSPECIONADOS ({veiculo.VistoriaRealizada.Count} ITENS):");

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
        Console.WriteLine("> RESUMO DA PONTUACAO:");
        Console.WriteLine($"  - Pontuacao Atingida: {pontuacao} de {pontuacaoMaxima} pontos possiveis");
        Console.WriteLine($"  - Percentual de Aprovacao: {percentual:F1}%");
        Console.WriteLine($"  - Classificacao Final: [ {classificacao.ToUpper()} ]");

        ExibirPendencias(veiculo);
    }

    private void ExibirPendencias(Veiculo veiculo)
    {
        Console.WriteLine();
        Console.WriteLine("> RELATORIO DE MANUTENCAO E RECOMENDACOES DA OFICINA:");

        bool possuiPendencias = false;

        Console.WriteLine();
        Console.WriteLine("  ITENS CRITICOS / REPROVADOS:");

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Ruim")
            {
                string recomendacao = ObterRecomendacao(item.Nome);

                Console.WriteLine($"    - {item.Nome}: {recomendacao}");
                possuiPendencias = true;
            }
        }

        Console.WriteLine();
        Console.WriteLine("  ITENS DE ATENCAO:");

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Regular")
            {
                string recomendacao = ObterRecomendacao(item.Nome);

                Console.WriteLine($"    - {item.Nome}: {recomendacao}");
                possuiPendencias = true;
            }
        }

        Console.WriteLine();

        if (!possuiPendencias)
        {
            Console.WriteLine("  Nenhuma pendencia mecanica identificada.");
        }
        else
        {
            Console.WriteLine("  Recomendacoes: priorizar os itens criticos e realizar revisao dos itens de atencao.");
        }

        Console.WriteLine();
        Console.WriteLine("-------------------------------------------------------------------");
    }

    private string ObterRecomendacao(string nomeItem)
    {
        if (nomeItem == "Nivel de Oleo do Motor")
        {
            return "Verificar nivel e realizar troca do oleo e filtro, se necessario.";
        }
        else if (nomeItem == "Bateria e Sistema Eletrico")
        {
            return "Verificar bateria, cabos, alternador e sistema eletrico.";
        }
        else if (nomeItem == "Documentacao Regularizada")
        {
            return "Regularizar a documentacao do veiculo antes da liberacao.";
        }
        else if (nomeItem == "Estepe e Macaco")
        {
            return "Verificar o estepe e o funcionamento do macaco.";
        }
        else if (nomeItem == "Triangulo de Sinalizacao")
        {
            return "Repor ou substituir o equipamento obrigatorio.";
        }
        else if (nomeItem == "Ar Condicionado Funcional")
        {
            return "Realizar verificacao do sistema e do gas refrigerante.";
        }
        else if (nomeItem == "Kit Transmissao/Corrente")
        {
            return "Verificar corrente, coroa e pinhao e realizar substituicao se necessario.";
        }
        else if (nomeItem == "Manetes de Freio/Embreagem")
        {
            return "Verificar regulagem e funcionamento dos manetes.";
        }
        else if (nomeItem == "Pezinho Lateral")
        {
            return "Verificar fixacao e funcionamento do pezinho lateral.";
        }
        else if (nomeItem == "Tacografo")
        {
            return "Verificar funcionamento e afericao do tacografo.";
        }
        else if (nomeItem == "Sistema de Freios a Ar")
        {
            return "Realizar revisao completa do sistema de freios a ar.";
        }
        else if (nomeItem == "Trava e Lona da Cacamba")
        {
            return "Verificar travas, lona e sistema de fixacao da carga.";
        }
        else
        {
            return "Realizar revisao e reparo conforme a necessidade.";
        }
    }
}