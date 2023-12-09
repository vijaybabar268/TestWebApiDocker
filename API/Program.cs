// public class Program
// {
//     const string envName = "dev1";
//     public static void Main(string[] args)
//     {
//         CreateHostBuilder(args).Build().Run();
//     }

//     public static IHostBuilder CreateHostBuilder(string[] args)
//     {
//         return Host.CreateDefaultBuilder(args)
//             .ConfigureAppConfiguration((a, config) =>
//             {
//                 config.AddJsonFile($"appsettings{envName}.json");
//             });
//     }
// }



const string envName = "dev1";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appsettings = builder.Configuration.AddJsonFile($"appsettings{envName}.json", true, true);

var app = builder.Build();

var env = app.Configuration.GetSection("URLs").GetSection("env").Value;
var APIUrl = app.Configuration.GetSection("URLs").GetSection("APIUrl").Value;

// Configure the HTTP request pipeline.
if (app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
