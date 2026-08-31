using AutoCheck.ConsoleApp.Models;

Veiculo veiculo = new Veiculo();

veiculo.Marca = "Toyota";
veiculo.Modelo = "Corolla";
veiculo.Ano = 2020;
veiculo.Quilometragem = 50000;

Console.WriteLine($"Marca: {veiculo.Marca}");
Console.WriteLine($"Modelo: {veiculo.Modelo}");
Console.WriteLine($"Ano: {veiculo.Ano}");
Console.WriteLine($"Quilometragem: {veiculo.Quilometragem}");