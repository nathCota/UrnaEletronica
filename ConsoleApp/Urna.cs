using ConsoleTables;
using Entidades;
using Entidades.Plural;
using Persistencias;
using Servicos.Administracao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Urna
    {
        private static EleicaoServico Servico = new EleicaoServico();
        public static ArrayList Politicos { get; set; } = new ArrayList();
        internal static void MenuIniciaL()
        {
            Console.Clear();
            Console.WriteLine("VOTAÇÃO\n------------------------------");
            GestaoEleicao.ListarEleicoes();
            Console.WriteLine("ESCOLHA A ELEIÇÃO!");
            Console.WriteLine("RETORNE O ID DA ELEIÇÃO");
            Console.Write("ID: ");
            string? id = Console.ReadLine();
            bool valida = Servico.VerificaExisteId(id);
            while (id == null || id.Replace(" ", "").Equals("") || valida == false)
            {
                Console.WriteLine("ID INFORMADO É INVÁLIDO:");
                Console.Write("ID: ");
                id = Console.ReadLine();
                valida = Servico.VerificaExisteId(id);
            }
            int escolhaModulo;
            // if(escolhaModulo==)

        }
        public static Candidato ModuloLegislativo(){
            try
            {
                var candidatos = JsonParaObjeto<Candidatos>.Recuperar(new Candidatos());
                var partidos = JsonParaObjeto<Partidos>.Recuperar(new Partidos());

                if (candidatos == null || candidatos.ListaCandidatos.Count == 0 || partidos == null || partidos.ListaPartidos.Count == 0)
                {
                    return default;
                }

                ConsoleTable tabela = new ConsoleTable("Id", "Nome", "Partido", "Cargo do Candidato");
                foreach (Candidato candidato in candidatos.ListaCandidatos)
                {
                    var partido = partidos?.ListaPartidos.Find(x => x.Id == candidato.Partido);
                    tabela.AddRow(candidato.Id, candidato.Nome, $"{partido?.Nome} - {partido?.Sigla}", candidato.CardgoCandidato);
                }

                return tabela.ToString();
            }
            catch
            {
                return default;
            }
        }
            
            //testar todos os tipo de candidato, retornando a listagem e pedindo para escolher, no final de cada tipo computar o voto 
            ComputaVoto();
        
        public static void ModuloExecutivo()
        {

            //testar todos os tipo de candidato, retornando a listagem e pedindo para escolher, no final de cada tipo computar o voto 
            ComputaVoto();
        }
        internal static void ComputaVoto()
        {

        }
    }
}
