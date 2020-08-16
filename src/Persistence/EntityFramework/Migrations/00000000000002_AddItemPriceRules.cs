using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MUnique.OpenMU.Persistence.EntityFramework.Migrations
{
    public partial class AddItemPriceRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemPriceRuleDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SerializedRule = table.Column<string>(nullable: true),
                    SerializedFunction = table.Column<string>(nullable: true),
                    GameConfigurationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPriceRuleDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPriceRuleDefinition_GameConfiguration_GameConfiguration~",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPriceRuleDefinition_GameConfigurationId",
                schema: "config",
                table: "ItemPriceRuleDefinition",
                column: "GameConfigurationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPriceRuleDefinition",
                schema: "config");
        }
    }
}
