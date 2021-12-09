using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.WebAPI.Migrations
{
    public partial class Rename_name_columns_and_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HerosBattles_Battles_BattleId",
                table: "HerosBattles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battles",
                table: "Battles");

            migrationBuilder.RenameTable(
                name: "Battles",
                newName: "battle");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "battle",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "battle",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "battle",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DtStart",
                table: "battle",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "DtFinal",
                table: "battle",
                newName: "final_date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_battle",
                table: "battle",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_HerosBattles_battle_BattleId",
                table: "HerosBattles",
                column: "BattleId",
                principalTable: "battle",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HerosBattles_battle_BattleId",
                table: "HerosBattles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_battle",
                table: "battle");

            migrationBuilder.RenameTable(
                name: "battle",
                newName: "Battles");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Battles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Battles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Battles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Battles",
                newName: "DtStart");

            migrationBuilder.RenameColumn(
                name: "final_date",
                table: "Battles",
                newName: "DtFinal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battles",
                table: "Battles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HerosBattles_Battles_BattleId",
                table: "HerosBattles",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
