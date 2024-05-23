using ProjectFitness.BL;
using ProjectFitness.DAL;
using ProjectFitness.DAL.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FitnessDbContext>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IManager, Manager>();

builder.Services.AddControllers().AddXmlSerializerFormatters();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();