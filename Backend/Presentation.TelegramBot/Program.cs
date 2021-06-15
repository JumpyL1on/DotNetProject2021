using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bots;
using Telegram.Bots.Requests.Webhooks;

namespace Presentation.TelegramBot
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var bot = host.Services.GetRequiredService<IBotClient>();
            const string uri = "https://24c03687a56e.ngrok.io/api/bot";
            var request = new SetWebhook(new Uri(uri));
            var response = await bot.HandleAsync(request);
            if (response.Ok)
                await host.RunAsync().ContinueWith(async _ => await bot.HandleAsync(new DeleteWebhook()));
            else
                Console.WriteLine(response.Failure.Description);
        }

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}