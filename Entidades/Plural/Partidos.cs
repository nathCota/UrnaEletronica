using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Plural
{
    public class Partidos
    {
        public List<Partido> ListaPartidos { get; set; }

        public Partidos()
        {
            ListaPartidos = new List<Partido>();
        }

    }
}
