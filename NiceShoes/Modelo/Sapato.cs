using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceShoes.Modelo
{
    public class Sapato: Calcado
    {
        public Sapato(string nome, int tamanho)
        {
            Nome = nome;
            Tipo = ETipo.SOCIAL;
            Tamanho = tamanho;
        }
    }
}
