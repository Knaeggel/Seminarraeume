using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Data.Migrations
{
    public partial class newtabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticktes",
                table: "Ticktes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blocks",
                table: "Blocks");

            migrationBuilder.RenameTable(
                name: "Ticktes",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "Blocks",
                newName: "Day");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Day",
                table: "Day",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Day",
                table: "Day");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Ticktes");

            migrationBuilder.RenameTable(
                name: "Day",
                newName: "Blocks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticktes",
                table: "Ticktes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blocks",
                table: "Blocks",
                column: "ID");
        }
    }
}
