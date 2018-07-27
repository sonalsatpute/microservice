using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBroker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Service
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
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      Settings setting = new Settings("localhost")
      {
        AppId = "microservice-sample-dotnetcore",
        ExchangeName = "dev-exchange",
        UserName = "sonal",
        Password = "sonal",
        PrefetchCount = 3,
        Timeout = 10,
        VirtualHost = "/",
        PersistentMessages = true
      };
      services.AddTransient<IConnection>(s => new Connection(setting));

      // Register the Swagger generator, defining 1 or more Swagger documents
      // Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info
        {
          Version = "v1",
          Title = "Microservice Sample",
          Description = "A simple example of Microservice using dotnet core with RabbitMQ and Docker",
          TermsOfService = "None",
          Contact = new Contact
          {
            Name = "Sonal Satpute",
            Email = "sonal.satpute@gmail.com",
            Url = "https://twitter.com/sonalsatpute"
          },
          License = new License
          {
            Name = "Use under LICX",
            Url = "https://example.com/license"
          }
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
      // specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservice Sample V1");
        c.RoutePrefix = string.Empty;
      });

      app.UseMvc();
    }
  }
}
