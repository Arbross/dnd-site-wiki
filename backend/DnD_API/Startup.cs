using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using Infrastracture.Extentions;
using ApplicationCore.Extentions;
using DnD_API.Helpers;
using Microsoft.AspNetCore.Authentication.Certificate;
using ApplicationCore.Helpers;
using Microsoft.OpenApi.Models;

namespace DnD_API
{
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
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<DatabaseContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("LocalConnStr"), options => options.EnableRetryOnFailure());
            });

            services.AddAuthorization();

            services.AddResponseCaching();

            services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));
            services.AddCustomServices();
            services.AddIdentity();
            services.AddJwtAuthentication(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DnD_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DnD_API v1"));
            }

            app.UseCors(cfg =>
            {
                cfg.AllowAnyOrigin();
                cfg.AllowAnyMethod();
                cfg.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
