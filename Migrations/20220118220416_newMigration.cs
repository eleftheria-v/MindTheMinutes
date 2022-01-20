using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meeting_Minutes.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParticipantsId",
                table: "MeetingsParticipants");

            migrationBuilder.AddColumn<string>(
                name: "Participant",
                table: "MeetingsParticipants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Participant",
                table: "MeetingsParticipants");

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantsId",
                table: "MeetingsParticipants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
