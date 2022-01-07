using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonWebApplication.Migrations
{
    public partial class ModifypropertyIdDoPokemon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MestrePokemon",
                newName: "IdDoPokemon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdDoPokemon",
                table: "MestrePokemon",
                newName: "Id");
        }
    }
}
