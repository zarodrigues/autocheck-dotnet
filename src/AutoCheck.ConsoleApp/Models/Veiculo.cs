namespace AutoCheck.ConsoleApp.Models;

public class NewBaseType
{
    public string Modelo { get; set; }
}

public class Veiculo : NewBaseType
{
    public string Marca { get; set; }
    public int Ano { get; set; }
public int Quilometragem { get; set; }
}