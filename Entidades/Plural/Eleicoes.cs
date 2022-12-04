using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Plural
{
    public class Eleicoes
    {
        public List<Eleicao> ListaEleicoes { get; set; }

        public Eleicoes()
        {
            ListaEleicoes = new List<Eleicao>();
        }

    }
}
