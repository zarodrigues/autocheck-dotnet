namespace AutoCheck.ConsoleApp.Models;

public class ItemVistoria
{
    public string Nome { get; set; }
    public string Status { get; set; }

    public ItemVistoria(string nome, string status)
    {
        if (status != "Bom" && status != "Regular" && status != "Ruim")
        {
            throw new ArgumentException("Status deve ser Bom, Regular ou Ruim.");
        }

        this.Nome = nome;
        this.Status = status;
    }
}