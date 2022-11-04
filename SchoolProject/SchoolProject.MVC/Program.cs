using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using SchoolProject.Models;
using SchoolProject.Data;
using SchoolProject.Services.Validators;
using SchoolProject.Services.Interfaces;
using SchoolProject.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var env = hostingContext.HostingEnvironment;

    config.SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) //load base settings
            .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true) //load local settings
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true) //load environment settings
            .AddEnvironmentVariables();
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = true;
});
builder.Services.AddScoped<IValidator<School>, SchoolValidator>();
builder.Services.AddScoped<IValidator<Course>, CourseValidator>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<UserViewModel>, UserViewModelValidator>();

builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<SchoolProjectDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:SchoolProjectConnection"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
