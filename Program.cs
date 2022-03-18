namespace PsychoBot
{
    using System;
    using System.Collections.Generic;
    using Telegram.Bot;
    using Telegram.Bot.Args;
    using Telegram.Bot.Types.ReplyMarkups;

    internal class Program
    {
        private static string Token { get; set; } = "5192872162:AAEQazYu7kAz0bgH2BksjSyIXYY1QBVuW7A";
        private static TelegramBotClient _bot;

        [Obsolete]
        private static void Main()
        {
            _bot = new TelegramBotClient(Token);
            _bot.OnMessage += OnMessageHandler;
            _bot.StartReceiving();
            Console.ReadLine();
            _bot.StopReceiving();
        }

        [Obsolete]
        private static async void OnMessageHandler(object? sender, MessageEventArgs e)
        {
            var message = e.Message;

            if (message.Text != null)
            {
                Console.WriteLine($"Was sent message: {message.Text}");

                switch (message.Text)
                {
                    case "Hello":
                        await _bot.SendTextMessageAsync(
                            message.Chat.Id,
                            "Hi i'm your mental health care assistant!"
                            + "You can click on any button to get my advice(:",
                            replyToMessageId: message.MessageId);
                        break;
                    case "I am sad(":
                        await _bot.SendTextMessageAsync(
                            message.Chat.Id, 
                            "Since the guinea pig is considered a social animal that needs to \"socialize\", " +
                                             "Swiss law prohibits keeping one individual at home - only a couple. " +
                                             "By the way, if one of the pigs dies, the owner must immediately acquire the remaining individual of the friend. " +
                                             "You urgently need to spend time with your friends or loved ones",
                            replyMarkup: GetButtons());
                        await _bot.SendPhotoAsync(
                            message.Chat.Id,
                            "https://vk.com/pixel_stickers?z=photo-39566948_457779383%2Fwall-39566948_1315772");
                        break;
                    case "I'm fine, you're a good bot!":
                        await _bot.SendTextMessageAsync(
                            message.Chat.Id,
                            "Thanks, honey, I am doing my best. " +
                            "You know, you're awesome too!",
                            replyMarkup: GetButtons());
                        break;
                    case "Cute sticker":
                        await _bot.SendStickerAsync(
                            message.Chat.Id,
                            "https://tlgrm.ru/_/stickers/06c/d14/06cd1435-9376-40d1-b196-097f5c30515c/192/20.webp",
                            replyToMessageId: message.MessageId,
                            replyMarkup: GetButtons());
                        break;
                    case "I'm bored":
                        await _bot.SendTextMessageAsync(
                            message.Chat.Id,
                            "Bunny, remember what makes you happy. And at the same time, it should be useful! I believe in you)");
                        break;
                    default:
                        await _bot.SendTextMessageAsync(message.Chat.Id, "if you're cute, press the button ", replyMarkup: GetButtons());
                        break;
                }
            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new() { new KeyboardButton { Text = "I am sad(" }, new KeyboardButton { Text = "I'm fine, you're a good bot!" } },
                    new() { new KeyboardButton { Text = "I'm bored"}, new KeyboardButton { Text = "Cute sticker"} },
                }
            };
        }
    }
}
