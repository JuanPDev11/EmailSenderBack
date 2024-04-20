using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using EmailSender.DataAccess.Data;
using EmailSender.DataAccess.Repositories;
using EmailSender.DataAccess.Repositories.IRepositories;
using Microsoft.AspNetCore.Builder;
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

////AWS S3
AWSOptions awsOptions = new AWSOptions
{
    Profile = "default",
    Region = RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"]),
    Credentials = new BasicAWSCredentials(builder.Configuration["AWS:AccessKey"], builder.Configuration["AWS:SecretKey"])
};
builder.Services.AddDefaultAWSOptions(awsOptions);


//builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<Amazon.S3.IAmazonS3>(awsOptions);



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
