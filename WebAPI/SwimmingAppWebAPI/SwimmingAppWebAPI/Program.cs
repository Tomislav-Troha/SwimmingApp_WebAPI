using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System.Data.Common;
using System.Data;
using System.Web.Http;
using Microsoft.AspNetCore.Hosting;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SwimmingApp.DAL.Core;
using SwimmingApp.DAL.Repositories.EmployeeService;
using SwimmingApp.BL.Managers;
using Microsoft.AspNetCore.Mvc.ViewComponents;

internal class Program
{

    public void ConfigureServices(IServiceCollection services) { }
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

       

        var services = builder.Services;

        
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();
        services.AddLogging();

       



        services.AddControllers();

        services.AddCors(c =>
        {
            c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader());
        });


        services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

        //services.AddDbContext<DataContex>(c => c.UseNpgsql(builder.Configuration.GetConnectionString("SwimmingAplication")));
        //services.AddScoped<IDataContex>(provider => provider.GetService<DataContex>());
        //services.AddScoped<IRepositroy, Respository>();

        services.AddScoped<IDbService, DbService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddTransient<EmployeeManager>();
       


        var app = builder.Build();


        HttpConfiguration config = new HttpConfiguration();
        config.MapHttpAttributeRoutes();

        app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = string.Empty;
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI(v1)");
        });

        app.UseDeveloperExceptionPage();

        app.UseRouting();
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        


        app.MapControllers();
     

        app.Run();



    }

 
      
    
}
