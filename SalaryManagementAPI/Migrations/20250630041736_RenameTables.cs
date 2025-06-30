using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaryManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaoHiems_NhanViens_MaNV",
                table: "BaoHiems");

            migrationBuilder.DropForeignKey(
                name: "FK_ChamCongs_NhanViens_MaNV",
                table: "ChamCongs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietLuongs_Luongs_MaLuong",
                table: "ChiTietLuongs");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDongs_NhanViens_MaNV",
                table: "HopDongs");

            migrationBuilder.DropForeignKey(
                name: "FK_Luongs_NhanViens_MaNV",
                table: "Luongs");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDungs_NhanViens_MaNV",
                table: "NguoiDungs");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDungs_VaiTros_MaVaiTro",
                table: "NguoiDungs");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanViens_ChucVus_MaChucVu",
                table: "NhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanViens_PhongBans_MaPhong",
                table: "NhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuCaps_NhanViens_MaNV",
                table: "PhuCaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ThuongPhats_NhanViens_MaNV",
                table: "ThuongPhats");

            migrationBuilder.DropForeignKey(
                name: "FK_ThuTNCNs_NhanViens_MaNV",
                table: "ThuTNCNs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VaiTros",
                table: "VaiTros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThuTNCNs",
                table: "ThuTNCNs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThuongPhats",
                table: "ThuongPhats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhuCaps",
                table: "PhuCaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhongBans",
                table: "PhongBans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhanViens",
                table: "NhanViens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NguoiDungs",
                table: "NguoiDungs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Luongs",
                table: "Luongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HopDongs",
                table: "HopDongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChucVus",
                table: "ChucVus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietLuongs",
                table: "ChiTietLuongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChamCongs",
                table: "ChamCongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaoHiems",
                table: "BaoHiems");

            migrationBuilder.RenameTable(
                name: "VaiTros",
                newName: "VaiTro");

            migrationBuilder.RenameTable(
                name: "ThuTNCNs",
                newName: "ThueTNCN");

            migrationBuilder.RenameTable(
                name: "ThuongPhats",
                newName: "ThuongPhat");

            migrationBuilder.RenameTable(
                name: "PhuCaps",
                newName: "PhuCap");

            migrationBuilder.RenameTable(
                name: "PhongBans",
                newName: "PhongBan");

            migrationBuilder.RenameTable(
                name: "NhanViens",
                newName: "NhanVien");

            migrationBuilder.RenameTable(
                name: "NguoiDungs",
                newName: "NguoiDung");

            migrationBuilder.RenameTable(
                name: "Luongs",
                newName: "Luong");

            migrationBuilder.RenameTable(
                name: "HopDongs",
                newName: "HopDong");

            migrationBuilder.RenameTable(
                name: "ChucVus",
                newName: "ChucVu");

            migrationBuilder.RenameTable(
                name: "ChiTietLuongs",
                newName: "ChiTietLuong");

            migrationBuilder.RenameTable(
                name: "ChamCongs",
                newName: "ChamCong");

            migrationBuilder.RenameTable(
                name: "BaoHiems",
                newName: "BaoHiem");

            migrationBuilder.RenameIndex(
                name: "IX_ThuTNCNs_MaNV",
                table: "ThueTNCN",
                newName: "IX_ThueTNCN_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_ThuongPhats_MaNV",
                table: "ThuongPhat",
                newName: "IX_ThuongPhat_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_PhuCaps_MaNV",
                table: "PhuCap",
                newName: "IX_PhuCap_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_NhanViens_MaPhong",
                table: "NhanVien",
                newName: "IX_NhanVien_MaPhong");

            migrationBuilder.RenameIndex(
                name: "IX_NhanViens_MaChucVu",
                table: "NhanVien",
                newName: "IX_NhanVien_MaChucVu");

            migrationBuilder.RenameIndex(
                name: "IX_NguoiDungs_MaVaiTro",
                table: "NguoiDung",
                newName: "IX_NguoiDung_MaVaiTro");

            migrationBuilder.RenameIndex(
                name: "IX_NguoiDungs_MaNV",
                table: "NguoiDung",
                newName: "IX_NguoiDung_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_Luongs_MaNV",
                table: "Luong",
                newName: "IX_Luong_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_HopDongs_MaNV",
                table: "HopDong",
                newName: "IX_HopDong_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietLuongs_MaLuong",
                table: "ChiTietLuong",
                newName: "IX_ChiTietLuong_MaLuong");

            migrationBuilder.RenameIndex(
                name: "IX_ChamCongs_MaNV",
                table: "ChamCong",
                newName: "IX_ChamCong_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_BaoHiems_MaNV",
                table: "BaoHiem",
                newName: "IX_BaoHiem_MaNV");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VaiTro",
                table: "VaiTro",
                column: "MaVaiTro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThueTNCN",
                table: "ThueTNCN",
                column: "MaThue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThuongPhat",
                table: "ThuongPhat",
                column: "MaTP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhuCap",
                table: "PhuCap",
                column: "MaPC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhongBan",
                table: "PhongBan",
                column: "MaPhong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhanVien",
                table: "NhanVien",
                column: "MaNV");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NguoiDung",
                table: "NguoiDung",
                column: "TenDangNhap");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Luong",
                table: "Luong",
                column: "MaLuong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HopDong",
                table: "HopDong",
                column: "MaHD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChucVu",
                table: "ChucVu",
                column: "MaChucVu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietLuong",
                table: "ChiTietLuong",
                column: "MaChiTiet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChamCong",
                table: "ChamCong",
                column: "MaCC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaoHiem",
                table: "BaoHiem",
                column: "MaBH");

            migrationBuilder.AddForeignKey(
                name: "FK_BaoHiem_NhanVien_MaNV",
                table: "BaoHiem",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChamCong_NhanVien_MaNV",
                table: "ChamCong",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietLuong_Luong_MaLuong",
                table: "ChiTietLuong",
                column: "MaLuong",
                principalTable: "Luong",
                principalColumn: "MaLuong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_NhanVien_MaNV",
                table: "HopDong",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Luong_NhanVien_MaNV",
                table: "Luong",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_NhanVien_MaNV",
                table: "NguoiDung",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_VaiTro_MaVaiTro",
                table: "NguoiDung",
                column: "MaVaiTro",
                principalTable: "VaiTro",
                principalColumn: "MaVaiTro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_ChucVu_MaChucVu",
                table: "NhanVien",
                column: "MaChucVu",
                principalTable: "ChucVu",
                principalColumn: "MaChucVu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_PhongBan_MaPhong",
                table: "NhanVien",
                column: "MaPhong",
                principalTable: "PhongBan",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuCap_NhanVien_MaNV",
                table: "PhuCap",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThueTNCN_NhanVien_MaNV",
                table: "ThueTNCN",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThuongPhat_NhanVien_MaNV",
                table: "ThuongPhat",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaoHiem_NhanVien_MaNV",
                table: "BaoHiem");

            migrationBuilder.DropForeignKey(
                name: "FK_ChamCong_NhanVien_MaNV",
                table: "ChamCong");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietLuong_Luong_MaLuong",
                table: "ChiTietLuong");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_NhanVien_MaNV",
                table: "HopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_Luong_NhanVien_MaNV",
                table: "Luong");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_NhanVien_MaNV",
                table: "NguoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_VaiTro_MaVaiTro",
                table: "NguoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_ChucVu_MaChucVu",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_PhongBan_MaPhong",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuCap_NhanVien_MaNV",
                table: "PhuCap");

            migrationBuilder.DropForeignKey(
                name: "FK_ThueTNCN_NhanVien_MaNV",
                table: "ThueTNCN");

            migrationBuilder.DropForeignKey(
                name: "FK_ThuongPhat_NhanVien_MaNV",
                table: "ThuongPhat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VaiTro",
                table: "VaiTro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThuongPhat",
                table: "ThuongPhat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThueTNCN",
                table: "ThueTNCN");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhuCap",
                table: "PhuCap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhongBan",
                table: "PhongBan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhanVien",
                table: "NhanVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NguoiDung",
                table: "NguoiDung");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Luong",
                table: "Luong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HopDong",
                table: "HopDong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChucVu",
                table: "ChucVu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietLuong",
                table: "ChiTietLuong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChamCong",
                table: "ChamCong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaoHiem",
                table: "BaoHiem");

            migrationBuilder.RenameTable(
                name: "VaiTro",
                newName: "VaiTros");

            migrationBuilder.RenameTable(
                name: "ThuongPhat",
                newName: "ThuongPhats");

            migrationBuilder.RenameTable(
                name: "ThueTNCN",
                newName: "ThuTNCNs");

            migrationBuilder.RenameTable(
                name: "PhuCap",
                newName: "PhuCaps");

            migrationBuilder.RenameTable(
                name: "PhongBan",
                newName: "PhongBans");

            migrationBuilder.RenameTable(
                name: "NhanVien",
                newName: "NhanViens");

            migrationBuilder.RenameTable(
                name: "NguoiDung",
                newName: "NguoiDungs");

            migrationBuilder.RenameTable(
                name: "Luong",
                newName: "Luongs");

            migrationBuilder.RenameTable(
                name: "HopDong",
                newName: "HopDongs");

            migrationBuilder.RenameTable(
                name: "ChucVu",
                newName: "ChucVus");

            migrationBuilder.RenameTable(
                name: "ChiTietLuong",
                newName: "ChiTietLuongs");

            migrationBuilder.RenameTable(
                name: "ChamCong",
                newName: "ChamCongs");

            migrationBuilder.RenameTable(
                name: "BaoHiem",
                newName: "BaoHiems");

            migrationBuilder.RenameIndex(
                name: "IX_ThuongPhat_MaNV",
                table: "ThuongPhats",
                newName: "IX_ThuongPhats_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_ThueTNCN_MaNV",
                table: "ThuTNCNs",
                newName: "IX_ThuTNCNs_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_PhuCap_MaNV",
                table: "PhuCaps",
                newName: "IX_PhuCaps_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_NhanVien_MaPhong",
                table: "NhanViens",
                newName: "IX_NhanViens_MaPhong");

            migrationBuilder.RenameIndex(
                name: "IX_NhanVien_MaChucVu",
                table: "NhanViens",
                newName: "IX_NhanViens_MaChucVu");

            migrationBuilder.RenameIndex(
                name: "IX_NguoiDung_MaVaiTro",
                table: "NguoiDungs",
                newName: "IX_NguoiDungs_MaVaiTro");

            migrationBuilder.RenameIndex(
                name: "IX_NguoiDung_MaNV",
                table: "NguoiDungs",
                newName: "IX_NguoiDungs_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_Luong_MaNV",
                table: "Luongs",
                newName: "IX_Luongs_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_HopDong_MaNV",
                table: "HopDongs",
                newName: "IX_HopDongs_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietLuong_MaLuong",
                table: "ChiTietLuongs",
                newName: "IX_ChiTietLuongs_MaLuong");

            migrationBuilder.RenameIndex(
                name: "IX_ChamCong_MaNV",
                table: "ChamCongs",
                newName: "IX_ChamCongs_MaNV");

            migrationBuilder.RenameIndex(
                name: "IX_BaoHiem_MaNV",
                table: "BaoHiems",
                newName: "IX_BaoHiems_MaNV");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VaiTros",
                table: "VaiTros",
                column: "MaVaiTro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThuongPhats",
                table: "ThuongPhats",
                column: "MaTP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThuTNCNs",
                table: "ThuTNCNs",
                column: "MaThue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhuCaps",
                table: "PhuCaps",
                column: "MaPC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhongBans",
                table: "PhongBans",
                column: "MaPhong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhanViens",
                table: "NhanViens",
                column: "MaNV");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NguoiDungs",
                table: "NguoiDungs",
                column: "TenDangNhap");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Luongs",
                table: "Luongs",
                column: "MaLuong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HopDongs",
                table: "HopDongs",
                column: "MaHD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChucVus",
                table: "ChucVus",
                column: "MaChucVu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietLuongs",
                table: "ChiTietLuongs",
                column: "MaChiTiet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChamCongs",
                table: "ChamCongs",
                column: "MaCC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaoHiems",
                table: "BaoHiems",
                column: "MaBH");

            migrationBuilder.AddForeignKey(
                name: "FK_BaoHiems_NhanViens_MaNV",
                table: "BaoHiems",
                column: "MaNV",
                principalTable: "NhanViens",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChamCongs_NhanViens_MaNV",
                table: "ChamCongs",
                column: "MaNV",
                principalTable: "NhanViens",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietLuongs_Luongs_MaLuong",
                table: "ChiTietLuongs",
                column: "MaLuong",
                principalTable: "Luongs",
                principalColumn: "MaLuong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongs_NhanViens_MaNV",
                table: "HopDongs",
                column: "MaNV",
                principalTable: "NhanViens",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Luongs_NhanViens_MaNV",
                table: "Luongs",
                column: "MaNV",
                principalTable: "NhanViens",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDungs_NhanViens_MaNV",
                table: "NguoiDungs",
                column: "MaNV",
                principalTable: "NhanViens",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDungs_VaiTros_MaVaiTro",
                table: "NguoiDungs",
                column: "MaVaiTro",
                principalTable: "VaiTros",
                principalColumn: "MaVaiTro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_ChucVus_MaChucVu",
                table: "NhanViens",
                column: "MaChucVu",
                principalTable: "ChucVus",
                principalColumn: "MaChucVu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_PhongBans_MaPhong",
                table: "NhanViens",
                column: "MaPhong",
                principalTable: "PhongBans",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuCaps_NhanViens_MaNV",
                table: "PhuCaps",
                column: "MaNV",
                principalTable: "NhanViens",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThuongPhats_NhanViens_MaNV",
                table: "ThuongPhats",
                column: "MaNV",
                principalTable: "NhanViens",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThuTNCNs_NhanViens_MaNV",
                table: "ThuTNCNs",
                column: "MaNV",
                principalTable: "NhanViens",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
