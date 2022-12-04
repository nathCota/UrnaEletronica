using ConsoleTables;
using Entidades;
using Entidades.Plural;
using Persistencias;
using Servicos.Interfaces;

namespace Servicos.Administracao
{
    public class PartidoServico : ICrud<Partidos, Partido>
    {
        public bool Adicionar(Partido obj)
        {
            try
            {
                Partidos? partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());

                if (partidos == null)
                {
                    partidos = new Partidos();
                }

                partidos.ListaPartidos.Add(obj);

                if (!ObjetoParaJson<Partidos>.Salvar(partidos))
                {
                    ObjetoParaJson<Partidos>.Editar(partidos);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Deletar(string? id)
        {
            try
            {
                var partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());
                var candidatos = JsonParaObjeto<Candidatos>.Recuperar(new Candidatos());

                if (partidos == null || partidos == default || partidos.ListaPartidos.Count == 0 || id == null || id == default)
                {
                    return false;
                }

                var filtro = partidos.ListaPartidos.Find(x => x.Id.ToString() == id);

                if (filtro == null || filtro == default)
                {
                    return false;
                }

                if (candidatos != null || candidatos != default)
                {
                    foreach (Partido partido in partidos.ListaPartidos)
                    {
                        var candidato = candidatos?.ListaCandidatos.Find(x => x.Partido.ToString() == id);
                        if (candidato != null || candidato != default)
                        {
                            candidatos?.ListaCandidatos.Remove(candidato);

                        }
                    }
                    ObjetoParaJson<Candidatos>.Editar(candidatos);
                }

                partidos.ListaPartidos.Remove(filtro);
                ObjetoParaJson<Partidos>.Editar(partidos);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Editar(Partido obj)
        {
            try
            {
                Partidos? partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());
                var partidoAnterior = partidos?.ListaPartidos.Find(x => x.Id == obj.Id);
                if (partidoAnterior == null || partidoAnterior == default)
                {
                    return false;
                }

                if (partidos == null)
                {
                    partidos = new Partidos();
                }

                partidos.ListaPartidos.Remove(partidoAnterior);
                partidos.ListaPartidos.Add(obj);
                return ObjetoParaJson<Partidos>.Editar(partidos);
            }
            catch
            {
                return false;
            }
        }

        public string? Listar()
        {
            try
            {
                var partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());

                if (partidos == null || partidos.ListaPartidos.Count == 0)
                {
                    return default;
                }

                ConsoleTable tabela = new ConsoleTable("Id", "Nome", "Sigla");
                foreach (Entidades.Partido partido in partidos.ListaPartidos)
                {
                    tabela.AddRow(partido.Id, partido.Nome, partido.Sigla);
                }

                return tabela.ToString();
            }
            catch
            {
                return default;
            }
        }

        public bool VerificaExisteId(string? id)
        {
            try
            {
                var partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());
                var result = partidos?.ListaPartidos.Find(x => x.Id.ToString() == id);
                return result == default || result == null ? false : true;

            }
            catch
            {
                return false;
            }
        }

        public bool VerificaExisteNome(string? nome)
        {
            try
            {
                var partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());
                var result = partidos?.ListaPartidos.Find(x => x.Nome == nome);
                return result == default || result == null ? false : true;

            }
            catch
            {
                return false;
            }
        }

        public bool VerificaExisteSigla(string? sigla)
        {
            try
            {
                var partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());
                var result = partidos?.ListaPartidos.Find(x => x.Sigla == sigla);
                return result == default || result == null ? false : true;
            }
            catch
            {
                return false;
            }
        }

    }
}
