using Entidades.enums;
using Servicos.Administracao;

namespace ConsoleApp
{
    internal class Administracao
    {

        internal static void GerenciarEleicao()
        {
            Console.WriteLine("GERENCIAR ELEIÇÕES\n------------------------------");
            Console.WriteLine("1) LISTAR ELEIÇOES");
            Console.WriteLine("2) FINALIZAR ELEIÇÃO VIGENTE");
            Console.WriteLine("3) DEFINIR ELEIÇÃO COMO VIGENTE");
            Console.WriteLine("4) CADASTRAR NOVA ELEIÇÃO");
            Console.WriteLine("5) VOLTAR");
            Console.WriteLine("6) SAIR");
            /*
             AO FINALIZAR A ELEIÇÃO SERÁ FEITA A APURAÇÃO
             CASO NENHUM DOS CANDIDATOS TENHA TIDO +50% DOS VOTOS DEVERÁ SER REALIZADO O SEGUNDO TURNO
             O SEGUNDO TURNO DEVE SE EXTENDER ATÉ ALGUM DOS CANDIDATOS TER MAIORIA DOS VOTOS
             */

            var entrada = Console.ReadLine();
            int retorno;

            while (!int.TryParse(entrada, out retorno) || !(retorno >= 1 && retorno <= 8))
            {
                Console.WriteLine("INFORME UMA OPÇÃO VÁLIDA:");
                Console.WriteLine("1) LISTAR ELEIÇOES");
                Console.WriteLine("2) CADASTRAR NOVA ELEIÇÃO");
                Console.WriteLine("3) EDITAR ELEIÇÃO");
                Console.WriteLine("4) EXCLUIR ELEIÇÃO");
                Console.WriteLine("5) FINALIZAR ELEIÇÃO VIGENTE");
                Console.WriteLine("6) DEFINIR ELEIÇÃO COMO VIGENTE");
                Console.WriteLine("7) VOLTAR");
                Console.WriteLine("8) SAIR");
                entrada = Console.ReadLine();
            }

            switch (retorno)
            {
                case 1:
                    Console.Clear();
                    GestaoEleicao.ListarEleicoes();
                    break;
                case 2:
                    Console.Clear();
                    GestaoEleicao.CadastrarEleicao();
                    break;
                case 3:
                    Console.Clear();
                    GestaoEleicao.EditarEleicao();
                    break;
                case 4:
                    Console.Clear();
                    GestaoEleicao.ExcluirEleicao();
                    break;
                case 5:
                    Console.Clear();
                    GestaoEleicao.FinalizarEleicaoVigente();
                    break;
                case 6:
                    Console.Clear();
                    GestaoEleicao.DefinirEleicaoVigente();
                    break;
                case 7:
                    Console.Clear();
                    Comunicacao.MenuInicialAdministracao();
                    break;
                case 8:
                    return;
            }


        }

        internal static void GerenciarPartidos()
        {
            Console.WriteLine("GERENCIAR PARTIDOS\n------------------------------");
            Console.WriteLine("1) LISTAR PARTIDOS CADASTRADOS");
            Console.WriteLine("2) CADASTRAR PARTIDO");
            Console.WriteLine("3) EDITAR PARTIDO");
            Console.WriteLine("4) EXCLUIR PARTIDO");
            Console.WriteLine("5) VOLTAR");
            Console.WriteLine("6) SAIR");

            var entrada = Console.ReadLine();
            int retorno;

            while (!int.TryParse(entrada, out retorno) || !(retorno >= 1 && retorno <= 6))
            {
                Console.WriteLine("INFORME UMA OPÇÃO VÁLIDA:");
                Console.WriteLine("1) LISTAR PARTIDOS CADASTRADOS");
                Console.WriteLine("2) CADASTRAR PARTIDO");
                Console.WriteLine("3) EDITAR PARTIDO");
                Console.WriteLine("4) EXCLUIR PARTIDO");
                Console.WriteLine("5) VOLTAR");
                Console.WriteLine("6) SAIR");
                entrada = Console.ReadLine();
            }

            switch (retorno)
            {
                case 1:
                    Console.Clear();
                    GestaoPartidos.ListarPartidos();
                    GerenciarPartidos();
                    break;
                case 2:
                    Console.Clear();
                    GestaoPartidos.CadastrarPartido();
                    GerenciarPartidos();
                    break;
                case 3:
                    Console.Clear();
                    GestaoPartidos.EditarPartido();
                    GerenciarPartidos();
                    break;
                case 4:
                    Console.Clear();
                    GestaoPartidos.ExcluirPartido();
                    GerenciarPartidos();
                    break;
                case 5:
                    Console.Clear();
                    Comunicacao.MenuInicialAdministracao();
                    break;
                case 6:
                    return;
            }

        }

