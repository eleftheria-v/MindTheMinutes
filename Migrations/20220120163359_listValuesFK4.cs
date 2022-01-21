using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meeting_Minutes.Migrations
{
    public partial class listValuesFK4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "ListValues",
                newName: "ListTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ListValues_ListTypeID",
                table: "ListValues",
                column: "ListTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ListValues_ListTypes_ListTypeID",
                table: "ListValues",
                column: "ListTypeID",
                principalTable: "ListTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListValues_ListTypes_ListTypeID",
                table: "ListValues");

            migrationBuilder.DropIndex(
                name: "IX_ListValues_ListTypeID",
                table: "ListValues");

            migrationBuilder.RenameColumn(
                name: "ListTypeID",
                table: "ListValues",
                newName: "TypeID");
        }
    }
}
