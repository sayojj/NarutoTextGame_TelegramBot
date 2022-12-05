using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram_Messaging_Bot_2022
{
    class Program
    {
        static TelegramBotClient Bot = new TelegramBotClient("5862653001:AAFkzfBhwNBH4Wg284LcPDT10zWWEMzSq5I");
        static void Main(string[] args)
        {
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new UpdateType[]
                {
                    UpdateType.Message,
                    UpdateType.EditedMessage,
                }
            };

            Bot.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions);

            Console.ReadLine();
        }

        private static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        private static async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken arg3)
        {
            if (update.Type == UpdateType.Message)
            {
                if (update.Message.Type == MessageType.Text)
                {
                    if (update.Message.Text.ToLower() == "hello")
                    {
                        await bot.SendTextMessageAsync(update.Message.Chat.Id, $"Hello, {update.Message.Chat.Username}.\nHow can I help you?");
                    }
                }
            }
        }
    }
}