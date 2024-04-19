using EmailSender.DataAccess.Data;
using EmailSender.DataAccess.Repositories;
using EmailSender.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DBCONTEXT

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//UNIT OF WORK
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//CORS
builder.Services.AddCors(opt=>
{
    opt.AddDefaultPolicy(opt =>
    {
        opt.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
    });
});
    

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

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
