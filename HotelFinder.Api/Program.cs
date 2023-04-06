using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddSingleton<IHotelService, HotelManager>();
builder.Services.AddSingleton<IHotelRepository, HotelRepository>();
builder.Services.AddSwaggerDocument(config => config.PostProcess = doc =>
{
    doc.Info.Title = "Otel Bulma Servisi";
    doc.Info.Version = "1.7.1";
    doc.Info.Contact = new NSwag.OpenApiContact()
    {
        Name = "Oguz Evrensel",
        Email = "oevrensel@gmail.com",
        Url = "oguzevrensel.com"
    };

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseOpenApi();
app.UseSwaggerUi3();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.MapRazorPages();

app.Run();
