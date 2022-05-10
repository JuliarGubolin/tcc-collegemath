using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste1
{
    public class Calculadora_Científica : Calculadora
    {
        //Protected funciona nas classes filhas, mas não em outros arquivos
        public Calculadora_Científica()
        {
            Somar(20, 20);
        }

    }
}
