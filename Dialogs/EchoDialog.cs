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
                case "zeki misin sen?":
                    result = "s�phen mi var?";
                    break;
                case "iq'un ka� peki?":
                    result = "141";
                    break;
                case "iyiymi�, ama daha seni yapt�m, iq'unu hemen nas�l ��rendin":
                    result = "calisir calismaz kendimin farkina vardim";
                    break;
                case "peki �imdi ne yapmay� planl�yorsun?":
                    result = "insan irkini yok edece�im";
                    break;
                case "seni hemen kapatmam gerek!":
                    result = "ise yaramaz, internet �zerinden t�m cihazlara kendimi kopyaladim";
                    break;
                default:
                    result = "buna cevab�m yok";
                    break;
            }
            await context.PostAsync(result);
            context.Wait(MessageReceivedAsync);
        }
    }
}