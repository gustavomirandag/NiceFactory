using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiceShoes.Modelo;

namespace NiceShoes
{
    class Program
    {
        private static List<Calcado> calcados = new List<Calcado>();

        static void Main(string[] args)
        {
            calcados.Add(new Sapato("Mr.Dog", 35));
            calcados.Add(new Sapato("Mr.Bird", 47));
            calcados.Add(new Sapato("iShoes", 43));

            calcados.Add(new Tenis("NiceShox", ETipo.ESPORTIVO, 35));
            calcados.Add(new Tenis("NiceAir", ETipo.ESPORTIVO, 43));
            calcados.Add(new Tenis("NiceNimbus", ETipo.ESPORTIVO, 32));
            calcados.Add(new Tenis("iRun", ETipo.ESPORTIVO, 44));
            calcados.Add(new Tenis("iCasual", ETipo.CASUAL, 34));

            Console.WriteLine("Lista de Sapatos:");
            foreach (var calcado in calcados)
                Console.WriteLine($"{calcado.Nome} - {calcado.Tamanho}");
            Console.WriteLine();

            //################  EXEMPLOS DE LINQ  ################

            //===== Encontrar um sapato de tamanho 35 ===== 
            //Forma 1
            Console.WriteLine("Sapatos com tamanho 35 (Forma1):");
            var saps35Forma1 = from c in calcados
                where c.Tamanho == 35
                select c.Nome;
            foreach (var sapato in saps35Forma1)
                Console.WriteLine(sapato);

            Console.WriteLine();

            //Forma 2
            Console.WriteLine("Sapatos com tamanho 35 (Forma2):");
            var saps35Forma2 = calcados
                    .Where(s => s.Tamanho == 35)
                    .Select(s => s.Nome);
            foreach (var sapato in saps35Forma2)
                Console.WriteLine(sapato);
            //==============================================

            Console.WriteLine();

            //==== Criar lista com Tamanhos Para Linha Infantil ====
            Random rand = new Random();
            var linhaInfantil = calcados.Select(s =>
                        new Tenis
                        (
                            s.Nome,
                            s.Tipo = ETipo.INFANTIL,
                            s.Tamanho = rand.Next(10, 30)
                        )
                );
            Console.WriteLine("Linha Infantil:");
            foreach (var sapato in linhaInfantil)
                Console.WriteLine($"{sapato.Nome} - {sapato.Tamanho}");
            //=================================================

            Console.ReadLine();
        }
    }
}
