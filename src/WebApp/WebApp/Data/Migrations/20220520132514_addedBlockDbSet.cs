using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Data.Migrations
{
    public partial class addedBlockDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Rooms",
                newName: "BlockID");

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Block1 = table.Column<int>(type: "int", nullable: false),
                    Block2 = table.Column<int>(type: "int", nullable: false),
                    Block3 = table.Column<int>(type: "int", nullable: false),
                    Block4 = table.Column<int>(type: "int", nullable: false),
                    Block5 = table.Column<int>(type: "int", nullable: false),
                    Block6 = table.Column<int>(type: "int", nullable: false),
                    Block7 = table.Column<int>(type: "int", nullable: false),
                    Block8 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.RenameColumn(
                name: "BlockID",
                table: "Rooms",
                newName: "Time");
        }
    }
}
