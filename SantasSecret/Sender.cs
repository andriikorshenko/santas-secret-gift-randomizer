using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace SantasSecret
{
    public class Sender
    {
        private readonly TelegramBotClient bot = 
            new(@"5911362108:AAEer6t-KFxmXHZArDxbak9nzDZLkuwdnmo"); 

        public async Task Send(Person person)
        {
            var updates = await bot.GetUpdatesAsync();
            if (updates == null)
            {
                throw new Exception("No subs");                
            }

            var personUpdate = updates.FirstOrDefault(u => u.Message.From.Username == person.Nickname);
            if (personUpdate == null)
            {
                throw new Exception($"No message from {person.Nickname}");
            }

            var chatId = personUpdate.Message.Chat.Id;
            await bot.SendTextMessageAsync(chatId, $"Ho-ho {person.Name}, your victim is {person.Target.Name}!" +
                $"Have fun and a happy New Year!");           
        }

        public async Task<int> GetOpenChatsQty()
        {
            var updates = await bot.GetUpdatesAsync();
            if (updates == null)
            {
                throw new Exception("No subs");
            }

            int numChats = updates.Count(u => u.Message != null);

            return numChats;
        }

        public async Task GetOpenChatsContent()
        {
            var updates = await bot.GetUpdatesAsync();
            if (updates == null)
            {
                throw new Exception("No subs");
            }

            foreach (var update in updates)
            {
                if (update.Type == UpdateType.Message)
                {
                    var message = update.Message;
                    Console.WriteLine($"Received message from {message.From.Username}: {message.Text}");
                }
            }
        }
    } 
}
