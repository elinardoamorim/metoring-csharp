using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.WebAPI.Migrations
{
    public partial class Rename_columns_and_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HerosBattles_battle_BattleId",
                table: "HerosBattles");

            migrationBuilder.DropForeignKey(
                name: "FK_HerosBattles_Heroes_HeroId",
                table: "HerosBattles");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretsIdentitys_Heroes_HeroId",
                table: "SecretsIdentitys");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecretsIdentitys",
                table: "SecretsIdentitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HerosBattles",
                table: "HerosBattles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "weapon");

            migrationBuilder.RenameTable(
                name: "SecretsIdentitys",
                newName: "secretidentity");

            migrationBuilder.RenameTable(
                name: "HerosBattles",
                newName: "herobattle");

            migrationBuilder.RenameTable(
                name: "Heroes",
                newName: "hero");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "weapon",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "HeroId",
                table: "weapon",
                newName: "heroid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "weapon",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_HeroId",
                table: "weapon",
                newName: "IX_weapon_heroid");

            migrationBuilder.RenameColumn(
                name: "HeroId",
                table: "secretidentity",
                newName: "heroid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "secretidentity",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NameReal",
                table: "secretidentity",
                newName: "namreal");

            migrationBuilder.RenameIndex(
                name: "IX_SecretsIdentitys_HeroId",
                table: "secretidentity",
                newName: "IX_secretidentity_heroid");

            migrationBuilder.RenameColumn(
                name: "HeroId",
                table: "herobattle",
                newName: "heroid");

            migrationBuilder.RenameColumn(
                name: "BattleId",
                table: "herobattle",
                newName: "battleid");

            migrationBuilder.RenameIndex(
                name: "IX_HerosBattles_HeroId",
                table: "herobattle",
                newName: "IX_herobattle_heroid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "hero",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "hero",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_weapon",
                table: "weapon",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_secretidentity",
                table: "secretidentity",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_herobattle",
                table: "herobattle",
                columns: new[] { "battleid", "heroid" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_hero",
                table: "hero",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_herobattle_battle_battleid",
                table: "herobattle",
                column: "battleid",
                principalTable: "battle",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_herobattle_hero_heroid",
                table: "herobattle",
                column: "heroid",
                principalTable: "hero",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_secretidentity_hero_heroid",
                table: "secretidentity",
                column: "heroid",
                principalTable: "hero",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_weapon_hero_heroid",
                table: "weapon",
                column: "heroid",
                principalTable: "hero",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_herobattle_battle_battleid",
                table: "herobattle");

            migrationBuilder.DropForeignKey(
                name: "FK_herobattle_hero_heroid",
                table: "herobattle");

            migrationBuilder.DropForeignKey(
                name: "FK_secretidentity_hero_heroid",
                table: "secretidentity");

            migrationBuilder.DropForeignKey(
                name: "FK_weapon_hero_heroid",
                table: "weapon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_weapon",
                table: "weapon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_secretidentity",
                table: "secretidentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_herobattle",
                table: "herobattle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hero",
                table: "hero");

            migrationBuilder.RenameTable(
                name: "weapon",
                newName: "Weapons");

            migrationBuilder.RenameTable(
                name: "secretidentity",
                newName: "SecretsIdentitys");

            migrationBuilder.RenameTable(
                name: "herobattle",
                newName: "HerosBattles");

            migrationBuilder.RenameTable(
                name: "hero",
                newName: "Heroes");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Weapons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "heroid",
                table: "Weapons",
                newName: "HeroId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Weapons",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_weapon_heroid",
                table: "Weapons",
                newName: "IX_Weapons_HeroId");

            migrationBuilder.RenameColumn(
                name: "heroid",
                table: "SecretsIdentitys",
                newName: "HeroId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SecretsIdentitys",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "namreal",
                table: "SecretsIdentitys",
                newName: "NameReal");

            migrationBuilder.RenameIndex(
                name: "IX_secretidentity_heroid",
                table: "SecretsIdentitys",
                newName: "IX_SecretsIdentitys_HeroId");

            migrationBuilder.RenameColumn(
                name: "heroid",
                table: "HerosBattles",
                newName: "HeroId");

            migrationBuilder.RenameColumn(
                name: "battleid",
                table: "HerosBattles",
                newName: "BattleId");

            migrationBuilder.RenameIndex(
                name: "IX_herobattle_heroid",
                table: "HerosBattles",
                newName: "IX_HerosBattles_HeroId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Heroes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Heroes",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecretsIdentitys",
                table: "SecretsIdentitys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HerosBattles",
                table: "HerosBattles",
                columns: new[] { "BattleId", "HeroId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HerosBattles_battle_BattleId",
                table: "HerosBattles",
                column: "BattleId",
                principalTable: "battle",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HerosBattles_Heroes_HeroId",
                table: "HerosBattles",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretsIdentitys_Heroes_HeroId",
                table: "SecretsIdentitys",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
