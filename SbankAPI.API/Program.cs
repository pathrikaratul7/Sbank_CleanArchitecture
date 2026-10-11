using SbankAPI.API;
using SbankAPI.API.ExceptionHandlers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddAPIDI(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// Add Exception Handlers
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Use Exception Handling Middleware
app.UseExceptionHandler();

app.MapSwagger();
app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
