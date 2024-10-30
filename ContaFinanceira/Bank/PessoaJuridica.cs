using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace Bank
{
    public class PessoaJuridica : Client
    {
        public PessoaJuridica(string name, int codigo) : base()
        {

        }
        public override decimal Taxar(decimal valor)
        {
            return valor-2;   
        }
    }
}
