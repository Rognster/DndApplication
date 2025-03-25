using DndApplication.Server.Data;
using Microsoft.EntityFrameworkCore;
//comment to trigger deploy
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register DbContext
builder.Services.AddDbContext<DndDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
});


// Add Swagger for API documentation (optional but recommended)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin() // Allows all origins
                .AllowAnyMethod() // Allows all HTTP methods (GET, POST, etc.)
                .AllowAnyHeader(); // Allows all headers
        });
});

//builder.WebHost.UseUrls("http://localhost:5002");


var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
