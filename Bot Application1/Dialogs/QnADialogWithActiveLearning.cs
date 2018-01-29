using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    [QnAMaker("58523c2cdcea407c989b2f3fb8609862", "85166011-7579-4896-be1b-33f52c651ad9", "Não identifiquei sua pergunta", 0.5, 1)]
    public class QnADialogWithActiveLearning : QnAMakerDialog
    {

    }
}