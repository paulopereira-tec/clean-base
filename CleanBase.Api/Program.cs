using CleanBase.Api.Hubs;
using CleanBase.Api.Services;
using CleanBase.Business.Features.ToDoItems.CreateToDoItem;
using CleanBase.Business.Interfaces;
using CleanBase.Business.Jobs;
using CleanBase.Domain.Interfaces;
using CleanBase.Infrastructure.Data;
using CleanBase.Repository.Repositories;
using FluentValidation;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Adiciona serviços ao container.

// 1. Controller and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanBase API", Version = "v1" });
  // Enable XML Comments
  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  if (File.Exists(xmlPath))
  {
    c.IncludeXmlComments(xmlPath);
  }
});

// 2. Database (In-Memory for this template, change to SQL Server as needed)
// Banco de dados (Em memória para este template, mude para SQL Server conforme necessário)
// builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("CleanBaseDb"));

// 3. MediatR
// Registra o MediatR procurando handlers no assembly de CleanBase.Business
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateToDoItemHandler).Assembly));

// 4. FluentValidation
// Registra validadores automaticamente
builder.Services.AddValidatorsFromAssembly(typeof(CreateToDoItemValidator).Assembly);

// 5. Repositories and Services (DI)
// Repositórios e Serviços (Injeção de Dependência)
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<INotifier, NotifierService>();
builder.Services.AddTransient<MaintenanceJob>(); // Job should be transient / Job deve ser transient

// 6. SignalR
builder.Services.AddSignalR();

// 7. Hangfire (Background Jobs)
// Configuração do Hangfire com armazenamento em memória
builder.Services.AddHangfire(config => config
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseMemoryStorage());

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Configura o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map Controllers
app.MapControllers();

// Map SignalR Hub
app.MapHub<NotificationHub>("/notificationHub");

// Configure Hangfire Dashboard
app.UseHangfireDashboard();

// Schedule a Recurring Job
// Agenda um job recorrente
RecurringJob.AddOrUpdate<MaintenanceJob>("maintenance-job", job => job.Execute(), Cron.Minutely);

Console.WriteLine("Application Started / Aplicação Iniciada");

app.Run();
