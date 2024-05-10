using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeseTazegi.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HeseTazegi");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                schema: "HeseTazegi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Name = table.Column<string>(type: "NVarChar(500)", maxLength: 500, nullable: false),
                    IsFoodAllergen = table.Column<bool>(type: "Bit", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients",
                schema: "HeseTazegi");
        }
    }
}
