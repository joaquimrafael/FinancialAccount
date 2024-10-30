using Bank;
using System;
using System.Collections.Generic;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var clients = new List<Client>
            {
                new PessoaFisica("João", 1),
                new PessoaJuridica("Empresa X", 2)
            };

            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("--- Conta Financeira ---");
                Console.Write("Digite seu código: ");
                if (!int.TryParse(Console.ReadLine(), out int codigo))
                {
                    Console.WriteLine("Código inválido. Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    continue;
                }

                Client client = clients.Find(c => c.Codigo == codigo);

                if (client == null)
                {
                    Console.WriteLine("Cliente inexistente.");
                    Console.WriteLine("Cadastre-se");
                    Console.Write("Digite seu nome: ");
                    string nomeClienteNovo = Console.ReadLine();

                    Console.Write("Digite seu código: ");
                    if (!int.TryParse(Console.ReadLine(), out int codigoClienteNovo))
                    {
                        Console.WriteLine("Código inválido. Cadastro cancelado. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("CPF ou CNPJ? ");
                    string tipoCliente = Console.ReadLine().Trim().ToUpper();

                    if (tipoCliente == "CPF")
                    {
                        client = new PessoaFisica(nomeClienteNovo, codigoClienteNovo);
                    }
                    else if (tipoCliente == "CNPJ")
                    {
                        client = new PessoaJuridica(nomeClienteNovo, codigoClienteNovo);
                    }
                    else
                    {
                        Console.WriteLine("Tipo de cliente inválido. Cadastro cancelado. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        continue;
                    }

                    clients.Add(client);
                    Console.WriteLine("Cadastro realizado com sucesso!");
                    Console.ReadKey();
                }

                bool sessionActive = true;

                while (sessionActive)
                {
                    Console.Clear();
                    Console.WriteLine($"Olá {client.Nome}, Código: {client.Codigo}");
                    Console.WriteLine($"Saldo Atual: R$ {client.Saldo:F2}");
                    Console.WriteLine("\nO que deseja fazer?");
                    Console.WriteLine("1 - Sacar");
                    Console.WriteLine("2 - Depositar");
                    Console.WriteLine("3 - Ver Movimentações");
                    Console.WriteLine("4 - Sair");

                    Console.Write("Escolha uma opção: ");
                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.Write("Digite o valor para sacar: R$ ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal valorSaque))
                            {
                                client.Sacar(valorSaque);
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido.");
                            }
                            PressionarTecla();
                            break;

                        case "2":
                            Console.Write("Digite o valor para depositar: R$ ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal valorDeposito))
                            {
                                client.Depositar(valorDeposito);
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido.");
                            }
                            PressionarTecla();
                            break;

                        case "3":
                            Console.WriteLine("\n--- Movimentações ---");
                            if (client.Movimentacoes.Count == 0)
                            {
                                Console.WriteLine("Nenhuma movimentação encontrada.");
                            }
                            else
                            {
                                foreach (var mov in client.Movimentacoes)
                                {
                                    Console.WriteLine(mov);
                                }
                            }
                            PressionarTecla();
                            break;

                        case "4":
                            sessionActive = false;
                            break;

                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            PressionarTecla();
                            break;
                    }
                }

                Console.WriteLine("Deseja encerrar o programa ou atender outro cliente?");
                Console.WriteLine("Digite 'sair' para encerrar ou qualquer outra tecla para continuar.");
                string acao = Console.ReadLine();
                if (acao.Trim().ToLower() == "sair")
                {
                    continuar = false;
                }
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços. Até logo!");
        }

        static void PressionarTecla()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
