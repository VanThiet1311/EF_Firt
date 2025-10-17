using MiniEfApi.Services;
var builder = WebApplication.CreateBuilder(args);

var startup = new MiniEfApi.Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
             .AllowAnyOrigin()  
            .AllowAnyHeader()
            .AllowAnyMethod()

    );
});
// register CustomerService
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<CustomerService>();

// add Controllers
builder.Services.AddControllers();


var app = builder.Build();
app.UseCors("AllowFrontend");
startup.Configure(app);

app.Run();
