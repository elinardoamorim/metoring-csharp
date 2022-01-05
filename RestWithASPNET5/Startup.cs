using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using RestWithASPNET5.Models.Context;
using RestWithASPNET5.Business;
using RestWithASPNET5.Business.Implementations;
using Microsoft.Net.Http.Headers;
using RestWithASPNET5.Repositories.Generic;
using System.Reflection;
using System.IO;
using RestWithASPNET5.Hypermedia.Filters;
using RestWithASPNET5.Hypermedia.Enricher;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Repositories;
using RestWithASPNET5.Repositories.Implementations;
using RestWithASPNET5.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using RestWithASPNET5.Services;
using RestWithASPNET5.Services.impl;
using RestWithASPNET5.Repositories.impl;

namespace RestWithASPNET5
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var tokenConfigurations = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfiguration"))
                .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = tokenConfigurations.Issuer,
                   ValidAudience = tokenConfigurations.Audience,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
               };
           });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddControllers();

            //Configuração com banco de dados
            var connection = Configuration.GetConnectionString("MyConnection");
            services.AddDbContext<SqlServerContext>(options =>
                options.UseSqlServer(connection));

            if (Environment.IsDevelopment())
            {
                MigrateDataBase(connection);
            }

            services.AddMvc(option =>
            {
                option.RespectBrowserAcceptHeader = true;
                option.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                option.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
            .AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContenResponseEnricherList.Add(new PersonEnricher());
            filterOptions.ContenResponseEnricherList.Add(new BookEnricher());
            filterOptions.ContenResponseEnricherList.Add(new AuthorEnricher());
            services.AddSingleton(filterOptions);

            //Swagger
            services.AddSwaggerGen(d =>
            {
                d.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{ Title = "Swagger", Version = "v1" });


                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                d.AddSecurityDefinition("Bearer", jwtSecurityScheme);
                d.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                d.IncludeXmlComments(xmlPath);
            });


            //Versioning API
            services.AddApiVersioning();

            //Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();

            services.AddScoped<IBookBusiness, BookBusinessImplementation>();

            services.AddScoped<IAuthorBusiness, AuthorBusinessImplementation>();

            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

            services.AddScoped<IBookRepository, BookRepositoryImplementation>();

            services.AddScoped<IAuthorRepository, AuthorRepositoryImplementation>();
            
            services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();

            services.AddScoped<IUserBusiness, UserBusinessImplementation>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddTransient<ITokenService, TokenService>();

            services.AddScoped<IGenericBusiness<PersonVO>, PersonBusinessImplementation>();

            services.AddScoped<IGenericBusiness<BookVO>, BookBusinessImplementation>();
            
            services.AddScoped<IGenericBusiness<AuthorVO>, AuthorBusinessImplementation>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger V1");
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller}");
            });
        }
        private void MigrateDataBase(string connection)
        {
            try
            {
                var evolveConnection = new SqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> {"db/migrations", "db/dataset"},
                    IsEraseDisabled = true
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }
    }
}
