using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1._DAL.Migrations
{
    public partial class TestShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaoCaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoanhThu = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatLieus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiemTichLuy = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MauSacs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NSXes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NSXes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NgayMua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    ID_NV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_KH = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_ID_KH",
                        column: x => x.ID_KH,
                        principalTable: "KhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDons_NhanViens_ID_NV",
                        column: x => x.ID_NV,
                        principalTable: "NhanViens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_NV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChucVu = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoans_NhanViens_Id_NV",
                        column: x => x.Id_NV,
                        principalTable: "NhanViens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    GiaNiemYet = table.Column<double>(type: "float", nullable: false),
                    GiaNhap = table.Column<float>(type: "real", nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaVach = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ID_CL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Loai = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_NSX = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Size = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_MauSac = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_SP = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_ChatLieus_ID_CL",
                        column: x => x.ID_CL,
                        principalTable: "ChatLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_Loais_ID_Loai",
                        column: x => x.ID_Loai,
                        principalTable: "Loais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_MauSacs_ID_MauSac",
                        column: x => x.ID_MauSac,
                        principalTable: "MauSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_NSXes_ID_NSX",
                        column: x => x.ID_NSX,
                        principalTable: "NSXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_SanPhams_ID_SP",
                        column: x => x.ID_SP,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_Sizes_ID_Size",
                        column: x => x.ID_Size,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiaDaGiam = table.Column<double>(type: "float", nullable: false),
                    ID_HD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_SPCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_HoaDons_ID_HD",
                        column: x => x.ID_HD,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_SanPhamChiTiets_ID_SPCT",
                        column: x => x.ID_SPCT,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_ID_HD",
                table: "HoaDonChiTiets",
                column: "ID_HD");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_ID_SPCT",
                table: "HoaDonChiTiets",
                column: "ID_SPCT");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_ID_KH",
                table: "HoaDons",
                column: "ID_KH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_ID_NV",
                table: "HoaDons",
                column: "ID_NV");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_ID_CL",
                table: "SanPhamChiTiets",
                column: "ID_CL");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_ID_Loai",
                table: "SanPhamChiTiets",
                column: "ID_Loai");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_ID_MauSac",
                table: "SanPhamChiTiets",
                column: "ID_MauSac");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_ID_NSX",
                table: "SanPhamChiTiets",
                column: "ID_NSX");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_ID_Size",
                table: "SanPhamChiTiets",
                column: "ID_Size");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_ID_SP",
                table: "SanPhamChiTiets",
                column: "ID_SP");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_Id_NV",
                table: "TaiKhoans",
                column: "Id_NV",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoCaos");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiets");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "SanPhamChiTiets");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "ChatLieus");

            migrationBuilder.DropTable(
                name: "Loais");

            migrationBuilder.DropTable(
                name: "MauSacs");

            migrationBuilder.DropTable(
                name: "NSXes");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
