using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"C:\Temp-keys"))
    .SetApplicationName("CookieApp");

builder.Services.AddAuthentication("Identity.Application").AddCookie("Identity.Application", opts =>
{
    opts.Cookie.Name = "AuthCookie";
    opts.Cookie.MaxAge = TimeSpan.FromMinutes(1);
    opts.LoginPath = "/Identity/Login";

    //opts.Cookie.MaxAge = new TimeSpan(00, 30, 00);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
