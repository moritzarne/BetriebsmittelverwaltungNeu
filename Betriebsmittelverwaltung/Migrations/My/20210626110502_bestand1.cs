using Microsoft.EntityFrameworkCore.Migrations;

namespace Betriebsmittelverwaltung.Migrations.My
{
    public partial class bestand1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "typ",
                table: "Bestandsverwaltung",
                newName: "Typ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Typ",
                table: "Bestandsverwaltung",
                newName: "typ");
        }
    }
}
