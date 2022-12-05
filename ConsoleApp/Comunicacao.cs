using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Comunicacao
    {

        public static void Start()
        {
            Console.WriteLine("URNA ELETRÔNICA 1.0\n------------------------------");
            Console.WriteLine("O QUE DESEJA FAZER?");
            Console.WriteLine("1) ADMINISTRAR");
            Console.WriteLine("2) VOTAR");
            Console.WriteLine("3) SAIR\n");

            var entrada = Console.ReadLine();
            int retorno;

            while (!int.TryParse(entrada, out retorno) || !(retorno >= 1 && retorno <= 3))
            {
                Console.WriteLine("INFORME UMA OPÇÃO VÁLIDA:");
                Console.WriteLine("1) ADMINSTRAÇÃO");
                Console.WriteLine("2) VOTAÇÃO");
                Console.WriteLine("3) SAIR");
                entrada = Console.ReadLine();
            }

            switch (retorno)
            {
                case 1:
                    MenuInicialAdministracao();
                    break;
                case 2:
                    MenuInicialUrna();
                    break;
                case 3:
                    return;
            }

        }

        internal static void MenuInicialAdministracao()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRAÇÃO DO SISTEMA ELEITORAL\n------------------------------");
            Console.WriteLine("1) GERENCIAR ELEIÇÕES");
            Console.WriteLine("2) GERENCIAR PARTIDOS");
            Console.WriteLine("3) GERENCIAR CANDIDATOS");
            Console.WriteLine("4) RELATÓRIOS E RESUMOS");
            Console.WriteLine("5) VOLTAR");
            Console.WriteLine("6) SAIR\n");

            var entrada = Console.ReadLine();
            int retorno;

            while (!int.TryParse(entrada, out retorno) || !(retorno >= 1 && retorno <= 6))
            {
                Console.WriteLine("INFORME UMA OPÇÃO VÁLIDA:");
                Console.WriteLine("1) GERENCIAR ELEIÇÕES");
                Console.WriteLine("2) GERENCIAR PARTIDOS");
                Console.WriteLine("3) GERENCIAR CANDIDATOS");
                Console.WriteLine("4) RELATÓRIOS E RESUMOS");
                Console.WriteLine("5) VOLTAR");
                Console.WriteLine("6) SAIR");
                entrada = Console.ReadLine();
            }

            switch (retorno)
            {
                case 1:
                    Console.Clear();
                    Administracao.GerenciarEleicao();
                    break;
                case 2:
                    Console.Clear();
                    Administracao.GerenciarPartidos();
                    break;
                case 3:
                    Console.Clear();
                    Administracao.GerenciarCandidatos();
                    break;
                case 4:
                    Console.Clear();
                    Administracao.RelatoriosResumos();
                    break;
                case 5:
                    Console.Clear();
                    Start();
                    break;
                case 6:
                    return;
            }

        }

        internal static void MenuInicialUrna()
        {
            Urna.MenuIniciaL();
         }

    }

}
