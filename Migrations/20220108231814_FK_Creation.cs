using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meeting_Minutes.Migrations
{
    public partial class FK_Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "FollowUps",
                newName: "MeetingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingsParticipants_MeetingId",
                table: "MeetingsParticipants",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_MeetingId",
                table: "MeetingItems",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUps_MeetingItemId",
                table: "FollowUps",
                column: "MeetingItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowUps_MeetingItems_MeetingItemId",
                table: "FollowUps",
                column: "MeetingItemId",
                principalTable: "MeetingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingItems_Meetings_MeetingId",
                table: "MeetingItems",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingsParticipants_Meetings_MeetingId",
                table: "MeetingsParticipants",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowUps_MeetingItems_MeetingItemId",
                table: "FollowUps");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingItems_Meetings_MeetingId",
                table: "MeetingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingsParticipants_Meetings_MeetingId",
                table: "MeetingsParticipants");

            migrationBuilder.DropIndex(
                name: "IX_MeetingsParticipants_MeetingId",
                table: "MeetingsParticipants");

            migrationBuilder.DropIndex(
                name: "IX_MeetingItems_MeetingId",
                table: "MeetingItems");

            migrationBuilder.DropIndex(
                name: "IX_FollowUps_MeetingItemId",
                table: "FollowUps");

            migrationBuilder.RenameColumn(
                name: "MeetingItemId",
                table: "FollowUps",
                newName: "ItemId");
        }
    }
}
