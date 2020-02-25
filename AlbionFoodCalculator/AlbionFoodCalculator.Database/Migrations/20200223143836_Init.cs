using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AlbionFoodCalculator.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    CraftingFocus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "FoodItemResources",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FoodItemName = table.Column<string>(nullable: true),
                    ResourceName = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItemResources_FoodItems_FoodItemName",
                        column: x => x.FoodItemName,
                        principalTable: "FoodItems",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodItemResources_Resources_ResourceName",
                        column: x => x.ResourceName,
                        principalTable: "Resources",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemResources_FoodItemName",
                table: "FoodItemResources",
                column: "FoodItemName");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemResources_ResourceName",
                table: "FoodItemResources",
                column: "ResourceName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItemResources");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
