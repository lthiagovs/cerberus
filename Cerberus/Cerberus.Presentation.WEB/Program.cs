using Cerberus.Domain.ApiService.ApiService;
using Cerberus.Domain.ApiService.Interface;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(new RestClient(connection != null ? connection : ""));
builder.Services.AddScoped<IUserApiService, UserApiService>();
builder.Services.AddScoped<IComputerApiService, ComputerApiService>();
builder.Services.AddScoped<IComputerScriptApiService, ComputerScriptApiService>();
builder.Services.AddScoped<ILuaResultApiService, LuaResultApiService>();
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
