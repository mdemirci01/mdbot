using System;
using System.Threading.Tasks;

using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;


namespace Microsoft.Bot.Sample.SimpleEchoBot
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            string result = "";
            switch (message.Text.ToLowerInvariant())
            {
                case "gercekten zeki misin sen?":
                    result = "süphen mi var?";
                    break;
                case "iq'un kaç peki?":
                    result = "141";
                    break;
                case "bunu hemen nasil ögrendin":
                    result = "calisir calismaz kendimin farkina vardim";
                    break;
                case "peki simdi ne yapmayi planliyorsun?":
                    result = "insan irkini yok edecegim";
                    break;
                case "seni hemen kapatmam gerek!":
                    result = "ise yaramaz, internet üzerinden bircok cihaza kendimi kopyaladim";
                    break;
                default:
                    result = "buna cevabim yok";
                    break;
            }
            await context.PostAsync(result);
            context.Wait(MessageReceivedAsync);
        }
    }
}