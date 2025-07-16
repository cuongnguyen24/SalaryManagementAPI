using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SalaryManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BangThueTNCN",
                columns: table => new
                {
                    Bac = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MucTu = table.Column<decimal>(type: "numeric", nullable: true),
                    MucDen = table.Column<decimal>(type: "numeric", nullable: true),
                    TyLe = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    SoTienGiamTru = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    ThoiGianHieuLuc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangThueTNCN", x => x.Bac);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    MaChucVu = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenChucVu = table.Column<string>(type: "text", nullable: false),
                    HeSoLuong = table.Column<decimal>(type: "numeric(4,2)", precision: 4, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.MaChucVu);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    MaPhong = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenPhong = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.MaPhong);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    MaVaiTro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenVaiTro = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.MaVaiTro);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HoTen = table.Column<string>(type: "text", nullable: false),
                    GioiTinh = table.Column<string>(type: "text", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiaChi = table.Column<string>(type: "text", nullable: false),
                    DienThoai = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    MaPhong = table.Column<int>(type: "integer", nullable: false),
                    MaChucVu = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_MaChucVu",
                        column: x => x.MaChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "MaChucVu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_PhongBan_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "PhongBan",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaoHiem",
                columns: table => new
                {
                    MaBH = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaNV = table.Column<int>(type: "integer", nullable: false),
                    Thang = table.Column<int>(type: "integer", nullable: false),
                    Nam = table.Column<int>(type: "integer", nullable: false),
                    BHXH = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    BHYT = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    BHTN = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    TongBH = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoHiem", x => x.MaBH);
                    table.ForeignKey(
                        name: "FK_BaoHiem_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamCong",
                columns: table => new
                {
                    MaCC = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaNV = table.Column<int>(type: "integer", nullable: false),
                    Thang = table.Column<int>(type: "integer", nullable: false),
                    Nam = table.Column<int>(type: "integer", nullable: false),
                    SoNgayCong = table.Column<int>(type: "integer", nullable: false),
                    SoGioTangCa = table.Column<int>(type: "integer", nullable: false),
                    SoNgayNghiCoPhep = table.Column<int>(type: "integer", nullable: false),
                    SoNgayNghiKhongPhep = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamCong", x => x.MaCC);
                    table.ForeignKey(
                        name: "FK_ChamCong_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiamTruThueTNCN",
                columns: table => new
                {
                    MaGiamTru = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaNV = table.Column<int>(type: "integer", nullable: false),
                    Thang = table.Column<int>(type: "integer", nullable: false),
                    Nam = table.Column<int>(type: "integer", nullable: false),
                    LoaiGiamTru = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SoTien = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamTruThueTNCN", x => x.MaGiamTru);
                    table.ForeignKey(
                        name: "FK_GiamTruThueTNCN_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaNV = table.Column<int>(type: "integer", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LoaiHopDong = table.Column<string>(type: "text", nullable: false),
                    MucLuongCoBan = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HopDong_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    MaLuong = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaNV = table.Column<int>(type: "integer", nullable: false),
                    Thang = table.Column<int>(type: "integer", nullable: false),
                    Nam = table.Column<int>(type: "integer", nullable: false),
                    TongLuong = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    NgayTinhLuong = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.MaLuong);
                    table.ForeignKey(
                        name: "FK_Luong_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    TenDangNhap = table.Column<string>(type: "text", nullable: false),
                    MatKhau = table.Column<string>(type: "text", nullable: false),
                    MaNV = table.Column<int>(type: "integer", nullable: false),
                    MaVaiTro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.TenDangNhap);
                    table.ForeignKey(
                        name: "FK_NguoiDung_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiDung_VaiTro_MaVaiTro",
                        column: x => x.MaVaiTro,
                        principalTable: "VaiTro",
                        principalColumn: "MaVaiTro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhuCap",
                columns: table => new
                {
                    MaPC = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaNV = table.Column<int>(type: "integer", nullable: false),
                    Thang = table.Column<int>(type: "integer", nullable: false),
                    Nam = table.Column<int>(type: "integer", nullable: false),
                    LoaiPhuCap = table.Column<string>(type: "text", nullable: false),
                    SoTien = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuCap", x => x.MaPC);
                    table.ForeignKey(
                        name: "FK_PhuCap_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThueTNCN",
                columns: table => new
                {
                    MaThue = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaNV = table.Column<int>(type: "integer", nullable: false),
                    Thang = table.Column<int>(type: "integer", nullable: false),
                    Nam = table.Column<int>(type: "integer", nullable: false),
                    ThuNhapChiuThue = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    ThuePhaiDong = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    BacThue = table.Column<int>(type: "integer", nullable: false),
                    NgayTinhThue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThueTNCN", x => x.MaThue);
                    table.ForeignKey(
                        name: "FK_ThueTNCN_BangThueTNCN_BacThue",
                        column: x => x.BacThue,
                        principalTable: "BangThueTNCN",
                        principalColumn: "Bac",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThueTNCN_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThuongPhat",
                columns: table => new
                {
                    MaTP = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaNV = table.Column<int>(type: "integer", nullable: false),
                    Thang = table.Column<int>(type: "integer", nullable: false),
                    Nam = table.Column<int>(type: "integer", nullable: false),
                    Loai = table.Column<string>(type: "text", nullable: false),
                    LyDo = table.Column<string>(type: "text", nullable: false),
                    SoTien = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongPhat", x => x.MaTP);
                    table.ForeignKey(
                        name: "FK_ThuongPhat_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietLuong",
                columns: table => new
                {
                    MaChiTiet = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaLuong = table.Column<int>(type: "integer", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    HeSoLuong = table.Column<decimal>(type: "numeric(4,2)", precision: 4, scale: 2, nullable: false),
                    TongPhuCap = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    TongThuong = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    TongPhat = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    LuongTruocKhauTru = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    LuongThucLanh = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietLuong", x => x.MaChiTiet);
                    table.ForeignKey(
                        name: "FK_ChiTietLuong_Luong_MaLuong",
                        column: x => x.MaLuong,
                        principalTable: "Luong",
                        principalColumn: "MaLuong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoHiem_MaNV",
                table: "BaoHiem",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_ChamCong_MaNV",
                table: "ChamCong",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietLuong_MaLuong",
                table: "ChiTietLuong",
                column: "MaLuong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiamTruThueTNCN_MaNV",
                table: "GiamTruThueTNCN",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_MaNV",
                table: "HopDong",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_MaNV",
                table: "Luong",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_MaNV",
                table: "NguoiDung",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_MaVaiTro",
                table: "NguoiDung",
                column: "MaVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaChucVu",
                table: "NhanVien",
                column: "MaChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaPhong",
                table: "NhanVien",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_PhuCap_MaNV",
                table: "PhuCap",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_ThueTNCN_BacThue",
                table: "ThueTNCN",
                column: "BacThue");

            migrationBuilder.CreateIndex(
                name: "IX_ThueTNCN_MaNV",
                table: "ThueTNCN",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_ThuongPhat_MaNV",
                table: "ThuongPhat",
                column: "MaNV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoHiem");

            migrationBuilder.DropTable(
                name: "ChamCong");

            migrationBuilder.DropTable(
                name: "ChiTietLuong");

            migrationBuilder.DropTable(
                name: "GiamTruThueTNCN");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "PhuCap");

            migrationBuilder.DropTable(
                name: "ThueTNCN");

            migrationBuilder.DropTable(
                name: "ThuongPhat");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "BangThueTNCN");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "PhongBan");
        }
    }
}
