using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLST.Migrations
{
    /// <inheritdoc />
    public partial class Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryidCat",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idCat",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nameCat",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    idCat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameCat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.idCat);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryidCat",
                table: "Product",
                column: "CategoryidCat");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryidCat",
                table: "Product",
                column: "CategoryidCat",
                principalTable: "Category",
                principalColumn: "idCat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryidCat",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryidCat",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryidCat",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "idCat",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "nameCat",
                table: "Product");
        }
    }
}
