using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Interfaces
{
    internal interface ICrud<P, S>// P = Plural , S = Singular
    {
        public string? Listar();
        public bool Adicionar(S obj);
        public bool Editar(S obj);
        public bool Deletar(string? id);

    }
}
