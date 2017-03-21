using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceShoes.Modelo
{
    public class Tenis: Calcado
    {
        public Tenis(string nome, ETipo tipo, int tamanho)
        {
            Nome = nome;
            Tipo = tipo;
            Tamanho = tamanho;
        }
    }
}
