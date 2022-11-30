using ApiRest.Middlewares;
using ApiRest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<ITareasService,TareasService>();
builder.Services.AddScoped<ICategoriaService,CategoriaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
