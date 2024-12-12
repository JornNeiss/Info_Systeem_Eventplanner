using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Info_Systeem_Eventplanner.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: false),
                    Participants = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AppUserUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_AppUsers_AppUserUserID",
                        column: x => x.AppUserUserID,
                        principalTable: "AppUsers",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservations_AppUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AppUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<float>(type: "real", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "UserID", "Email", "IsAdmin", "Name", "TelephoneNumber" },
                values: new object[,]
                {
                    { 1, "JornNeiss@gmail.com", false, "Jörn Neiss", null },
                    { 2, "CharlesBenschop@gmail.com", false, "Charles Benschop", null },
                    { 3, "JoopBuyt@gmail.com", false, "Joop Buyt", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "AppUserUserID", "DateTime", "EventDescription", "EventName", "ImagePath", "MaxParticipants", "Participants" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 24, 11, 48, 44, 979, DateTimeKind.Local).AddTicks(3832), "Een spannende Serie A wedstrijd tussen 2 titelkandidaten Ac Milan en Napoli.", "AC Milan - Napoli", "/images/ACMilan", 100, 0 },
                    { 2, null, new DateTime(2024, 12, 24, 11, 48, 44, 979, DateTimeKind.Local).AddTicks(3879), "De spannende 3. Bundesliga wedstrijd tussen Alemannia Aachen en RW Essen.", "Alemannia Aachen - RW Essen", "/images/Alemannia", 10000, 0 },
                    { 3, null, new DateTime(2025, 1, 8, 11, 48, 44, 979, DateTimeKind.Local).AddTicks(3882), "De derby van het zuiden de Keukenkampioen divisie wedstrijd tussen Roda JC Kerkrade en MVV Maastricht.", "Roda JC - MVV Maastricht", "/images/RodaJCMVV", 14000, 0 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationID", "Active", "EventID", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventID", "IsReserved", "TicketPrice" },
                values: new object[,]
                {
                    { 1, 1, true, 39f },
                    { 2, 2, false, 20f },
                    { 3, 3, false, 15f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_AppUserUserID",
                table: "Events",
                column: "AppUserUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EventID",
                table: "Reservations",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserID",
                table: "Reservations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventID",
                table: "Tickets",
                column: "EventID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
