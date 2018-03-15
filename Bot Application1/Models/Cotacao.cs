using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1.Models
{
    //http://api.promasters.net.br/cotacao/v1/valores

    public class Resultado
    {
        public bool status { get; set; }
        public Cotacao[] Cotacoes { get; set; }
    }

    public class Cotacao
    {
        public USD USD { get; set; }
        public EUR EUR { get; set; }
        public ARS ARS { get; set; }
        public GBP GBP { get; set; }
        public BTC BTC { get; set; }
    }

    public class USD
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("valor")]
        public float Valor { get; set; }
        [JsonProperty("ultima_consulta")]
        public int UltimaConsulta { get; set; }
        [JsonProperty("fonte")]
        public string Fonte { get; set; }
    }

    public class EUR
    {
        public string nome { get; set; }
        public float valor { get; set; }
        public int ultima_consulta { get; set; }
        public string fonte { get; set; }
    }

    public class ARS
    {
        public string nome { get; set; }
        public float valor { get; set; }
        public int ultima_consulta { get; set; }
        public string fonte { get; set; }
    }

    public class GBP
    {
        public string nome { get; set; }
        public float valor { get; set; }
        public int ultima_consulta { get; set; }
        public string fonte { get; set; }
    }

    public class BTC
    {
        public string nome { get; set; }
        public float valor { get; set; }
        public int ultima_consulta { get; set; }
        public string fonte { get; set; }
    }

}