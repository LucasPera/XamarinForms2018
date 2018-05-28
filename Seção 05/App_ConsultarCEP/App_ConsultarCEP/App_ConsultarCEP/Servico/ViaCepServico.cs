using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using App_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
namespace App_ConsultarCEP.Servico
{
    public class ViaCepServico
    {
        private static string enderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoURL = string.Format(enderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(novoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.Cep == null) return null;

            return end;

        }
       
    }
}
