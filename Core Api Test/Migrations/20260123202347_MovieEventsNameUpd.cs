using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Api_Test.Migrations
{
    /// <inheritdoc />
    public partial class MovieEventsNameUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Events_MovieEventId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Events_EventId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "MovieEvents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieEvents",
                table: "MovieEvents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_MovieEvents_MovieEventId",
                table: "Reservations",
                column: "MovieEventId",
                principalTable: "MovieEvents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_MovieEvents_EventId",
                table: "Seats",
                column: "EventId",
                principalTable: "MovieEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_MovieEvents_MovieEventId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_MovieEvents_EventId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieEvents",
                table: "MovieEvents");

            migrationBuilder.RenameTable(
                name: "MovieEvents",
                newName: "Events");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Events_MovieEventId",
                table: "Reservations",
                column: "MovieEventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Events_EventId",
                table: "Seats",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
