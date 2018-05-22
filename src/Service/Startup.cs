using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBroker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Service
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
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
      services.AddTransient<IConnection>( s => new Connection(setting) );

      // Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "Microservice Sample", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        //app.UseDeveloperExceptionPage();
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

      
      // app.Run(async (context) =>
      // {
      //     await context.Response.WriteAsync("Hello Pranal!");
      // });
    }
  }
}
