var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                      policy.WithOrigins("http://localhost:3000")
                      .AllowAnyHeader();
                    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

/*app.UseEndpoints(endpoints =>
{
  endpoints.MapGet("/WeatherForecast",
      context => context.Response.WriteAsync("WeatherForecast"))
      .RequireCors(MyAllowSpecificOrigins);

  endpoints.MapControllers()
           .RequireCors(MyAllowSpecificOrigins);

  endpoints.MapRazorPages();
});*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

/*
app.UseEndpoints(endpoints =>
{
  endpoints.MapControllers();
  endpoints.MapFallbackToController("Index", "Fallback");
});*/

app.Run();
