using Ataal.BL;
using Ataal.BL.Managers.Customer;
using Ataal.BL.Managers.Section;
using Ataal.BL.Managers.problem;
using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Identity;
using Ataal.BL.Managers.Identity;
using Ataal.BL.Mangers.technical;
using Ataal.BL.Mangers.Technical;

using Ataal.DAL.Data.Repos;
using Ataal.DAL.Data.Repos.Technical_Repo;
using Ataal.DAL.Repos.Section;
using Ataal.DAL.Repos.problem;
using Ataal.DAL.Repos.Reviews;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Ataal.DAL.Repos.customer;
using Ataal.DAL.Data;
using Ataal.DAL.Repos.recommendation;
using Ataal.BL.Managers.recommendation;
using Ataal.BL.Managers.review;
using Stripe;
using Stripe_Payments_Web_Api.Application;
using Stripe_Payments_Web_Api.Contracts;
using System.Configuration;
using Stripe_Payments_Web_Api;
using Ataal.DAL.Repos.keywords;
using Ataal.BL.Managers.keywords;

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

            

            builder.Services.AddStripeInfrastructure(builder.Configuration);

            #region Cors

            var corsPolicy = "AllowAll";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsPolicy, p => p.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            #endregion

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

            builder.Services.AddScoped<ISectionRepo, SectionRepo>();
            builder.Services.AddScoped<ITechnicalRepo, TechnicalRepo>();


            builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
            builder.Services.AddScoped<IProblemRepo, ProblemRepo>();
            builder.Services.AddScoped<IRecommendationRepo, RecommendationRepo>();
            builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
            builder.Services.AddScoped<IKeywordsRepo, KeywordsRepo>();

            #endregion




            #region Manager
            builder.Services.AddScoped<ISectionManger, SectionManger>();
           

            builder.Services.AddScoped<ICustomerManager, CustomerManager>();


            builder.Services.AddScoped<ISectionManger, SectionManger>();

            builder.Services.AddScoped<IProblemManager, ProblemManager>();
            builder.Services.AddScoped<ItechnicalManger, TechnicalManger>();
            builder.Services.AddScoped<IIdentityManger, IdentityManager>();
            builder.Services.AddScoped<IRecommendationManager, RecommendationManager>();
            builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
            builder.Services.AddScoped<IReviewManager, ReviewManager>();
            builder.Services.AddScoped<IKeywordsManager, KeywordsManager>();



            #endregion






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(corsPolicy);
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();
          
            app.MapControllers();
            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<AtaalContext>();
            //    SeedClass.Initialize(context);
            //}

            app.Run();
        }
    }
}