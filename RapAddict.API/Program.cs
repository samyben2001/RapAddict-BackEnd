
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using RapAddict.API.Infrastructure.Token;
using RapAddict.Domain.Repositories;
using RapAddict.Domain.Services;
using System.Data.Common;
using System.Text;

namespace RapAddict.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Cors
            string corsPolicyName = "TechnoCors";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName,
                    policy =>
                    {
                        policy.AllowAnyOrigin();
                        policy.AllowAnyMethod();
                        policy.AllowAnyHeader();
                    });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configuration JWT Token (need Microsoft.AspNetCore.Authentication.JwtBearer) ([Authorize] sur les actions du controller)
            JwtOptions jwtOptions = new JwtOptions("https://localhost:7252", "https://localhost:7252", "7debfdf6dc7605271abefb340855667ac90ec7aca2ca6ecb225759cd4ed1b328");

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecurityKey))
                    };
                });

            // Injections de dépendances
            builder.Services.AddSingleton(sp => jwtOptions);
            builder.Services.AddTransient<DbConnection>(sp => new SqlConnection(@"Data Source=SAM_LAPTOP;Initial Catalog=RapAddict;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;"));

            builder.Services.AddScoped<IUserRepository, UserService>();
            builder.Services.AddScoped<IPersonRepository, PersonService>();
            builder.Services.AddScoped<IVideoRepository, VideoService>();
            builder.Services.AddScoped<IStreamingPlatformRepository, StreamingPlatformService>();
            builder.Services.AddScoped<ISocialMediaRepository, SocialMediaService>();
            builder.Services.AddScoped<IAlbumRepository, AlbumService>();
            builder.Services.AddScoped<ITrackRepository, TrackService>();
            builder.Services.AddScoped<ITokenRepository, TokenService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(corsPolicyName);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
