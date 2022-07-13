using ArtBloger.Data.Abstract;
using ArtBloger.Data.Concrete;
using ArtBloger.Data.Concrete.EntityFramework.Contexts;
using ArtBloger.Services.Abstract;
using ArtBloger.Services.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? 
        throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)); ;

//services-dependency injection-UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IArticleService,ArticleManager>();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); 
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//admin area routing
app.MapAreaControllerRoute(
    name: "AdminArea",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
