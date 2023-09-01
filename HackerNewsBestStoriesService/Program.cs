using HackerNewsBestStoriesService.HackerNewsClient;
using LazyCache;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Services;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IHackerNewsService, HackerNewsService> ();
builder.Services.AddSingleton<HackerNewsClient> ();
builder.Services.AddSingleton<IHackerNewsClient> (
    x => new CachedHackerNewsClient(x.GetRequiredService<HackerNewsClient>(), x.GetRequiredService<IAppCache>()));
builder.Services.AddHttpClient("HackerNews", client =>
{
    var baseAddress = builder.Configuration.GetValue<string>("HackerNewsBaseAddress");
    client.BaseAddress = new Uri(baseAddress);
})
.ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
{
    MaxConnectionsPerServer = builder.Configuration.GetValue<int>("HackerNewsRequestConnections")
})
.AddTransientHttpErrorPolicy(policy =>  policy.WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 4)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLazyCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
