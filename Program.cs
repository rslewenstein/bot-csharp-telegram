using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
//using Telegram.Bot.Extensions.Polling;

namespace bot_csharp_telegram
{
    class Program
    {
        private static TelegramBotClient botClient = new TelegramBotClient("YOUR_TOKEN"); // YOUR_TOKEN
        static void Main(string[] args)
        {
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Olá! Eu sou o {me.FirstName}.");

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(Timeout.Infinite);
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();

            botClient.StopReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Mensagem recebida do chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                    // chatId: e.Message.Chat,
                    // text: "Você disse:\n " + e.Message.Text
                    e.Message.Chat.Id,
                    $"Olá {e.Message.From.FirstName}, tudo bem? \nVocê disse: \n {e.Message.Text}"
                );
            }
        }
    }
}