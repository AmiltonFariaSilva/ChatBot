using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            await context.PostAsync("**Olá, Tudo Bem?**");

            var message = activity.CreateReply();

            if (activity.Text.Equals("herocard", StringComparison.InvariantCultureIgnoreCase))
            {
                var heroCard = new HeroCard();

                heroCard.Title = "Bolo";
                heroCard.Subtitle = "De coco";
                heroCard.Images = new List<CardImage>
            {
                new CardImage("https://img.cybercook.uol.com.br/imagens/receitas/969/bolo-de-chocolate-molhadinho-1-583x350.jpg",
                "Bolo de cocô", new CardAction(ActionTypes.OpenUrl, "Lojinha de Pastel", value: "http://www.viceri.com.br/"))
            };

                heroCard.Buttons = new List<CardAction>
                {
                    new CardAction{
                        Text = "Botão 1",
                        DisplayText = "Display",
                        Title = "Title",
                        Type = ActionTypes.PostBack,
                        Value = "audiocard"

                    }


                };

                message.Attachments.Add(heroCard.ToAttachment());

            }
            else if (activity.Text.Equals("videocard", StringComparison.InvariantCultureIgnoreCase))
            {
                var attachement = CreateVideoCard();

                message.Attachments.Add(attachement);
            }
            else if (activity.Text.Equals("audiocard", StringComparison.InvariantCultureIgnoreCase))
            {
                var attachement = CreateAudioCard();

                message.Attachments.Add(attachement);

            }
            else if (activity.Text.Equals("animationCard", StringComparison.InvariantCultureIgnoreCase))
            {
                var attachement = CreateAnimationCard();

                message.Attachments.Add(attachement);

            }
            else if (activity.Text.Equals("carousel", StringComparison.InvariantCultureIgnoreCase))
            {         

                message.AttachmentLayout = AttachmentLayoutTypes.Carousel;

                var audio = CreateAudioCard();
                var animation = CreateAnimationCard();
                var video = CreateVideoCard();

                message.Attachments.Add(audio);
                message.Attachments.Add(animation);
                message.Attachments.Add(video);

            }



            await context.PostAsync(message);

            context.Wait(MessageReceivedAsync);
        }

        private Attachment CreateAnimationCard()
        {
            var animationCard = new AnimationCard();

            animationCard.Title = "animationCard Pega Rex!";
            animationCard.Subtitle = "gifizin";
            animationCard.Autoloop = false;
            animationCard.Autostart = true;

            animationCard.Media = new List<MediaUrl>
                {
                    new MediaUrl("https://img.buzzfeed.com/buzzfeed-static/static/2014-06/14/15/enhanced/webdr07/anigif_enhanced-30127-1402774426-6.gif")
                };

            return animationCard.ToAttachment();
        }

        private Attachment CreateAudioCard()
        {
            var audioCard = new AudioCard();

            audioCard.Title = "Pega Rex!";
            audioCard.Subtitle = "Aqui vai um subtitulo";
            audioCard.Image = new ThumbnailUrl("https://hypescience.com/wp-content/uploads/2017/05/cachorro-beneficios.jpg");
            audioCard.Autoloop = false;
            audioCard.Autostart = true;

            audioCard.Media = new List<MediaUrl>
                {
                    new MediaUrl("//protettordelinks.com/wp-content/audiosparazap/cachorro_latindo.mp3")
                };

            return audioCard.ToAttachment();
        }

        private Attachment CreateVideoCard()
        {
            var videoCard = new VideoCard();

            videoCard.Title = "Video do bolo";
            videoCard.Subtitle = "Aqui vai um subtitulo";
            videoCard.Autoloop = false;
            videoCard.Autostart = true;

            videoCard.Media = new List<MediaUrl>
                {
                    new MediaUrl("https://www.youtube.com/watch?v=ieukcNWempc")
                };

            return videoCard.ToAttachment();
        }
    }
}

