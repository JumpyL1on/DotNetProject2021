using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Backend.Presentation
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
            /*var bot = host.Services.GetRequiredService<IBotClient>();
            var request =
                new SetWebhook(
                    new Uri("https://aca889be2b94.ngrok.io/api/bot/1699936465:AAEmc-S8YUcrkFzI8Lxi97x4q82btJkrS-s"));
            var response = await bot.HandleAsync(request);
            if (response.Ok)
                await host
                    .RunAsync()
                    .ContinueWith(async _ => await bot.HandleAsync(new DeleteWebhook()));
            else
                Console.WriteLine(response.Failure.Description);*/
        }

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}