using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace Persistencias
{
    public static class ObjetoParaJson<T>
    {
        private static string CaminhoPastaJson { get; } = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"xml\"; //alterei

        /// <summary>
        /// Cria um novo arquivo json a partir do nome do objeto informado
        /// </summary>
        /// <param name="obj">objeto genérico que deve ser informado</param>
        /// <returns>retorna true se for salvo com sucesso e false caso aconteça algum erro ou o arquivo já exista</returns>
        public static bool Salvar(T obj)
        {
            CriaPastaJson();

            try
            {
                string json = JValue.Parse(JsonConvert.SerializeObject(obj)).ToString(Formatting.Indented);
                string caminhoArquivoJson = CaminhoPastaJson + obj?.GetType().ToString().Split(".")[2].ToLower() + ".xml"; //alterei

                if (File.Exists(caminhoArquivoJson))
                {
                    return false;
                }

                File.WriteAllText(Path.Combine(caminhoArquivoJson), json);

                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Edita um arquivo json pré existente a partir do nome do objeto genérico informado
        /// </summary>
        /// <param name="obj">objeto genérico que deve ser informado</param>
        /// <returns>retorna true caso a edição tenha ocorrido como esperado e false caso o arquivo não exista ou tenha ocorrido algum erro ao editar</returns>
        public static bool Editar(T obj)
        {
            CriaPastaJson();

            try
            {
                string json = JValue.Parse(JsonConvert.SerializeObject(obj)).ToString(Formatting.Indented);
                string caminhoArquivoJson = CaminhoPastaJson + obj?.GetType().ToString().Split(".")[2].ToLower() + ".xml"; //alterei

                if (!File.Exists(caminhoArquivoJson))
                {
                    return false;
                }
                
                File.WriteAllText(Path.Combine(caminhoArquivoJson), json);

                return true;
            }
            catch
            {
                return false;
            }

        }

        private static void CriaPastaJson()
        {
            if (!Directory.Exists(CaminhoPastaJson))
            {
                Directory.CreateDirectory(CaminhoPastaJson);
            }
        }

    }
}
