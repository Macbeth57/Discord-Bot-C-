using Discord;
using Discord.WebSocket;

namespace NomDuProjet
{
    class Program
    {
        private DiscordSocketClient _client;
        Random random = new Random();
        int kumideValue = default;

        static async Task Main(string[] args)
        {
            var program = new Program();
            await program.RunBotAsync();

        }

        public async Task RunBotAsync()
        {
            
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info,
                GatewayIntents = GatewayIntents.Guilds | GatewayIntents.GuildMessages | GatewayIntents.MessageContent
                
            });

            _client.Log += LogAsync;
            _client.MessageReceived += MessageReceivedAsync;

            string token = "MTE5MDM0OTQ3MjQ1OTM5MTExNw.Ga_1sj.FPiz1vMJgTkUKDoFKPMerbQ00nppzJl9c9nBMU";
            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {

            if (!(message is SocketUserMessage userMessage) || userMessage.Author.IsBot)
                return;

            Console.WriteLine($"Message reçu : {userMessage.Content}");

            if (userMessage.Content.ToLower() == "!ping")
            {
                await message.Channel.SendMessageAsync("pong");
            }

            if (userMessage.Content.ToLower() == "!kumide")
            {
                kumideValue = random.Next(1,21);
                await message.Channel.SendMessageAsync(Convert.ToString(kumideValue));
            }

        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log);
            return Task.CompletedTask;
        }
    }
}
