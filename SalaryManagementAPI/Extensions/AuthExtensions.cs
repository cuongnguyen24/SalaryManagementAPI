namespace SalaryManagementAPI.Extensions
{
    public static class AuthExtensions
    {
        public static void ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });
        }

        public static void ConfigureAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("1"));
                options.AddPolicy("NhanSu", policy => policy.RequireRole("2"));
                options.AddPolicy("KeToan", policy => policy.RequireRole("3"));
                options.AddPolicy("TruongPhong", policy => policy.RequireRole("4"));
                options.AddPolicy("NhanVien", policy => policy.RequireRole("5"));
            });
        }
    }

}
