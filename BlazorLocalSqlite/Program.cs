using BlazorLocalSqlite;
using BlazorLocalSqlite.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddDbContextFactory<ClientSideDbContext>(
    options => options.UseSqlite($"Filename={DataSynchronizer.SqliteDbFilename}"));
builder.Services.AddScoped<DataSynchronizer>();

await builder.Build().RunAsync();
