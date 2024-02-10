var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var secrets = new Secret();

app.Configuration.GetSection("Secrets").Bind(secrets);
var connectionString = app.Configuration.GetConnectionString("DefaultConnection");

app.MapGet("/", () => new {
    ConnectionString = connectionString,
    Secrets = secrets
});

app.Run();
