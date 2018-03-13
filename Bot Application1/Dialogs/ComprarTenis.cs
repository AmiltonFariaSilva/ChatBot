using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    [LuisModel("e6f426c1-e091-4888-a6a1-8bbdee8983f8", "1bffe21c349a4146b3e2399509c32316")]

    public class ComprarTenis : LuisDialog<object>
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
            await context.PostAsync($"Saudações humano, eu sou uma máquina e vou lhe vender um tênis hoje!");
        }

        [LuisIntent("Compra")]

        public async Task Compra(IDialogContext context, LuisResult result)
        {
            var tenis = result.Entities?.Select(e => e.Entity); 

            await context.PostAsync($"Eu Farei uma venda de tenis para você{string.Join(",", tenis.ToArray())}");
        }
    }
}