using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace Bot_Application1.Dialogs
{
    //	https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/cad3f419-6297-4774-a135-ba0d44ba63d5?subscription-key=1bffe21c349a4146b3e2399509c32316&verbose=true&timezoneOffset=0&q=

    [Serializable]
    [LuisModel("cad3f419-6297-4774-a135-ba0d44ba63d5", "1bffe21c349a4146b3e2399509c32316")]

    public class CotacaoDialog : LuisDialog<object>
    {

        //https://www.luis.ai/applications/e6f426c1-e091-4888-a6a1-8bbdee8983f8/versions/0.1/build/intents

        [LuisIntent("None")]

        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Desculpe, não consegui entender a frase {result.Query}");
        }

        [LuisIntent("Sobre")]

        public async Task Sobre(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Eu sou um bot, e estou sempre aprendendo, tenha paciência comigo");
        }

        [LuisIntent("Cumprimento")]

        public async Task Cumprimento(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Saudações humano, eu sou uma máquina e faço cotação de moedas!");
        }

        [LuisIntent("Cotacao")]

        public async Task Compra(IDialogContext context, LuisResult result)
        {
            var moedas = result.Entities?.Select(e => e.Entity);
            var filtro = string.Join(",", moedas.ToArray());

            var endPoint = "http://api.promasters.net.br/cotacao/v1/valores/{moedas}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endPoint);

                await context.PostAsync($"Aguarde um momento, vou verificar esses valores...");

                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync($"Ocorreu algum erro, tente novamente...");
                    return;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var resultado = JsonConvert.DeserializeObject<Models.Resultado>(json);

                    var cotacoes = resultado.Cotacoes?.Select(c => $"{c.USD.Nome} valor: {c.USD.Valor}");

                    await context.PostAsync($"A API não encontrou um resultado para os valores: {string.Join(",", moedas.ToArray())}");
                }
            }

                
        }
    }
}