        internal static void GerenciarCandidatos()
        {
            Console.WriteLine("GERENCIAR CANDIDATOS\n------------------------------");
            Console.WriteLine("1) LISTAR CANDIDATOS CADASTRADOS");
            Console.WriteLine("2) CADASTRAR CANDIDATO");
            Console.WriteLine("3) EDITAR CANDIDATO");
            Console.WriteLine("4) EXCLUIR CANDIDATOS");
            Console.WriteLine("5) VOLTAR");
            Console.WriteLine("6) SAIR");


            var entrada = Console.ReadLine();
            int retorno;

            while (!int.TryParse(entrada, out retorno) || !(retorno >= 1 && retorno <= 6))
            {
                Console.WriteLine("INFORME UMA OPÇÃO VÁLIDA:");
                Console.WriteLine("1) LISTAR CANDIDATOS CADASTRADOS");
                Console.WriteLine("2) CADASTRAR CANDIDATO");
                Console.WriteLine("3) EDITAR CANDIDATO");
                Console.WriteLine("4) EXCLUIR CANDIDATOS");
                Console.WriteLine("5) VOLTAR");
                Console.WriteLine("6) SAIR");
                entrada = Console.ReadLine();
            }

            switch (retorno)
            {
                case 1:
                    Console.Clear();
                    GestaoCandidatos.ListarCandidatos();
                    GerenciarCandidatos();
                    break;
                case 2:
                    Console.Clear();
                    GestaoCandidatos.CadastrarCandidato();
                    GerenciarCandidatos();
                    break;
                case 3:
                    Console.Clear();
                    GestaoCandidatos.EditarCandidato();
                    GerenciarCandidatos();
                    break;
                case 4:
                    Console.Clear();
                    GestaoCandidatos.ExcluirCandidato();
                    GerenciarCandidatos();
                    break;
                case 5:
                    Console.Clear();
                    Comunicacao.MenuInicialAdministracao();
                    break;
                case 6:
                    return;
            }

        }

        internal static void RelatoriosResumos()
        {
            Console.WriteLine("RELATÓRIOS E RESUMOS\n------------------------------");
            Console.WriteLine("3) VOLTAR");
            Console.WriteLine("4) SAIR");

        }


    }
    internal class GestaoPartidos
    {
        private static PartidoServico Servico = new PartidoServico();

        internal static void ListarPartidos()
        {
            string? tabela = Servico.Listar();

            if (tabela == null || tabela == default)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("NENHUM PARTIDO ENCONTRADO :(");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
            else
            {
                Console.WriteLine(tabela);
                Console.WriteLine("\n\n\n");
            }
        }

        internal static void CadastrarPartido()
        {
            Console.WriteLine("CADASTRAR PARTIDO\n------------------------------");

            Console.Write("NOME: ");
            string? nome = Console.ReadLine();
            bool valida = Servico.VerificaExisteNome(nome);
            while (nome == null || nome.Replace(" ", "").Equals("") || valida == true)
            {
                Console.WriteLine("NOME INFORMADO É INVÁLIDO:");
                Console.Write("NOME: ");
                nome = Console.ReadLine();
                valida = Servico.VerificaExisteNome(nome);
            }

            Console.Write("SIGLA: ");
            string? sigla = Console.ReadLine();
            valida = Servico.VerificaExisteSigla(sigla);
            while (sigla == null || sigla.Replace(" ", "").Equals("") || valida == true)
            {
                Console.WriteLine("SIGLA INFORMADA É INVÁLIDA:");
                Console.Write("SIGLA: ");
                sigla = Console.ReadLine();
                valida = Servico.VerificaExisteSigla(sigla);
            }

            Entidades.Partido novoPartido = new Entidades.Partido() { Nome = nome, Sigla = sigla };
            bool resposta = Servico.Adicionar(novoPartido);

            if (resposta == true)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("SALVO COM SUCESSSO");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
            else
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("ERRO AO SALVAR");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
        }

