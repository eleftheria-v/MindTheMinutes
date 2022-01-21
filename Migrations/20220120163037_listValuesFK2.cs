using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meeting_Minutes.Migrations
{
    public partial class listValuesFK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "ListValues",
                newName: "ListTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ListTypeID",
                table: "ListValues",
                newName: "TypeID");
        }
    }
}
