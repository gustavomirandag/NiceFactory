using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceShoes.Modelo
{
    public enum ETipo { SOCIAL, CASUAL, ESPORTIVO, INFANTIL }

    public abstract class Calcado
    {
        private string nome;
        private ETipo tipo;
        private int tamanho;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public ETipo Tipo
        {
            get { return tipo; }
            set { tipo = value;}
        }

        public int Tamanho
        {
            get { return tamanho; }
            set { tamanho = value;}
        }
    }
}