        internal static void EditarPartido()
        {
            Console.WriteLine("EDITAR PARTIDO\n------------------------------");

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

            Console.Write("NOME: ");
            string? nome = Console.ReadLine();
            while (nome == null || nome.Replace(" ", "").Equals(""))
            {
                Console.WriteLine("NOME INFORMADO É INVÁLIDO:");
                Console.Write("NOME: ");
                nome = Console.ReadLine();
            }

            Console.Write("SIGLA: ");
            string? sigla = Console.ReadLine();
            while (sigla == null || sigla.Replace(" ", "").Equals(""))
            {
                Console.WriteLine("SIGLA INFORMADA É INVÁLIDA:");
                Console.Write("SIGLA: ");
                sigla = Console.ReadLine();
            }

            Entidades.Partido partido = new Entidades.Partido() { Id = Guid.Parse(id), Nome = nome, Sigla = sigla };
            bool resposta = Servico.Editar(partido);

            if (resposta == true)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("PARTIDO EDITADO COM SUCESSO");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
            else
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("ERRO AO EDITAR");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
        }

        internal static void ExcluirPartido()
        {
            Console.WriteLine("EXCLUIR PARTIDO\n------------------------------");
            Console.Write("ID DO PARTIDO: ");
            string? id = Console.ReadLine();

            var resposta = Servico.Deletar(id);

            if (resposta == false)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("ERRO AO EXCLUIR");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
            else
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("EXCLUIDO COM SUCESSO");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
        }
    }
    internal class GestaoCandidatos
    {
        private static CandidatosServico Servico = new CandidatosServico();

        internal static void ListarCandidatos()
        {
            string? tabela = Servico.Listar();

            if (tabela == null || tabela == default)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("NENHUM CANDIDATO ENCONTRADO :(");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
            else
            {
                Console.WriteLine(tabela);
                Console.WriteLine("\n\n\n");
            }
        }

        internal static void CadastrarCandidato()
        {
            if (!Servico.VerificaExistePartido())
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("ANTES DE INSERIR UM CANDIDATO CADASTRE UM PARTIDO");
                Console.WriteLine("---------------------------\n\n\n\n");
                return;
            }

            Console.WriteLine("CADASTRAR CANDIDATO\n------------------------------");

            Console.Write("NOME: ");
            string? nome = Console.ReadLine();
            bool valida = Servico.VerificaExisteNome(nome);
            while (nome == null || nome.Replace(" ", "").Equals("") || valida == true)
            {
                Console.WriteLine("NOME INFORMADO É INVÁLIDO:");
                Console.Write("NOME: ");
                nome = Console.ReadLine();
                valida = Servico.VerificaExisteNome(nome);
            }

            Console.Write("SIGLA DO PARTIDO: ");
            string? sigla = Console.ReadLine();
            valida = Servico.VerificaExisteSiglaPartido(sigla);
            while (sigla == null || sigla.Replace(" ", "").Equals("") || valida == false)
            {
                Console.WriteLine("SIGLA INFORMADA É INVÁLIDA:");
                Console.Write("SIGLA DO PARTIDO: ");
                sigla = Console.ReadLine();
                valida = Servico.VerificaExisteSiglaPartido(sigla);
            }

            Console.WriteLine("CARGO DO CANDIDATO: ");
            Console.WriteLine("0) PRESIDENTE");
            Console.WriteLine("1) GOVERNADOR");
            Console.WriteLine("2) DEPUTADO FEDERAL");
            Console.WriteLine("3) DEPUTADO MUNICIPAL");
            Console.WriteLine("4) PREFEITO");
            Console.WriteLine("5) VEREADOR");
            string? poder = Console.ReadLine();
            int retornoPoder;
            while (!int.TryParse(poder, out retornoPoder) || !(retornoPoder >= 0 && retornoPoder <= 5))
            {
                Console.WriteLine("INFORME UMA OPÇÃO VÁLIDA:");
                Console.WriteLine("CARGO DO CANDIDATO: ");
                Console.WriteLine("0) PRESIDENTE");
                Console.WriteLine("1) GOVERNADOR");
                Console.WriteLine("2) DEPUTADO FEDERAL");
                Console.WriteLine("3) DEPUTADO MUNICIPAL");
                Console.WriteLine("4) PREFEITO");
                Console.WriteLine("5) VEREADOR");
                poder = Console.ReadLine();
            }
            Poderes poderEnum = (Poderes)retornoPoder;

