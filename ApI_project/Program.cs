using Ataal.BL;
using Ataal.BL.Managers.Customer;
using Ataal.DAL.Data;
using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Identity;
using Ataal.DAL.Repos.Customer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace ApI_project
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

            #region DB
            var connectionString = builder.Configuration.GetConnectionString("connection");
            builder.Services.AddDbContext<AtaalContext>(options
                => options.UseSqlServer(connectionString));
            #endregion


            #region Identity Managers

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;

            })
                .AddEntityFrameworkStores<AtaalContext>();

            #endregion

            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                //Used Authentication Scheme
                options.DefaultAuthenticateScheme = "Authentication";

                //Used Challenge Authentication Scheme
                options.DefaultChallengeScheme = "Authentication";
            })
                .AddJwtBearer("Authentication", options =>
                {
                    var secretKeyString = builder.Configuration.GetValue<string>("SecretKey")!;
                    var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
                    var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = secretKey,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            #endregion

            #region Authorization

            builder.Services.AddAuthorization(options =>
            {

                options.AddPolicy(Constants.Roles.Admin, policy => policy
                    .RequireClaim(ClaimTypes.Role, Constants.Roles.Admin)
                    .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy(Constants.Roles.Customer, policy => policy
                    .RequireClaim(ClaimTypes.Role, Constants.Roles.Customer));

                options.AddPolicy(Constants.Roles.Technical, policy => policy
                    .RequireClaim(ClaimTypes.Role, Constants.Roles.Technical));
            });

            #endregion

            #region Repos
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            
            #endregion

            #region Managers
            builder.Services.AddScoped<ICustomerManager, CustomerManager>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AtaalContext>();
                SeedClass.Initialize(context);
            }

            app.Run();
        }
    }
}