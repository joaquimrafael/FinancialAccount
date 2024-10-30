using Bank;
using System;
using System.Collections.Generic;

var clients = new List<Client>
{
    new PessoaFisica("João", 1),
    new PessoaJuridica("Empresa X", 2)
};

bool continuar = true;

while (continuar)
{
    Console.WriteLine("---Conta Financeira---");
    Console.WriteLine("Digite seu código: ");
    int codigo = int.Parse(Console.ReadLine());
    Client client = null;

    foreach (var c in clients)
    {
        if (c.Codigo == codigo)
        {
            client = c;
            break;
        }
    }

    if (client == null)
    {
        Console.WriteLine("Cliente inexistente");
        Console.WriteLine("Cadastre-se");
        Console.WriteLine("\nDigite seu nome: ");
        string nomeClienteNovo = Console.ReadLine();
        Console.WriteLine("Digite seu código: ");
        int codigoClienteNovo = int.Parse(Console.ReadLine());
        Console.WriteLine("CPF ou CNPJ?");
        string tipoCliente = Console.ReadLine();

        if (tipoCliente.ToUpper() == "CPF")
        {
            client = new PessoaFisica(nomeClienteNovo, codigoClienteNovo);
        }
        else
        {
            client = new PessoaJuridica(nomeClienteNovo, codigoClienteNovo);
        }

        clients.Add(client);
    }

    Console.WriteLine($"Olá {client.Nome}, código: {client.Codigo}");
    Console.WriteLine("O que deseja fazer hoje: ");
    // Adicione aqui as opções de ações que o cliente pode realizar
    Console.WriteLine("Digite 'sair' para encerrar ou 'continuar' para outro cliente.");
    string acao = Console.ReadLine();
    if (acao.ToLower() == "sair")
    {
        continuar = false;
    }
}
