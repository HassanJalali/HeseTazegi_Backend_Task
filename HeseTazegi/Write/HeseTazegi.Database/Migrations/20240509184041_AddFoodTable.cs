using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeseTazegi.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                schema: "HeseTazegi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Name = table.Column<string>(type: "NVarChar(500)", maxLength: 500, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodIngredient",
                schema: "HeseTazegi",
                columns: table => new
                {
                    FoodId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodIngredient", x => new { x.FoodId, x.Id });
                    table.ForeignKey(
                        name: "FK_FoodIngredient_Foods_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "HeseTazegi",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "HeseTazegi",
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodIngredient_IngredientId",
                schema: "HeseTazegi",
                table: "FoodIngredient",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodIngredient",
                schema: "HeseTazegi");

            migrationBuilder.DropTable(
                name: "Foods",
                schema: "HeseTazegi");
        }
    }
}
