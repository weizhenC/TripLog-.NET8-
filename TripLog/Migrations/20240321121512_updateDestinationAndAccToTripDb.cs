using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripLog.Migrations
{
    /// <inheritdoc />
    public partial class updateDestinationAndAccToTripDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationTrip");

            migrationBuilder.DropTable(
                name: "DestinationTrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destination",
                table: "Destination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accommodation",
                table: "Accommodation");

            migrationBuilder.DropColumn(
                name: "Accommodation",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "AccommodationEmail",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "AccommodationPhone",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Trips");

            migrationBuilder.RenameTable(
                name: "Destination",
                newName: "Destinations");

            migrationBuilder.RenameTable(
                name: "Accommodation",
                newName: "Accommodations");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations",
                column: "DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accommodations",
                table: "Accommodations",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_AccommodationId",
                table: "Trips",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DestinationId",
                table: "Trips",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Accommodations_AccommodationId",
                table: "Trips",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Destinations_DestinationId",
                table: "Trips",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Accommodations_AccommodationId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Destinations_DestinationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_AccommodationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_DestinationId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accommodations",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Accommodations");

            migrationBuilder.RenameTable(
                name: "Destinations",
                newName: "Destination");

            migrationBuilder.RenameTable(
                name: "Accommodations",
                newName: "Accommodation");

            migrationBuilder.AddColumn<string>(
                name: "Accommodation",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccommodationEmail",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccommodationPhone",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destination",
                table: "Destination",
                column: "DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accommodation",
                table: "Accommodation",
                column: "AccommodationId");

            migrationBuilder.CreateTable(
                name: "AccommodationTrip",
                columns: table => new
                {
                    AccommodationId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationTrip", x => new { x.AccommodationId, x.TripId });
                    table.ForeignKey(
                        name: "FK_AccommodationTrip_Accommodation_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodation",
                        principalColumn: "AccommodationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccommodationTrip_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DestinationTrip",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationTrip", x => new { x.DestinationId, x.TripId });
                    table.ForeignKey(
                        name: "FK_DestinationTrip_Destination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destination",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinationTrip_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationTrip_TripId",
                table: "AccommodationTrip",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationTrip_TripId",
                table: "DestinationTrip",
                column: "TripId");
        }
    }
}
