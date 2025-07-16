using Npgsql;

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
            var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                                  ?? configuration.GetConnectionString("DefaultConnection");

            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Chuyển đổi nếu dùng DATABASE_URL từ Railway
            if (connectionString.StartsWith("postgresql://"))
            {
                var uri = new Uri(connectionString);
                var userInfo = uri.UserInfo.Split(':');

                connectionString = new NpgsqlConnectionStringBuilder
                {
                    Host = uri.Host,
                    Port = uri.Port,
                    Username = userInfo[0],
                    Password = userInfo[1],
                    Database = uri.AbsolutePath.TrimStart('/'),
                    SslMode = SslMode.Require,
                    TrustServerCertificate = true
                }.ToString();
            }

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));
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