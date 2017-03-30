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
            calcados.Add(new Tenis("NiceShox", ETipo.ESPORTIVO, 43));
            calcados.Add(new Tenis("iRun", ETipo.ESPORTIVO, 44));
            calcados.Add(new Tenis("NiceShox", ETipo.ESPORTIVO, 26));
            calcados.Add(new Tenis("NiceShox", ETipo.CASUAL, 32));
            calcados.Add(new Tenis("iCasual", ETipo.CASUAL, 34));

            //Quais tamanhos disponíveis do tenis NiceShox?
            //Resposta em LINQ
            var niceShoxes = calcados
                .Where(s => s.Nome == "NiceShox" && s.Tipo == ETipo.CASUAL);

            foreach (var s in niceShoxes)
                Console.WriteLine(s.Tamanho);
            

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

            List<int> numeros = new List<int>() { 20, 15, 12, 30, 45, 100, 70 };
            var duplas = numeros.Select((valor, indice) => new { valor, indice });
            foreach (var dup in duplas)
                Console.WriteLine($"{dup.indice}: {dup.valor}");

            Console.WriteLine();


            Console.WriteLine();

            //==== Criar lista com Tamanhos Para Linha Infantil ====
            Random rand = new Random();
            var linhaInfantil = calcados.Select(s =>
                        new Tenis
                        (
                            s.Nome,
                            ETipo.INFANTIL,
                            rand.Next(10, 30)
                        )
                );
            Console.WriteLine("Linha Infantil:");
            foreach (var sapato in linhaInfantil)
                Console.WriteLine($"{sapato.Nome} - {sapato.Tamanho}");
            //=================================================

            Console.WriteLine();

            //==== Criar lista com Sapatos Sociais ====
            var linhaSocial = calcados.Where(s =>
                    s.Tipo == ETipo.SOCIAL
                );
            Console.WriteLine("Sapatos Sociais:");
            foreach (var sapato in linhaSocial)
                Console.WriteLine($"{sapato.Nome} - {sapato.Tamanho}");
            //=================================================

            Console.WriteLine();

            //==== Criar lista com Sapatos Esportivos ====
            var linhaEsportiva = calcados.Where(s =>
                    s.Tipo == ETipo.ESPORTIVO
                );
            Console.WriteLine("Sapatos Esportivos:");
            foreach (var sapato in linhaEsportiva)
                Console.WriteLine($"{sapato.Nome} - {sapato.Tamanho}");
            //=================================================

            Console.WriteLine();


            //==== Listar todos os calçados de todas as linhas disponíveis ====
            List<LinhaCalcados> linhasDeCalcados = new List<LinhaCalcados>();

            linhasDeCalcados.Add(new LinhaCalcados("Linha Infantil", linhaInfantil));
            linhasDeCalcados.Add(new LinhaCalcados("Linha Social", linhaSocial));
            linhasDeCalcados.Add(new LinhaCalcados("Linha Esportiva", linhaEsportiva));

            var linhasCalcados = linhasDeCalcados.Select(s => s.Calcados);

            Console.WriteLine("Calçados disponíveis na loja:");
            foreach(var linha in linhasCalcados)
            {
                foreach(var calcado in calcados)
                {
                    Console.WriteLine($"{calcado.Nome} - {calcado.Tamanho}");
                }
            }

            var listaDeNumeros = new List<int>() { 2, 4, 3, 8, 7, 5, 1, 6, 9 };

            listaDeNumeros.Count(x => x % 2 != 0);

            listaDeNumeros.Any(x => x > 8);

            //All
            listaDeNumeros.All(x => x < 10);

            List<int> multiplosDeTres = listaDeNumeros.Where(x => x % 3 == 0).ToList();

            int[] multiplosDeDois = listaDeNumeros.Where(x => x % 2 == 0).ToArray();

            int[] dezNumeros = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            multiplosDeDois.CopyTo(dezNumeros, 4);

            Console.WriteLine();

            var listaCalcados = linhasDeCalcados.SelectMany(s => s.Calcados);

            foreach (var calcado in listaCalcados)
            {
                Console.WriteLine($"{calcado.Nome} - {calcado.Tamanho}");
            }

            //=================================================================

            Console.ReadLine();
        }

        public class LinhaCalcados
        {
            private string nome;
            private IEnumerable<Calcado> calcados;

            public string Nome
            {
                get { return nome; }
                set { nome = value; }
            }

            public IEnumerable<Calcado> Calcados
            {
                get { return calcados; }
                set { calcados = value;}
            }

            public LinhaCalcados(string nome, IEnumerable<Calcado> calcados)
            {
                Nome = nome;
                Calcados = calcados;
            }
        }
    }
}
