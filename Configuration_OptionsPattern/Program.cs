using Configuration_OptionsPattern.Options;
using Configuration_OptionsPattern.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register options with validation
builder.Services.AddOptions<DatabaseSettings>()
    .Bind(builder.Configuration.GetSection("DatabaseSettings"))
    .ValidateDataAnnotations()
    .Validate(s => !string.IsNullOrWhiteSpace(s.ConnectionString) && !string.IsNullOrWhiteSpace(s.Provider), "Database settings are required.")
    .ValidateOnStart();
builder.Services.AddOptions<EmailApiSettings>()
    .Bind(builder.Configuration.GetSection("EmailApiSettings"))
    .ValidateDataAnnotations()
    .Validate(s => !string.IsNullOrWhiteSpace(s.Endpoint) && !string.IsNullOrWhiteSpace(s.ApiKey), "Email API settings are required.")
    .ValidateOnStart();
builder.Services.AddOptions<JobSettings>()
    .Bind(builder.Configuration.GetSection("JobSettings"))
    .ValidateDataAnnotations()
    .Validate(s => s.IntervalSeconds > 0, "Job interval must be positive.")
    .ValidateOnStart();

// Register services
builder.Services.AddScoped<IDatabaseService, DatabaseService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IJobService, JobService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
