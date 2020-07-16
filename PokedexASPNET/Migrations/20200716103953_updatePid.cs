using Microsoft.EntityFrameworkCore.Migrations;

namespace PokedexASPNET.Migrations
{
    public partial class updatePid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pid",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pid",
                table: "Pokemons");
        }
    }
}
