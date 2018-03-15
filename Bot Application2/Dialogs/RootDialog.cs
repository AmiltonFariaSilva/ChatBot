using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;

namespace ChatBot.Dialogs
{
    [Serializable]
    [QnAMaker("58523c2cdcea407c989b2f3fb8609862", "85166011-7579-4896-be1b-33f52c651ad9", "Não identifiquei sua pergunta", 0.5, 1)]
    public class QnADialogWithActiveLearning : QnAMakerDialog
    {

    }
}