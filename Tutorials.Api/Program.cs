using System;
using System.Net.NetworkInformation;
using System.Buffers;
using System.Runtime.InteropServices;
using System.Reflection.PortableExecutable;
using Microsoft.EntityFrameworkCore;
using Tutorial.Infstructures.Interfaces;
using Tutorial.Infstructures.Repository;
using Tutorial.Infstructures.UnitOfWorks;
using Tutorials.Data.Context;
using AutoMapper;
using Tutorials.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Tutorials.Api.Mapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;


namespace Tutorials.Api
{
    public class Program
    {
        private static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
           Configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddCors(option => option
            .AddDefaultPolicy(build => build.AllowAnyOrigin()
            .AllowAnyMethod().AllowAnyHeader()));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<TutorialDbContext>(Options => Options
            .UseSqlServer(builder.Configuration.GetConnectionString("Data")));


            builder.Services.AddScoped<UserManager<User>, UserManager<User>>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
            builder.Services.AddAutoMapper(typeof(UserProfile));
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TutorialDbContext>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }



            ).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))

                };

            });
            builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
    
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseCors();
            app.UseRouting();
           // app.UseHttpsRedirection();

           //app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}