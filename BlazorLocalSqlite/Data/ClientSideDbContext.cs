using Microsoft.EntityFrameworkCore;

namespace BlazorLocalSqlite.Data;

internal class ClientSideDbContext : DbContext
{
    public DbSet<Forecast> Forecasts { get; set; } = default!;

    public ClientSideDbContext(DbContextOptions<ClientSideDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Forecast>(entity =>
        {
            entity.ToTable("Forecasts");
            entity.HasKey(e => e.Date);
        });

        modelBuilder.Entity<Forecast>().HasData(InitForecasts());
    }

    private static List<Forecast> InitForecasts()
    {
        return new List<Forecast>
        {
            new()
            {
                Date=new DateTime(2020,5,6),
                TemperatureC= 1,
                Summary="Freezing",
            },
            new()
            {
                Date=new DateTime(2020,5,7),
                TemperatureC= 14,
                Summary="Bracing",
            },
            new()
            {
                Date=new DateTime(2020,5,8),
                TemperatureC= -3,
                Summary="Chilly",
            },
        };
    }
}
