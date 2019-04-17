namespace KudosSlackbot.Presentation.Api
{
    using System.IO;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.PlatformAbstractions;

    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerUI;

    public partial class Startup
    {
        /// <summary>
        /// Configures the swagger.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureSwagger(IServiceCollection services)
        {
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            //});
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", GetApiInfo("v1"));

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "kudos-slackbot.xml");
                if (File.Exists(filePath))
                {
                    c.IncludeXmlComments(filePath);
                }

                //if (Settings.EnableAuthentication)
                //{
                //    var identityUrl = Settings.IdentityServiceUrl;
                //    c.AddSecurityDefinition("client_credentials", new OAuth2Scheme
                //    {
                //        Flow = "application",
                //        AuthorizationUrl = identityUrl + "connect/authorize",
                //        TokenUrl = identityUrl + "connect/token",
                //        Scopes = new Dictionary<string, string>
                //    {
                //            { Settings.RequiredScope, "Access to Kudos Slack bot" },
                //    }
                //    });

                //    // default authorization flow
                //    var security = new Dictionary<string, IEnumerable<string>>
                //    {
                //            { "client_credentials", new string[] { Settings.RequiredScope } },
                //    };
                //    c.AddSecurityRequirement(security);

                //    c.OperationFilter<MakeFarfetchOperation>();
                //    c.DocumentFilter<MakeFarfetchDocument>();
                //}
            });
        }

        /// <summary>
        /// Configures the swagger.
        /// </summary>
        /// <param name="app">The application.</param>
        public void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger(c => { c.RouteTemplate = "{documentName}/swagger.json"; });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/v1/swagger.json", "KUDOS Slackbot");
                c.SupportedSubmitMethods(new[] { SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Patch, SubmitMethod.Delete });
                c.RoutePrefix = "swagger/api";
                c.EnableValidator(null);
            });
        }

        private Info GetApiInfo(string version)
        {
            return new Info
            {
                Version = version,
                Title = "KUDOS Slackbot",
                Description = "Kudos slack bot API.",
                Contact = new Contact
                {
                    Name = "José Sousa",
                    Email = "zpedro_s@hotmail.com"
                }
            };
        }
    }
}