using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interface;
using ServiceLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//This allow to refresh view while running project
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(options =>
    options.JsonSerializerOptions.PropertyNamingPolicy = null);


//----------------------------------------------------------------------------------------
//Code required for session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromDays(3);
    options.Cookie.HttpOnly = true;
    // Make the session cookie essential
    options.Cookie.IsEssential = true;
});
//Code required for session END
//----------------------------------------------------------------------------------------


builder.Services.Configure<CookiePolicyOptions>(options =>
{
    //Auto Generated
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

string connectionString = builder.Configuration["ConnectionStrings:DemoDBConnection"];



//Configure basic authentication - only for cookie authentication, not for Identity.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(option =>
{
    option.LoginPath = "/Account/Login";
    option.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddHttpContextAccessor();


//ElmahCore for Error Logging
builder.Services.AddElmah<SqlErrorLog>(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString("DemoDBConnection");

    //To dsplay error log only login user, uncomment bwlow line.
    //options.OnPermissionCheck = context => context.User.Identity.IsAuthenticated;
});


//-------------------------------------------------DI-----------------------------------------------
//Services
builder.Services.AddTransient<ICommonService>(x => new CommonService(connectionString));
builder.Services.AddTransient<IUserService>(x => new UserService(connectionString));

//-------------------------------------------------DI END-------------------------------------------


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseElmah();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
