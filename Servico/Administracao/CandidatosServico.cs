using ConsoleTables;
using Entidades;
using Entidades.Plural;
using Persistencias;
using Servicos.Interfaces;

namespace Servicos.Administracao
{
    public class CandidatosServico : ICrud<Candidatos, Candidato>
    {
        public bool Adicionar(Candidato obj)
        {
            try
            {
                Candidatos? candidatos = JsonParaObjeto<Candidatos>.Recuperar(new Candidatos());

                if (candidatos == null)
                {
                    candidatos = new Candidatos();
                }

                candidatos.ListaCandidatos.Add(obj);

                if (!ObjetoParaJson<Candidatos>.Salvar(candidatos))
                {
                    ObjetoParaJson<Candidatos>.Editar(candidatos);
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
                var candidatos = JsonParaObjeto<Candidatos>.Recuperar(new Candidatos());

                if (candidatos == null || candidatos == default || candidatos.ListaCandidatos.Count == 0 || id == null || id == default)
                {
                    return false;
                }

                var filtro = candidatos.ListaCandidatos.Find(x => x.Id.ToString() == id);

                if (filtro == null || filtro == default)
                {
                    return false;
                }

                candidatos.ListaCandidatos.Remove(filtro);
                ObjetoParaJson<Candidatos>.Editar(candidatos);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Editar(Candidato obj)
        {
            try
            {
                Candidatos? candidatos = JsonParaObjeto<Candidatos>.Recuperar(new Candidatos());
                var candidatoAnterior = candidatos?.ListaCandidatos.Find(x => x.Id == obj.Id);
                if (candidatoAnterior == null || candidatoAnterior == default)
                {
                    return false;
                }

                if (candidatos == null)
                {
                    candidatos = new Candidatos();
                }

                candidatos.ListaCandidatos.Remove(candidatoAnterior);
                candidatos.ListaCandidatos.Add(obj);
                return ObjetoParaJson<Candidatos>.Editar(candidatos);
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
                var candidatos = JsonParaObjeto<Candidatos>.Recuperar(new Candidatos());
                var partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());

                if (candidatos == null || candidatos.ListaCandidatos.Count == 0 || partidos == null || partidos.ListaPartidos.Count == 0)
                {
                    return default;
                }

                ConsoleTable tabela = new ConsoleTable("Id", "Nome", "Partido", "Quantidade de votos", "Cargo do Candidato");
                foreach (Candidato candidato in candidatos.ListaCandidatos)
                {
                    var partido = partidos?.ListaPartidos.Find(x => x.Id == candidato.Partido);
                    tabela.AddRow(candidato.Id, candidato.Nome, $"{partido?.Nome} - {partido?.Sigla}", candidato.QuantidadeVotos, candidato.PoderRepublica);
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
                var candidatos = JsonParaObjeto<Candidatos>.Recuperar(new Candidatos());
                var result = candidatos?.ListaCandidatos.Find(x => x.Id.ToString() == id);
                return result == default || result == null ? false : true;
            }
            catch
            {
                return false;
            }
        }

        public bool VerificaExistePartido()
        {
            var partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());
            return partidos == default || partidos == null ? false : true;
        }

        public bool VerificaExisteNome(string? nome)
        {
            var candidatos = JsonParaObjeto<Candidatos>.Recuperar(new Candidatos());
            var candidato = candidatos?.ListaCandidatos.Find(x => x.Nome == nome);
            return candidato == default || candidato == null ? false : true;
        }

        public bool VerificaExisteSiglaPartido(string? sigla)
        {
            var partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());
            var partido = partidos?.ListaPartidos.Find(x => x.Sigla == sigla);
            return partido == default || partido == null ? false : true;
        }

        public string? PegaIdPartidoPelaSigla(string? sigla)
        {

            var partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());
            var partido = partidos?.ListaPartidos.Find(x => x.Sigla == sigla);
            return partido == default || partido == null ? null : partido.Id.ToString();

        }

    }
}
