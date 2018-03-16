using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1.Formularios
{
    [Serializable]
    [Template(TemplateUsage.NotUnderstood, "Desculpe não entendi\"{0}\".")]
    public class Pedido
    {
        public Salgadinhos salgadinhos { get; set; }
        public Bebidas bebidas { get; set; }
        public TipoEntrega tipoEntrega { get; set; }  
        public CPFNaNota cpfNaNota { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public static IForm<Pedido> BuildForm()
        {
            var form = new FormBuilder<Pedido>();
            //priorizar botões
            form.Configuration.DefaultPrompt.ChoiceStyle = ChoiceStyleOptions.Buttons;
            form.Configuration.Yes = new string[] { "sim", "yes", "y", "s", "yep" };
            form.Configuration.No = new string[] { "nao","não","Not","No","n" };
            form.Message("Olá, Seja bem vindo!! Será um prazer ajudar você...");
            form.OnCompletion(async (context, pedido) =>
            {
                //Salvar na base de dados
                //Gerar pedido
                //Integrar com serviço
                await context.PostAsync("Seu pedido foi gerado, com o número 12345. Em breve estará indo para você...");
            });


            return form.Build();

        } 
    }

    [Describe("TipoEntrega")]
    public enum TipoEntrega
    {
        [Terms("Retirar no local", "Passo ai", "Eu pego", "Retiro ai")]
        [Describe("RetiraLocal")]
        RetiraLocal = 1,
        [Terms("Motoca", "Entrega", "Manda aqui", "Em casa")]
        [Describe("Motoboy")]
        Motoboy
    }

    [Describe("salgadinhos")]
    public enum Salgadinhos
    {
        [Terms("Esfirra", "Esfira", "I")]
        [Describe("Esfirra")]
        Esfirra = 1,
        [Terms("Quibe", "Kibe", "kibi")]
        [Describe("Quibe")]
        Quibe,
        [Terms("Coxa", "Cochinha", "coxinha")]
        [Describe("Coxinha")]
        Coxinha
        
    }

    [Describe("Bebidas")]
    public enum Bebidas
    {
        [Terms("Água","agua","h2o","a")]
        [Describe("Água")]
        Agua = 1,
        [Terms("refrigerante", "refri", "Refri", "a")]
        [Describe("Refrigerante")]
        Refrigerante,
        [Terms("suco")]
        [Describe("Suco")]
        Suco
    }

    [Describe("CPF na Nota")]
    public enum CPFNaNota
    {
        [Terms("sim", "yes","Yes", "y","Y")]
        [Describe("Sim")]
        Sim = 1,
        [Terms("Não", "N", "não", "N", "n","not")]
        [Describe("Nao")]
        Nao
    }
}