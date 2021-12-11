using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Skype.Api.Hubs;
using Skype.Data;
using Skype.Data.Services;

namespace Skype.Api
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
      services.AddScoped((_) => new SkypeDbContext());
      services.AddScoped<UserService>();
      services.AddScoped<FriendService>();
      services.AddScoped<RoomService>();
      services.AddScoped<MessageService>();
      services.AddCors(options =>
      {
        options.AddDefaultPolicy(
            builder =>
            {
              builder.AllowAnyHeader()
                             .AllowAnyMethod()
                             .SetIsOriginAllowed((host) => true)
                             .AllowCredentials();
            });
      });
      services.AddControllers();
      services.AddSignalR();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Skype.Api", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skype.Api v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();
      app.UseCors();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapHub<ChatHub>("/hubs/chat");
      });
    }
  }
}
