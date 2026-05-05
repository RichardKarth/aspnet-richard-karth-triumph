using Infrastructure.Extensions;
using Application.Extensions;
using Infrastructure.Persistance;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;

});
builder.Services.AddSession();

builder.Services.AddApplication(builder.Configuration, builder.Environment);
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);

var app = builder.Build();

await PersistanceDatabaseInitializer.InitializeAsync(app.Services, app.Environment);

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();
app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
