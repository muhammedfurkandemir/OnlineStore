using OnlineStore.Utilities.EntityFreamwork;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Utilities.Helpers.FileHelper;
using Microsoft.AspNetCore.Identity;
using OnlineStore.Utilities.Helpers.EmailHelper;
using Microsoft.AspNetCore.Identity.UI.Services;
using OnlineStore.Utilities.Mernis;
using Microsoft.AspNetCore.Session;
using OnlineStore.DataAccess.Abstract;
using OnlineStore.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OnlineStoreContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>(options =>
options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<OnlineStoreContext>().AddDefaultTokenProviders();

builder.Services.AddRazorPages();//

builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderLineRepository, OrderLineRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IFileHelper, FileHelper>();
builder.Services.AddScoped<IEmailSender,EmailSender>();

builder.Services.AddSingleton<IUserService, KpsServiceAdapter>();

builder.Services.AddSession();

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

app.MapRazorPages();//

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
