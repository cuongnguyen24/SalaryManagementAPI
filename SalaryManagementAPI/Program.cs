using SalaryManagementAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureAppServices();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureJwtAuthentication(builder.Configuration);
builder.Services.ConfigureAuthorizationPolicies();
builder.Services.ConfigureControllersWithGlobalAuthorize();
builder.Services.ConfigureSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCustomStatusCodePages();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        dbContext.Database.CanConnect();
        Console.WriteLine("Kết nối PostgreSQL thành công!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Lỗi kết nối PostgreSQL:");
        Console.WriteLine(ex.Message);
    }
}

app.Run();
