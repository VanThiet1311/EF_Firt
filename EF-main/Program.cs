using MiniEfApi;

var builder = WebApplication.CreateBuilder(args);

// Khởi tạo Startup
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app);

app.Run();
