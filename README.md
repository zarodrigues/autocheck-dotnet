# AutoCheck .NET - Motor de Vistoria Veicular

## Sobre o projeto

O AutoCheck .NET é uma aplicação de console desenvolvida em C# com .NET para simular um sistema de vistoria veicular.

O sistema permite realizar vistorias em diferentes tipos de veículos: Carro, Moto e Caminhão.

Durante a vistoria, cada item do checklist recebe um dos seguintes status:

* Bom
* Regular
* Ruim

Com base nos resultados, o sistema calcula a pontuação, o percentual de aprovação e classifica a situação final do veículo.

## Funcionalidades

O sistema possui um menu principal com três opções:

1. Realizar Nova Vistoria
2. Exibir Relatório das Vistorias
3. Sair

Na realização da vistoria, o usuário informa os dados do veículo e avalia os itens do checklist.

O sistema também permite consultar o relatório das vistorias realizadas, mostrando a pontuação, percentual, classificação e pendências encontradas.

## Tipos de veículos

### Carro

Atributo específico:

* Quantidade de portas

Itens específicos do checklist:

* Estepe e Macaco
* Triângulo de Sinalização
* Ar Condicionado Funcional

### Moto

Atributo específico:

* Cilindradas

Itens específicos do checklist:

* Kit Transmissão/Corrente
* Manetes de Freio/Embreagem
* Pezinho Lateral

### Caminhão

Atributos específicos:

* Quantidade de eixos
* Capacidade de carga em toneladas

Itens específicos do checklist:

* Tacógrafo
* Sistema de Freios a Ar
* Trava e Lona da Caçamba

## Regra de pontuação

Cada item recebe uma pontuação de acordo com o seu status:

* Bom: 10 pontos
* Regular: 5 pontos
* Ruim: 0 pontos

A pontuação máxima é calculada multiplicando a quantidade de itens avaliados por 10.

O percentual de aprovação é calculado dividindo a pontuação obtida pela pontuação máxima possível e multiplicando o resultado por 100.

## Classificação do veículo

O resultado da vistoria é classificado da seguinte forma:

* 90% a 100%: Aprovado com Excelência
* 60% a 89%: Aprovado com Apontamentos
* 0% a 59%: Reprovado na Vistoria

O sistema também apresenta os itens classificados como Regular e Ruim para indicar possíveis necessidades de manutenção.

## Estrutura do projeto

```text
autocheck-dotnet/
|
+-- src/
|   |
|   +-- AutoCheck.ConsoleApp/
|       |
|       +-- Program.cs
|       |
|       +-- Models/
|       |   +-- ItemVistoria.cs
|       |   +-- Veiculo.cs
|       |   +-- Carro.cs
|       |   +-- Moto.cs
|       |   +-- Caminhao.cs
|       |
|       +-- Services/
|           +-- MotorVistoria.cs
|
+-- README.md
```

## Conceitos de C# e POO utilizados

O projeto utiliza conceitos estudados no Módulo 01:

* Tipos primitivos
* Classes e objetos
* Propriedades
* Construtores
* Encapsulamento
* Listas com List<T>
* Estruturas condicionais if/else
* Estruturas de repetição foreach
* Herança
* Polimorfismo
* Métodos virtual e override
* Uso da palavra-chave this
* Console.ReadLine()
* Console.WriteLine()

A classe Veiculo funciona como classe base para Carro, Moto e Caminhao.

Cada tipo de veículo possui características próprias e sobrescreve o método ObterChecklistObrigatorio(), permitindo a utilização do polimorfismo.

## Como executar o projeto

### Pré-requisitos

É necessário possuir o .NET SDK instalado no computador.

### Executar pelo terminal

Primeiro, clone o repositório:

```text
git clone URL_DO_REPOSITORIO
```

Entre na pasta do projeto:

```text
cd autocheck-dotnet/src/AutoCheck.ConsoleApp
```

Execute a aplicação:

```text
dotnet run
```

Para verificar se o projeto compila corretamente:

```text
dotnet build
```

## Exemplo de funcionamento

Ao iniciar o programa, o sistema apresenta o menu principal:

```text
===================================================================
                 AUTOCHECK .NET - MOTOR DE VISTORIA
===================================================================

1 - Realizar Nova Vistoria
2 - Exibir Relatório das Vistorias
0 - Sair

Escolha uma opção:
```

Após a realização da vistoria, o sistema apresenta os dados do veículo, os itens avaliados, a pontuação, o percentual de aprovação, a classificação final e as possíveis pendências.

## Versionamento

O projeto foi desenvolvido utilizando Git e GitHub para controle de versão.

Durante o desenvolvimento foram realizados commits para registrar as principais etapas da construção da aplicação.

## Vídeo de apresentação

O link do vídeo de apresentação será adicionado após a gravação.

## Autor

Projeto desenvolvido como parte do Mini-Projeto Avaliativo do curso de Desenvolvedor Back-End .NET - Módulo 01.
