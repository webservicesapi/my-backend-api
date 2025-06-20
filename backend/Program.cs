var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// ✅ Disable or restrict HTTPS redirection
// app.UseHttpsRedirection(); // <-- Commented out for Render

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
