using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using Quartz;
using Solar.Application.BackgroundJob;
using Solar.Infrastructure.Context;
using Solar.Infrastructure.IOC;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Quartz
builder.Services.AddQuartz(configure =>
{
    configure.UseMicrosoftDependencyInjectionJobFactory();

    var jobKey = new JobKey(nameof(ProcessRequest));

    configure
    .AddJob<ProcessRequest>(jobKey)
    .AddTrigger(
            trigger => trigger.ForJob(jobKey).WithSimpleSchedule(
                schedule => schedule.WithIntervalInSeconds(5).RepeatForever()));
});

builder.Services.AddQuartzHostedService(configure =>
{
    configure.WaitForJobsToComplete = true;
});

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = "http://localhost:7141",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OurVerifyAmini"))
        };
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCors", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .Build();
    });
});
//Database
builder.Services.AddDbContext<SolarDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SolarDbConnectionString")));

//Container
RegisterServices(builder.Services);
void RegisterServices(IServiceCollection services)
{
    DependencyContainer.RegisterService(services); ;
}

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
