using EventService;
using Ticket.Web;
using Ticket.Web.Interfaces;
using Ticket.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddGrpcClient<Events.EventsClient>(o => o.Address = new Uri(builder.Configuration["ApiConfigs:EventCatalog:Uri"]));
builder.Services.AddScoped<IEventCatalogService, EventCatalogService>();
builder.Services.AddSingleton<Settings>();

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
    pattern: "{controller=EventCatalog}/{action=Index}/{id?}");

app.Run();
