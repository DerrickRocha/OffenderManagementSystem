using Microsoft.EntityFrameworkCore;
using OffenderManagementSystem.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register your DbContext here before building the application
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class YourDbContext : DbContext
{
    public YourDbContext(DbContextOptions<YourDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Offender> Offenders { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuring User to Offender relationship
        modelBuilder.Entity<User>()
            .HasMany(u => u.Offenders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuring User to Report relationship
        modelBuilder.Entity<User>()
            .HasMany(u => u.Reports)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuring Offender to Report relationship
        modelBuilder.Entity<Offender>()
            .HasMany(o => o.Reports)
            .WithOne(r => r.Offender)
            .HasForeignKey(r => r.OffenderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Explicitly disabling cascading deletes on Reports
        modelBuilder.Entity<Report>()
            .HasOne(r => r.Offender)
            .WithMany(o => o.Reports)
            .HasForeignKey(r => r.OffenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Report>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reports)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}