using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DNMVCCP.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAndSeedTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ISBN = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Author = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price50 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price100 = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Waqas Nazir1", "This is my first book", "SW4345355435", 99m, 90m, 50m, 85m, "Book1" },
                    { 2, "Waqas Nazir2", "This is my second book", "SW4345355435", 99m, 90m, 50m, 85m, "Book2" },
                    { 3, "Waqas Nazir3", "This is my third book", "SW4345355435", 99m, 90m, 50m, 85m, "Book3" },
                    { 4, "Waqas Nazir4", "This is my fourth book", "SW4345355435", 99m, 90m, 50m, 85m, "Book4" },
                    { 5, "Waqas Nazir5", "This is my fifth book", "SW4345355435", 99m, 90m, 50m, 85m, "Book5" },
                    { 6, "Waqas Nazir6", "This is my sixth book", "SW4345355435", 99m, 90m, 50m, 85m, "Book6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
