using SwimmingApp.DAL.Core;
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
using SwimmingApp.DAL.Repositories.TrainingDateService;
using SwimmingApp.BL.Managers.TrainingDateManager;

internal class Program
{

    public void ConfigureServices(IServiceCollection services) { }
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
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

        services.AddAuthentication(options => 
        { 
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
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

        services.AddControllers();

        services.AddSingleton<DapperContext>();

        services.AddScoped<IDbService, DbService>();

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

        services.AddScoped<ITrainingDateService, TrainingDateService>();
        services.AddTransient<TrainingDateManager>();

        services.AddCors(p => p.AddPolicy("corsapp", builder =>
        {
            builder.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }));

        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI(v1)");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseCors("corsapp");

        app.MapControllers();
   
        app.Run();

    }
}