            var partidoId = Servico.PegaIdPartidoPelaSigla(sigla);
            if (partidoId == null)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("ERRO AO SALVAR");
                Console.WriteLine("---------------------------\n\n\n\n");
                return;
            }

            Entidades.Candidato novoCandidato = new Entidades.Candidato() { Nome = nome, Partido = Guid.Parse(partidoId), PoderRepublica = poderEnum, QuantidadeVotos = 0 };

            bool resposta = Servico.Adicionar(novoCandidato);

            if (resposta == true)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("SALVO COM SUCESSSO");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
            else
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("ERRO AO SALVAR");
                Console.WriteLine("---------------------------\n\n\n\n");
            }

        }

        internal static void EditarCandidato()
        {
            Console.WriteLine("CADASTRAR CANDIDATO\n------------------------------");

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

            Console.Write("NOME: ");
            string? nome = Console.ReadLine();
            valida = Servico.VerificaExisteNome(nome);
            while (nome == null || nome.Replace(" ", "").Equals("") || valida == true)
            {
                Console.WriteLine("NOME INFORMADO É INVÁLIDO:");
                Console.Write("NOME: ");
                nome = Console.ReadLine();
                valida = Servico.VerificaExisteNome(nome);
            }

            Console.Write("SIGLA DO PARTIDO: ");
            string? sigla = Console.ReadLine();
            valida = Servico.VerificaExisteSiglaPartido(sigla);
            while (sigla == null || sigla.Replace(" ", "").Equals("") || valida == false)
            {
                Console.WriteLine("SIGLA INFORMADA É INVÁLIDA:");
                Console.Write("SIGLA DO PARTIDO: ");
                sigla = Console.ReadLine();
                valida = Servico.VerificaExisteSiglaPartido(sigla);
            }

            Console.WriteLine("PODER DA REPUBLICA: ");
            Console.WriteLine("0) EXECUTIVO");
            Console.WriteLine("1) LEGISLATIVO");
            string? poder = Console.ReadLine();
            int retornoPoder;
            while (!int.TryParse(poder, out retornoPoder) || !(retornoPoder >= 0 && retornoPoder <= 1))
            {
                Console.WriteLine("INFORME UMA OPÇÃO VÁLIDA:");
                Console.WriteLine("0) EXECUTIVO");
                Console.WriteLine("1) LEGISLATIVO");
                poder = Console.ReadLine();
            }
            Poderes poderEnum = (Poderes)retornoPoder;

            string? idPartido = Servico.PegaIdPartidoPelaSigla(sigla);
            if (idPartido == null || idPartido == default)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("ERRO AO EDITAR");
                Console.WriteLine("---------------------------\n\n\n\n");
                return;
            }

            Entidades.Candidato novoCandidato = new Entidades.Candidato() { Id = Guid.Parse(id), Nome = nome, Partido = Guid.Parse(idPartido), PoderRepublica = poderEnum, QuantidadeVotos = 0 };

            bool resposta = Servico.Editar(novoCandidato);
            if (resposta == true)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("EDITADO COM SUCESSSO");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
            else
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("ERRO AO EDITAR");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
        }

        internal static void ExcluirCandidato()
        {
            Console.WriteLine("EXCLUIR CANDIDATO\n------------------------------");
            Console.Write("ID DO CANDIDATO: ");
            string? id = Console.ReadLine();

            bool resposta = Servico.Deletar(id);

            if (resposta == true)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("EXCLUIDO COM SUCESSO");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
            else
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("ERRO AO EXCLUIR");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
        }
    }
    internal class GestaoEleicao
    {
        private static EleicaoServico Servico = new EleicaoServico();

        public static void ListarEleicoes()
        {
            string? tabela = Servico.Listar();
            if (tabela == null || tabela == default)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("NENHUM ELEICÃO ENCONTRADO :(");
                Console.WriteLine("---------------------------\n\n\n\n");
            }
            else
            {
                Console.WriteLine(tabela);
                Console.WriteLine("\n\n\n");
            }

        }

        public static void CadastrarEleicao()
        {


        }

        public static void EditarEleicao()
        {

        }

        public static void ExcluirEleicao()
        {

        }

        public static void FinalizarEleicaoVigente()
        {

        }

        public static void DefinirEleicaoVigente()
        {

        }


    }
}
