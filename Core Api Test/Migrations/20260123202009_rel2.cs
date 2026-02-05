using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Api_Test.Migrations
{
    /// <inheritdoc />
    public partial class rel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Reservations",
                newName: "UserID");

            migrationBuilder.AddColumn<int>(
                name: "MovieEventId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_EventId",
                table: "Seats",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MovieEventId",
                table: "Reservations",
                column: "MovieEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SeatId",
                table: "Reservations",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserID",
                table: "Reservations",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Events_MovieEventId",
                table: "Reservations",
                column: "MovieEventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seats_SeatId",
                table: "Reservations",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserID",
                table: "Reservations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Events_EventId",
                table: "Seats",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Events_MovieEventId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seats_SeatId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Events_EventId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_EventId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_MovieEventId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_SeatId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "MovieEventId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Reservations",
                newName: "EventId");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
