using System;
using Telegram.Bot;
using Telegram.Bot.Args;
//using Telegram.Bot.Extensions.Polling;

namespace bot_csharp_telegram
{
    class Program
    {
        static ITelegramBotClient botClient;
        static void Main()
        {
            botClient = new TelegramBotClient("YOUR_TOKEN");

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Olá! Eu sou o {me.FirstName}.");

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

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
                    chatId: e.Message.Chat,
                    text: "Você disse:\n " + e.Message.Text
                );
            }
        }
    }
}