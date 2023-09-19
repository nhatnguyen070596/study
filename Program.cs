global using Microsoft.AspNetCore.Mvc;
global using study.Models;
global using Microsoft.EntityFrameworkCore;
global using study.Utility;
using study.Repositories;
using study.Repositories.Interface;
using study.Strategies.Shipping.Interface;
using study.Strategies.Shipping.Context;
using study.Services.Interface;
using study.Services;
using StackExchange.Redis;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddScoped<ITeamRepository, TeamRepository>();
        builder.Services.AddScoped<ITeamService, TeamService>();

        builder.Services.AddScoped<IShippingContext, ShippingContext>();
        builder.Services.AddScoped<IShippingService, ShippingService>();
        builder.Services.AddScoped<IShippingRepository, ShippingRepository>();

        builder.Services.AddSingleton<IConnectionMultiplexer>(option =>
            ConnectionMultiplexer.Connect("127.0.0.1:6379,password=visaothe13,defaultDatabase=0")
        );
        builder.Services.AddScoped<IRedisRepository, RedisRepository>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();


        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddDbContext<TestDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
        // Configure the HTTP request pipeline.

        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy(name: "CorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();


        app.UseCors("CorsPolicy");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();


    }
}

