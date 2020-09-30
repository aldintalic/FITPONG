using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FIT_PONG.Database;
using FIT_PONG.Services.BL;
using FIT_PONG.Services.Services;
using FIT_PONG.WebAPI;
using FIT_PONG.WebAPI.Security;
using Microsoft.AspNetCore.Authentication;
using FIT_PONG.Services.Services.Autorizacija;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using FIT_PONG.WebAPI.Filters;
using FIT_PONG.WebAPI.Services.Bazni;
using FIT_PONG.WebAPI.Hubs;
using FIT_PONG.Database.DTOs;

namespace FIT_PONG.WebAPI
{
    public class BasicAuthDocumentFilter : Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var securityRequirements = new Dictionary<string, IEnumerable<string>>()
        {
            { "basic", new string[] { } }  // in swagger you specify empty list unless using OAuth2 scopes
        };

            //swaggerDoc.SecurityRequirements = new[] { securityRequirements };
        }
    }


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.Filters.Add<Filterko>());
            services.AddControllers().AddNewtonsoftJson(opcije => {
                opcije.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header
                });
                c.DocumentFilter<BasicAuthDocumentFilter>();
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Basic"
                            }
                        }, new List<string>()
                    }
                });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<MyDb>(opcije => opcije.UseSqlServer(Configuration.GetConnectionString("docker"), b=>b.MigrationsAssembly("FITPONG.Database")));
            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(opcije =>
             {
                 opcije.Password.RequiredLength = 6;
                 opcije.Password.RequireUppercase = false;
                 opcije.Password.RequireNonAlphanumeric = false;
                 opcije.Password.RequireDigit = false;
                 opcije.SignIn.RequireConfirmedEmail = true;
             })
                .AddEntityFrameworkStores<FIT_PONG.Database.MyDb>()
                .AddDefaultTokenProviders();

            
            //fina gradska raja
            services.AddScoped<FIT_PONG.Services.BL.InitTakmicenja>();
            services.AddScoped<ISuspenzijaService, SuspenzijaService>();
            services.AddScoped<FIT_PONG.Services.BL.ELOCalculator>();
            services.AddScoped<FIT_PONG.Services.BL.Evidentor>();
            services.AddScoped<FIT_PONG.Services.BL.iEmailServis, FIT_PONG.Services.BL.FITPONGGmail>();
            services.AddScoped<FIT_PONG.Services.BL.TakmicenjeValidator>();

            //ciste puno linija koda, negdje i obraz!
            services.AddScoped<IFeedsService, FeedsService>();
            services.AddScoped<IReportsService, ReportsService>();
            services.AddScoped<IGradoviService, GradoviService>();
            services.AddScoped<IObjaveService, ObjaveService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IStatistikeService, StatistikeService>();
            services.AddScoped<iEmailServis, FITPONGGmail>();
            services.AddScoped<ITakmicenjeService, TakmicenjeService>();
            services.AddScoped<IPrijaveService, PrijaveService>();

            //combobox jarani
            services.AddScoped<IBaseService<FIT_PONG.SharedModels.KategorijeTakmicenja,object>,
                BaseService<SharedModels.KategorijeTakmicenja, Database.DTOs.Kategorija, object>>();
            
            services.AddScoped<IBaseService<FIT_PONG.SharedModels.VrsteTakmicenja, object>,
                BaseService<SharedModels.VrsteTakmicenja, Database.DTOs.Vrsta_Takmicenja, object>>();
            
            services.AddScoped<IBaseService<FIT_PONG.SharedModels.SistemiTakmicenja, object>,
                BaseService<SharedModels.SistemiTakmicenja, Database.DTOs.Sistem_Takmicenja, object>>();
            
            services.AddScoped<IBaseService<FIT_PONG.SharedModels.StatusiTakmicenja, object>,
                BaseService<SharedModels.StatusiTakmicenja, Database.DTOs.Status_Takmicenja, object>>();

            services.AddScoped<IBaseService<FIT_PONG.SharedModels.VrsteSuspenzija, object>,
                BaseService<SharedModels.VrsteSuspenzija, Database.DTOs.VrstaSuspenzije, object>>();

            //SIPA
            services.AddScoped<ITakmicenjeAutorizator, TakmicenjeAutorizator>();
            services.AddScoped<IUsersAutorizator, UsersAutorizator>();
            services.AddScoped<IGradoviAutorizator, GradoviAutorizator>();
            services.AddScoped<IObjaveAutorizator, ObjaveAutorizator>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            //{
            //    builder.AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .WithOrigins("http://localhost:4260")
            //        .AllowCredentials();
            //}));

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "";
            });

            app.UseRouting();

            //app.UseHttpsRedirection();



            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseCors();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("ChatHub");
            });

        }
    }
}
