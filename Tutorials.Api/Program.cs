using Microsoft.EntityFrameworkCore;
using Tutorial.Infstructures.Interfaces;
using Tutorial.Infstructures.Repository;
using Tutorial.Infstructures.UnitOfWorks;
using Tutorials.Data.Context;
using AutoMapper;
using Tutorials.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Tutorials.Api.Mapper;


namespace Tutorials.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<TutorialDbContext>(Options => Options
            .UseSqlServer(builder.Configuration.GetConnectionString("Data")));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
            builder.Services.AddAutoMapper(typeof(UserProfile));
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TutorialDbContext>();

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
            app.MapControllers();
        }
    }
}