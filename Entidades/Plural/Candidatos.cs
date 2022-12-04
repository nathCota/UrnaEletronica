using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Plural
{
    public class Candidatos
    {
        public List<Candidato> ListaCandidatos { get; set; }

        public Candidatos()
        {
            ListaCandidatos = new List<Candidato>();
        }

    }
}
