using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaryManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBangThueAndGiamTruThueTNCN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BacThue",
                table: "ThueTNCN",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTinhThue",
                table: "ThueTNCN",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BangThueTNCN",
                columns: table => new
                {
                    Bac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MucTu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MucDen = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TyLe = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    SoTienGiamTru = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangThueTNCN", x => x.Bac);
                });

            migrationBuilder.CreateTable(
                name: "GiamTruThueTNCN",
                columns: table => new
                {
                    MaGiamTru = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    LoaiGiamTru = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ThueTNCN_BacThue",
                table: "ThueTNCN",
                column: "BacThue");

            migrationBuilder.CreateIndex(
                name: "IX_GiamTruThueTNCN_MaNV",
                table: "GiamTruThueTNCN",
                column: "MaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_ThueTNCN_BangThueTNCN_BacThue",
                table: "ThueTNCN",
                column: "BacThue",
                principalTable: "BangThueTNCN",
                principalColumn: "Bac",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThueTNCN_BangThueTNCN_BacThue",
                table: "ThueTNCN");

            migrationBuilder.DropTable(
                name: "BangThueTNCN");

            migrationBuilder.DropTable(
                name: "GiamTruThueTNCN");

            migrationBuilder.DropIndex(
                name: "IX_ThueTNCN_BacThue",
                table: "ThueTNCN");

            migrationBuilder.DropColumn(
                name: "BacThue",
                table: "ThueTNCN");

            migrationBuilder.DropColumn(
                name: "NgayTinhThue",
                table: "ThueTNCN");
        }
    }
}
