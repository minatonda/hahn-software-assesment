using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HahnWorkerService.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BreedAttributeBoolean",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AttributeType = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedAttributeBoolean", x => new { x.Id, x.AttributeType });
                });

            migrationBuilder.CreateTable(
                name: "BreedAttributeRange",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AttributeType = table.Column<int>(type: "INTEGER", nullable: false),
                    Min = table.Column<decimal>(type: "TEXT", nullable: false),
                    Max = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedAttributeRange", x => new { x.Id, x.AttributeType });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropTable(
                name: "BreedAttributeBoolean");

            migrationBuilder.DropTable(
                name: "BreedAttributeRange");
        }
    }
}
