using System;
using System.Collections.Generic;
using System.Linq;

namespace teste1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Float:precisão
            //Decimal: valores monetários
            //long cpf = 23213131;
            //Alt + Enter para importar bibliotecas
            List<int> numeros_inteiros = new List<int>();
            int soma = numeros_inteiros.Sum();
            List<string> nomes = new List<string>();

            var nome = "";
            var lista = new List<double>();

            Console.WriteLine("Digite seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine($"Você é {nome}");

            Calculadora calculadora = new Calculadora();
            int resultado = calculadora.Somar(10, 10);

        }
    }
}
