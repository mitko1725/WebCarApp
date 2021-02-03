using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCarApp.Data.Migrations
{
    public partial class RemovedModelMistakeInEngineClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Models_ModelId",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Engines_ModelId",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Engines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Engines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Engines_ModelId",
                table: "Engines",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Models_ModelId",
                table: "Engines",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
