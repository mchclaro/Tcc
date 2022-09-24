using Api.Middlewares;
using Application.Aggregates.Business.Mappings;
using Data.Context;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure.FileService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System.Reflection;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddDbContextPool<DataContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
            );

// AutoMapper
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

// Register repositories
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddScoped<IBusinessPhotosRepository, BusinessPhotosRepository>();
builder.Services.AddScoped<IOpeningHoursRepository, OpeningHoursRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddTransient<IFileStorageService, LocalStorageService>();
builder.Services.AddTransient<IFileStorageServiceS3, CloudStorageService>();


// builder.Services.AddScoped<IMediator, Mediator>();
builder.Services.AddScoped<Mediator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        }
                    )
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm" });
                });

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TCC.API", Version = "v1" });
    c.CustomSchemaIds(type => type.FullName);
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Scheme = "Bearer",
    });
});
builder.Services.AddCors();

builder.Services.AddMvcCore()
                .AddRazorViewEngine()
                .AddRazorRuntimeCompilation()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = actionContext =>
                    {
                        var result = new Application.Result.StandardResult<object> { };
                        var errors = actionContext.ModelState.Values
                            .Where(v => v.Errors.Count > 0)
                            .SelectMany(v => v.Errors);
                        foreach (var error in errors)
                        {
                            result.AddError(Application.Result.Code.BadRequest, error.ErrorMessage);
                        };
                        var responseBody = result.GetResult().Body;
                        return new BadRequestObjectResult(responseBody);
                    };
                });
builder.Services.AddHttpContextAccessor();
builder.Services.AddHealthChecks();

var app = builder.Build();

IConfiguration configuration = app.Configuration;
IWebHostEnvironment hostEnvironment = app.Environment;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TCC.API v1"));
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));
app.UseCors(option => option.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
});

app.Run();
