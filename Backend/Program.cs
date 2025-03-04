using InterArt.Models;
using InterArt.Repository;
using InterArt.Services;
using InterArt_Backend.DBContext;
using InterArt_Backend.Repository;
using InterArt_Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:5174") // React frontend URL
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IArtworkRepository, ArtworkRepository>();
builder.Services.AddScoped<IArtworkService, ArtworkService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

if(builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ArtworkDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDb"));
}
else if(builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<ArtworkDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ArtworkDbContext>();
    DbSeeding.SeedDatabase(context);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseCors("AllowReactApp"); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
