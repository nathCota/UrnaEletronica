using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistencias
{
    public static class JsonParaObjeto<T>
    {
        private static string CaminhoPastaJson { get; } = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"json\";

        /// <summary>
        /// Recupera arquivo json a partir do tipo genérico informado e instância qualquer compativel com o tipo genérico informado
        /// </summary>
        /// <param name="obj">instância do tipo genérico informado</param>
        /// <returns>retorna default caso ocorra algum erro ou o tipo genérico caso consiga recuperar o arquivo json</returns>
        public static T? Recuperar(T obj)
        {
            try
            {
                string caminhoArquivoJson = CaminhoPastaJson + obj?.GetType().ToString().Split(".")[2].ToLower() + ".json";

                if (!Directory.Exists(CaminhoPastaJson) || !File.Exists(caminhoArquivoJson))
                {
                    return default(T?);
                }

                string json = File.ReadAllText(caminhoArquivoJson);
                return JsonSerializer.Deserialize<T>(json);
            }
            catch
            {
                return default(T?);
            }
        }

    }
}
