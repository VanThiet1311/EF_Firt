using MiniEfApi.Services;
var builder = WebApplication.CreateBuilder(args);

var startup = new MiniEfApi.Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

// register CustomerService
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<CustomerService>();

// add Controllers
builder.Services.AddControllers();


var app = builder.Build();
startup.Configure(app);

app.Run();
