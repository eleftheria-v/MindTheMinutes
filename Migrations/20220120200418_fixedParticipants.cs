using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meeting_Minutes.Migrations
{
    public partial class fixedParticipants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExternalParticipants",
                table: "Meetings",
                newName: "Participants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Participants",
                table: "Meetings",
                newName: "ExternalParticipants");
        }
    }
}
