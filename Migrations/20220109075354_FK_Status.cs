using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meeting_Minutes.Migrations
{
    public partial class FK_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListValuesID",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ListValuesID",
                table: "Meetings",
                column: "ListValuesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_ListValues_ListValuesID",
                table: "Meetings",
                column: "ListValuesID",
                principalTable: "ListValues",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_ListValues_ListValuesID",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_ListValuesID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "ListValuesID",
                table: "Meetings");
        }
    }
}
