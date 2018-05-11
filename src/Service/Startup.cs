using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBroker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

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
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();

      // app.Run(async (context) =>
      // {
      //     await context.Response.WriteAsync("Hello Pranal!");
      // });
    }
  }
}
