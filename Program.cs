using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace bot_csharp_telegram
{
    class Program
    {
        static ITelegramBotClient botClient;
        static void Main()
        {
            botClient = new TelegramBotClient("YOUR_TOKEN");
        }
    }
}
