using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtKey = builder.Configuration["Jwt:Key"]!;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Cấu hình chính sách phân quyền
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("1"));
    options.AddPolicy("NhanSu", policy => policy.RequireRole("2"));
    options.AddPolicy("KeToan", policy => policy.RequireRole("3"));
    options.AddPolicy("TruongPhong", policy => policy.RequireRole("4"));
    options.AddPolicy("NhanVien", policy => policy.RequireRole("5"));
});

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SalaryManagement API",
        Version = "v1"
    });

    // Thêm định nghĩa bảo mật Bearer
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,         
        Scheme = "Bearer",                       
        BearerFormat = "JWT",                    
        In = ParameterLocation.Header,
        Description = "Nhập token vào đây (không cần thêm 'Bearer ')"
    });

    // Áp dụng yêu cầu bảo mật cho tất cả các endpoint
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<INhanVienService, NhanVienService>();
builder.Services.AddScoped<IPhongBanService, PhongBanService>();
builder.Services.AddScoped<IChucVuService, ChucVuService>();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseStatusCodePages(context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode == StatusCodes.Status401Unauthorized)
    {
        response.ContentType = "application/json";
        return response.WriteAsync("""
        {
            "thanhCong": false,
            "thongBao": "Bạn chưa đăng nhập hoặc token không hợp lệ."
        }
        """);
    }

    if (response.StatusCode == StatusCodes.Status403Forbidden)
    {
        response.ContentType = "application/json";
        return response.WriteAsync("""
        {
            "thanhCong": false,
            "thongBao": "Bạn không có quyền truy cập chức năng này."
        }
        """);
    }

    return Task.CompletedTask;
});


app.Run();

