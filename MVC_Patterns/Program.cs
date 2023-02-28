var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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

app.MapControllerRoute(
    name: "Pages",
    pattern: "pages",
    defaults: new { controller = "Pages", action = "Index" });

app.MapControllerRoute(
    name: "pages_new",
    pattern: "pages/new",
    defaults: new { controller = "Pages", action = "New" });

app.MapControllerRoute(
    name: "pages_create",
    pattern: "pages/create",
    defaults: new { controller = "Pages", action = "CreatePage" });

app.MapControllerRoute(
    name: "privacy",
    pattern: "privacidade",
    defaults: new { controller = "Home", action = "Privacy" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
