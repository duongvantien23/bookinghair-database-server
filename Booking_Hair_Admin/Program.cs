using DataAccessLayer;
using BusinessLayer;
using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DataAcessLayer.InterFace;
using DataAcessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<ICustomerBusiness, CustomerBusiness>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICitiesBusiness, CitiesBusiness>();
builder.Services.AddTransient<ICitiesRepository, CitiesRepository>();
builder.Services.AddTransient<IDistrictsBusiness, DistrictsBusiness>();
builder.Services.AddTransient<IDistrictsRepository, DistrictsRepository>();
builder.Services.AddTransient<IServiceBusiness, ServiceBusiness>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IServiceDetailBusiness, ServiceDetailBusiness>();
builder.Services.AddTransient<IServiceDetailRepository, ServiceDetailRepository>();
builder.Services.AddTransient<ISalonBusiness, SalonBusiness>();
builder.Services.AddTransient<ISalonRepository, SalonRepository>();
builder.Services.AddTransient<IHairStylistBusiness, HairStylistBusiness>();
builder.Services.AddTransient<IHairStylistRepository,HairStylistRepository>();
builder.Services.AddTransient<IWorkingHourBusiness, WorkingHourBusiness>();
builder.Services.AddTransient<IWorkingHourRepository, WorkingHourRepository>();
builder.Services.AddTransient<ITimeSlotBusiness, TimeSlotBusiness>();
builder.Services.AddTransient<ITimeSlotRepository, TimeSlotRepository>();
builder.Services.AddTransient<ICustomerReviewBusiness, CustomerReviewBusiness>();
builder.Services.AddTransient<ICustomerReviewRepository, CustomerReviewRepository>();
builder.Services.AddTransient<IPromotionBusiness, PromotionBusiness>();
builder.Services.AddTransient<IPromotionRepository, PromotionRepository>();

builder.Services.AddCors(option =>
{
    option.AddPolicy("MyCors", build =>
    {
        build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
