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
using SwimmingApp.BL.Managers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SwimmingApp.DAL.Repositories.MemberService;
using SwimmingApp.BL.Managers.MemberManager;
using SwimmingApp.DAL.Repositories.UserRegisterService;
using SwimmingApp.DAL.Repositories.UserService;
using SwimmingApp.BL.Managers.UserRegisterManager;
using SwimmingApp.BL.Managers.UserManager;
using SwimmingApp.DAL.Contex;
using SwimmingApp.DAL.Repositories.UserLoginService;
using SwimmingApp.BL.Managers.UserLoginManager;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SwimmingApp.DAL.Repositories.TrainingService;
using SwimmingApp.BL.Managers.TrainingManager;
using SwimmingApp.DAL.Repositories.AttendanceService;
using SwimmingApp.BL.Managers.AttendanceManager;

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

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standard Authorization header using the Bearer scheme",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"])),
             ValidateIssuer = false,
             ValidateAudience = false
         };
     });

        services.AddLogging();

        services.AddControllers();

        services.AddCors(p => p.AddPolicy("corsapp", builder =>
        {
            builder.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }));


        services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

        //services.AddDbContext<DataContex>(c => c.UseNpgsql(builder.Configuration.GetConnectionString("SwimmingAplication")));
        //services.AddScoped<IDataContex>(provider => provider.GetService<DataContex>());
        //services.AddScoped<IRepositroy, Respository>();

        services.AddSingleton<DapperContext>();

        services.AddScoped<IDbService, DbService>();

        services.AddScoped<IMemberService, MemberService>();
        services.AddTransient<MemberManager>();

        services.AddScoped<IUserService, UserService>();
        services.AddTransient<UserManager>();

        services.AddScoped<IUserRegisterService, UserRegisterService>();
        services.AddTransient<UserRegisterManager>();

        services.AddScoped<IUserLoginService, UserLoginService>();
        services.AddTransient<UserLoginManager>();

        services.AddScoped<ITrainingService, TrainingService>();
        services.AddTransient<TrainingManager>();

        services.AddScoped<IAttendanceService, AttendanceService>();
        services.AddTransient<AttendanceManager>();


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
