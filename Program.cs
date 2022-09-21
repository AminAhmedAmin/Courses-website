using courseapp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddDbContext<coursedatabaseContext>
//    (a => a.UseSqlServer(builder.Configuration.GetConnectionString("DefouitConection")));

builder.Services.AddDbContext<coursedatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefouitConection") ?? throw new InvalidOperationException("Connection string 'DefouitConection' not found.")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
 
app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}"

//    );

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area=Admin}/{controller=Account}/{action=LogIn}/{id?}"
    );
});

app.Run();
