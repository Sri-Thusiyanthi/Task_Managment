
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.Data;

namespace TaskManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(Option=>
            {
            Option.JsonSerializerOptions.ReferenceHandler =System.Text.Json .Serialization.ReferenceHandler.IgnoreCycles;
                Option.JsonSerializerOptions.DefaultIgnoreCondition =
                System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;


            }
            );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<TaskContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

            builder.Services.AddCors(Option =>
                Option.AddPolicy("AllowAllOrigins",
                builder =>
                {


                    builder.AllowAnyOrigin()
                     .AllowAnyMethod()
                    .AllowAnyHeader();

                }));
               

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();

            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
