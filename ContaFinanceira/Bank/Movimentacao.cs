using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Movimentacao
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public Movimentacao() { }

        public Movimentacao(string descricao, decimal valor) : this()
        {
            this.Descricao = descricao;
            this.Valor = valor;
        }

        public override string ToString()
        {
            return $"Mov:{Descricao}, Valor:{Valor}";
        }
    }
}