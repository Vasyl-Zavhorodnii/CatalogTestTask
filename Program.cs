using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();   
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CatalogDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddMvc().AddRazorPagesOptions(options => {
    options.Conventions.AddPageRoute("/GetCatalog", "");
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
 //   app.UseExceptionHandler("/Error");
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
               name: "CreatingDigitalImages",
               pattern: "CreatingDigitalImages/{controller=Home}/{action=Index}/{id?}");
});


var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    context.Database.Migrate();
    DbInitializer.Initialize(context);
}
catch (Exception ex )
{
    logger.LogError(ex, "a problem occured during migration");
}

app.Run();
