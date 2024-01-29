using API;
using API.Data;
using API.Services;
using API.Validators;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        return HttpErrors.BadRequest(data: "Invalid data model");
                    };
                });
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<StoreDB>();

//SERVICES
builder.Services.AddScoped<IProductService, ProductService>();

//VALIDATORS
builder.Services.AddScoped<IProductValidator, ProductValidator>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.MapControllers();
app.UseExceptionHandler("/errors/500");
app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.Run();