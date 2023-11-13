using ApiExamen.Context;
using ApiExamen.Operaciones;
using Examen.Operaciones;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<AutoresDAO>();
builder.Services.AddScoped<LibrosDAO>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();  
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()); 
builder.Services.AddConnections();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddDbContext<LibreriaContext>();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.MapControllers();
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.Run();


