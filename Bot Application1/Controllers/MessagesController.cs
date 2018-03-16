using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

namespace Bot_Application1
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await this.sendConversation(activity);
                //await Conversation.SendAsync(activity, () => new Dialogs.CotacaoDialog());
                //await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
                //await Conversation.SendAsync(activity, () => new Dialogs.ComprarTenis());
                //await Conversation.SendAsync(activity, () => new Dialogs.CotacaoDialog());
                //await Conversation.SendAsync(activity, () => new Dialogs.CotacaoDialog());
            }
            else if (activity.Type == ActivityTypes.ConversationUpdate)
            {
                if (activity.MembersAdded != null && activity.MembersAdded.Any())
                {
                    foreach (var members in activity.MembersAdded)
                    {
                        if (members.Id != activity.Recipient.Id)
                        {
                            await this.sendConversation(activity);
                        }
                    }
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private async Task sendConversation(Activity activity)
        {
            await Conversation.SendAsync(activity,  () => Chain.From(() => FormDialog.FromForm(() => Formularios.Pedido.BuildForm(), FormOptions.PromptFieldsWithValues)));
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}