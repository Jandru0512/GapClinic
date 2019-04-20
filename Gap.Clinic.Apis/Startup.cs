namespace Gap.Clinic.Apis
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Gap.Clinic.Common;
    using Gap.Clinic.Configurations;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    public class Startup
    {
        #region Constructor
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Private Attributes
        private readonly IConfiguration _configuration;
        #endregion

        #region Public Methods
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option => option.AddPolicy("All", constructor =>
            {
                constructor.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
            }));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services.RegisterServices(_configuration);
            ConfigureAuthentication(services);
            Configuration.ConfigurationOptions = _configuration;
        }

        public void Configure(IApplicationBuilder application, IHostingEnvironment hosting)
        {
            if (hosting.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }

            application.UseCors("All");
            application.UseMvc();
        }
        #endregion

        #region Private Methods
        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(AddBearer);
        }

        private void AddBearer(JwtBearerOptions options)
        {
            byte[] key = Encoding.ASCII.GetBytes(_configuration["Authentication:SecretKey"]);
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = AuthenticationFailed
            };
        }

        private Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
        #endregion
    }
}