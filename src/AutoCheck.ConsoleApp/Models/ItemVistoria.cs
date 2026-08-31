using System.Collections.Generic;

namespace AutoCheck.ConsoleApp.Models;

public class Veiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public int Quilometragem { get; set; }
    public List<ItemVistoria> VistoriaRealizada { get; set; }
public Veiculo(string marca, string modelo, int ano, int quilometragem)
{
    this.Marca = marca;
    this.Modelo = modelo;
    this.Ano = ano;
    this.Quilometragem = quilometragem;
    this.VistoriaRealizada = new List<ItemVistoria>();
    }

}