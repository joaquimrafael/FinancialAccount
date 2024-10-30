using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Client
    {
        public decimal Saldo { get; private set; }
        public string Nome { get; private set; }
        public int Codigo { get; private set; }
        public List<Movimentacao> Movimentacoes { get; set; }

        public Client()
        {
            Movimentacoes = new List<Movimentacao>();
        }

        public Client(string nome, int codigo) : this()
        {
            Nome = nome;
            Codigo = codigo;
        }

        public void Sacar(decimal valor)
        {
            if(Saldo > valor)
            {
                decimal valoratt = Taxar(valor);
                Saldo = Saldo - valor;
                AdicionarMov("SAQUE", valoratt);
                Console.WriteLine("Saque realizado com sucesso. Saldo: "+Saldo);
            }
            else
            {
                Console.WriteLine("Saldo insuficiente");
            }
        }

        public void Depositar(decimal valor)
        {
            if(valor >= 5)
            {
                decimal valoratt = Taxar(valor);
                Saldo += valoratt;
                AdicionarMov("DEPOSITO", valoratt);
                Console.WriteLine("Deposito realizado com sucesso. Saldo: " + Saldo);
            }
            else
            {
                Console.WriteLine("Apenas depositos maiores que R$5,00");
            }
        }

        public void AdicionarMov(string desc, decimal valor)
        {
            Movimentacoes.Add(new Movimentacao(desc, valor));
        }

        public virtual decimal Taxar(decimal valor)
        {
            return valor;
        }
    }
}
