﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace context.Migrations
{
    /// <inheritdoc />
    public partial class uuuuu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catigoes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parent_CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catigoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Catigoes_Catigoes_Parent_CategoryID",
                        column: x => x.Parent_CategoryID,
                        principalTable: "Catigoes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Productss",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Discound_persentage = table.Column<byte>(type: "tinyint", nullable: true),
                    Available = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productss", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesID = table.Column<int>(type: "int", nullable: false),
                    ProductsID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesID, x.ProductsID });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Catigoes_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Catigoes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Productss_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Productss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "imagess",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    ProductID = table.Column<long>(type: "bigint", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagess", x => x.ID);
                    table.ForeignKey(
                        name: "FK_imagess_Catigoes_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Catigoes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_imagess_Productss_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Productss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsID",
                table: "CategoryProduct",
                column: "ProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_Catigoes_Parent_CategoryID",
                table: "Catigoes",
                column: "Parent_CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_imagess_CategoryID",
                table: "imagess",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_imagess_ProductID",
                table: "imagess",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "imagess");

            migrationBuilder.DropTable(
                name: "Catigoes");

            migrationBuilder.DropTable(
                name: "Productss");
        }
    }
}
