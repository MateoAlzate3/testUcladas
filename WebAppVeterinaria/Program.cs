using Microsoft.EntityFrameworkCore;
using WebAppVeterinaria.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Middleware
builder.Services.AddHttpContextAccessor();

// Agrega la configuración del DbContext con la cadena de conexión
builder.Services.AddDbContext<VeterinariaDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("VeterinariaDbConnection")));

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
