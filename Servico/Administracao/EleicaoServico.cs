using Entidades;
using Entidades.Plural;
using Persistencias;
using Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Administracao
{
    public class EleicaoServico : ICrud<Eleicoes, Eleicao>
    {
        public bool Adicionar(Eleicao obj)
        {
            try
            {
                obj.Vigente = false;
                obj.TurnoAtual = 1;
                Eleicoes? eleicoes = JsonParaObjeto<Eleicoes>.Recuperar(new Eleicoes());

                if (eleicoes == null)
                {
                    eleicoes = new Eleicoes();
                }

                eleicoes.ListaEleicoes.Add(obj);

                if (!ObjetoParaJson<Eleicoes>.Salvar(eleicoes))
                {
                    ObjetoParaJson<Eleicoes>.Editar(eleicoes);
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
                var eleicoes = JsonParaObjeto<Eleicoes>.Recuperar(new Eleicoes());

                if (eleicoes == null || eleicoes == default || eleicoes.ListaEleicoes.Count == 0 || id == null || id == default)
                {
                    return false;
                }

                var filtro = eleicoes.ListaEleicoes.Find(x => x.Id.ToString() == id);

                if (filtro == null || filtro == default)
                {
                    return false;
                }

                if(filtro.Vigente == true)
                {
                    return false;
                }

                eleicoes.ListaEleicoes.Remove(filtro);
                return ObjetoParaJson<Eleicoes>.Editar(eleicoes);

            }
            catch
            {
                return false;
            }
        }

        public bool Editar(Eleicao obj)
        {
            try
            {
                Eleicoes? eleicoes = JsonParaObjeto<Eleicoes>.Recuperar(new Eleicoes());
                var eleicaoAnterior = eleicoes?.ListaEleicoes.Find(x => x.Id == obj.Id);
                if (eleicaoAnterior == null || eleicaoAnterior == default || eleicaoAnterior.Vigente == true)
                {
                    return false;
                }

                if (eleicoes == null)
                {
                    eleicoes = new Eleicoes();
                }


                eleicoes.ListaEleicoes.Remove(eleicaoAnterior);
                eleicoes.ListaEleicoes.Add(obj);
                return ObjetoParaJson<Eleicoes>.Editar(eleicoes) ? true : false;

            }
            catch
            {
                return false;
            }
        }

        public string? Listar()
        {
            throw new NotImplementedException();
        }

        public static bool AtualizaEleicaoVigente()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Eleicao? RecuperaEleicaoVigente()
        {
            try
            {
                var eleicoes = JsonParaObjeto<Eleicoes>.Recuperar(new Eleicoes());
                return eleicoes?.ListaEleicoes.Find(x => x.Vigente == true);
            }
            catch
            {
                return default;
            }
        }

        public static bool VerificaIdCandidato(string? idCandidato)
        {
            try
            {
                var candidatos = JsonParaObjeto<Candidatos>.Recuperar(new Candidatos());
                var result = candidatos?.ListaCandidatos.Find(x => x.Id.ToString() == idCandidato);
                return result == default || result == null ? false : true;
            }
            catch
            {
                return false;
            }
        }

        public bool VerificaExistePartidos()
        {
            try
            {
                var partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());
                return partidos == default || partidos == null ? false : true;
            }
            catch
            {
                return false;
            }
        }

        public bool VerificaExisteCandidatos()
        {
            try
            {
                var candidatos = JsonParaObjeto<Candidatos>.Recuperar(new Candidatos());
                return candidatos == default || candidatos == null ? false : true;
            }
            catch
            {
                return false;
            }
        }

    }
}
