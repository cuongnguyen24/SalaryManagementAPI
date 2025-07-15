namespace SalaryManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<NhanVien> NhanViens => Set<NhanVien>();
        public DbSet<Luong> Luongs => Set<Luong>();
        public DbSet<ChiTietLuong> ChiTietLuongs => Set<ChiTietLuong>();
        public DbSet<BaoHiem> BaoHiems => Set<BaoHiem>();
        public DbSet<ThueTNCN> ThuTNCNs => Set<ThueTNCN>();
        public DbSet<HopDong> HopDongs => Set<HopDong>();
        public DbSet<PhongBan> PhongBans => Set<PhongBan>();
        public DbSet<ChucVu> ChucVus => Set<ChucVu>();
        public DbSet<ChamCong> ChamCongs => Set<ChamCong>();
        public DbSet<PhuCap> PhuCaps => Set<PhuCap>();
        public DbSet<ThuongPhat> ThuongPhats => Set<ThuongPhat>();
        public DbSet<NguoiDung> NguoiDungs => Set<NguoiDung>();
        public DbSet<VaiTro> VaiTros => Set<VaiTro>();
        public DbSet<BangThueTNCN> BangThueTNCNs => Set<BangThueTNCN>();
        public DbSet<GiamTruThueTNCN> GiamTruThueTNCNs => Set<GiamTruThueTNCN>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NhanVien>().ToTable("NhanVien");
            modelBuilder.Entity<Luong>().ToTable("Luong");
            modelBuilder.Entity<ChiTietLuong>().ToTable("ChiTietLuong");
            modelBuilder.Entity<BaoHiem>().ToTable("BaoHiem");
            modelBuilder.Entity<ThueTNCN>().ToTable("ThueTNCN");
            modelBuilder.Entity<HopDong>().ToTable("HopDong");
            modelBuilder.Entity<PhongBan>().ToTable("PhongBan");
            modelBuilder.Entity<ChucVu>().ToTable("ChucVu");
            modelBuilder.Entity<ChamCong>().ToTable("ChamCong");
            modelBuilder.Entity<PhuCap>().ToTable("PhuCap");
            modelBuilder.Entity<ThuongPhat>().ToTable("ThuongPhat");
            modelBuilder.Entity<NguoiDung>().ToTable("NguoiDung");
            modelBuilder.Entity<VaiTro>().ToTable("VaiTro");
            modelBuilder.Entity<BangThueTNCN>().ToTable("BangThueTNCN");
            modelBuilder.Entity<GiamTruThueTNCN>().ToTable("GiamTruThueTNCN");

            // Khóa chính cho NguoiDung là TenDangNhap
            modelBuilder.Entity<NguoiDung>()
                .HasKey(u => u.TenDangNhap);

            // Quan hệ NhanVien - Luong
            modelBuilder.Entity<Luong>()
                .HasOne(l => l.NhanVien)
                .WithMany(nv => nv.Luongs)
                .HasForeignKey(l => l.MaNV);

            // Quan hệ Luong - ChiTietLuong (1-1)
            modelBuilder.Entity<ChiTietLuong>()
                .HasOne(ct => ct.Luong)
                .WithOne(l => l.ChiTietLuong)
                .HasForeignKey<ChiTietLuong>(ct => ct.MaLuong);

            // Các quan hệ khác
            modelBuilder.Entity<BaoHiem>()
                .HasOne(b => b.NhanVien)
                .WithMany(nv => nv.BaoHiems)
            .HasForeignKey(b => b.MaNV);

            modelBuilder.Entity<ThueTNCN>()
                .HasOne(t => t.NhanVien)
                .WithMany(nv => nv.ThueTNCNs)
                .HasForeignKey(t => t.MaNV);

            modelBuilder.Entity<HopDong>()
                .HasOne(h => h.NhanVien)
                .WithMany(nv => nv.HopDongs)
                .HasForeignKey(h => h.MaNV);

            modelBuilder.Entity<ChamCong>()
                .HasOne(c => c.NhanVien)
                .WithMany(nv => nv.ChamCongs)
                .HasForeignKey(c => c.MaNV);

            modelBuilder.Entity<PhuCap>()
                .HasOne(p => p.NhanVien)
                .WithMany(nv => nv.PhuCaps)
                .HasForeignKey(p => p.MaNV);

            modelBuilder.Entity<ThuongPhat>()
                .HasOne(tp => tp.NhanVien)
                .WithMany(nv => nv.ThuongPhats)
                .HasForeignKey(tp => tp.MaNV);

            modelBuilder.Entity<NguoiDung>()
                .HasOne(nd => nd.NhanVien)
                .WithMany(nv => nv.NguoiDungs)
                .HasForeignKey(nd => nd.MaNV);

            modelBuilder.Entity<NguoiDung>()
                .HasOne(nd => nd.VaiTro)
                .WithMany(vt => vt.NguoiDungs)
                .HasForeignKey(nd => nd.MaVaiTro);

            modelBuilder.Entity<NhanVien>()
                .HasOne(nv => nv.PhongBan)
                .WithMany(pb => pb.NhanViens)
                .HasForeignKey(nv => nv.MaPhong);

            modelBuilder.Entity<NhanVien>()
                .HasOne(nv => nv.ChucVu)
                .WithMany(cv => cv.NhanViens)
                .HasForeignKey(nv => nv.MaChucVu);

            modelBuilder.Entity<ThueTNCN>()
                .HasOne(t => t.BacThueInfo)
                .WithMany(b => b.ThueTNCNs)
                .HasForeignKey(t => t.BacThue);

            modelBuilder.Entity<GiamTruThueTNCN>()
                .HasOne(gt => gt.NhanVien)
                .WithMany(nv => nv.GiamTruThueTNCNs)
                .HasForeignKey(gt => gt.MaNV);
        }
    }
}
