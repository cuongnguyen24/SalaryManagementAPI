namespace SalaryManagementAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddScoped<INhanVienService, NhanVienService>();
            services.AddScoped<IPhongBanService, PhongBanService>();
            services.AddScoped<IChucVuService, ChucVuService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IHopDongService, HopDongService>();
            services.AddScoped<IThueTNCNService, ThueTNCNService>();
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Ưu tiên lấy từ biến môi trường trước, nếu không có thì dùng từ configuration
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
                                  ?? configuration.GetConnectionString("DefaultConnection");

            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    npgsqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });

                // Chỉ bật logging chi tiết trong môi trường Development
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                {
                    options.LogTo(Console.WriteLine, LogLevel.Information)
                           .EnableSensitiveDataLogging();
                }
            });
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void UseCustomStatusCodePages(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(context =>
            {
                var response = context.HttpContext.Response;
                response.ContentType = "application/json";

                return response.StatusCode switch
                {
                    StatusCodes.Status401Unauthorized => response.WriteAsync("""
            {
                "thanhCong": false,
                "thongBao": "Bạn chưa đăng nhập hoặc token không hợp lệ."
            }
            """),

                    StatusCodes.Status403Forbidden => response.WriteAsync("""
            {
                "thanhCong": false,
                "thongBao": "Bạn không có quyền truy cập chức năng này."
            }
            """),

                    _ => Task.CompletedTask
                };
            });
        }

        public static void ConfigureControllersWithGlobalAuthorize(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
        }
    }
}