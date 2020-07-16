using Microsoft.EntityFrameworkCore.Migrations;

namespace PokedexASPNET.Migrations
{
    public partial class AddPokemoneToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PrimaryType = table.Column<string>(nullable: true),
                    SecondaryType = table.Column<string>(nullable: true),
                    Caught = table.Column<bool>(nullable: false),
                    EvolvesTo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
