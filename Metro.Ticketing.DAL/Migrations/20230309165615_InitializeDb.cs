using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metro.Ticketing.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PassengerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fare = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatNum = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "passenger",
                columns: table => new
                {
                    PassengerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassengerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passenger", x => x.PassengerId);
                });

            migrationBuilder.CreateTable(
                name: "trains",
                columns: table => new
                {
                    TrainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(25)", nullable: false),
                    ArrivalTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trains", x => x.TrainId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "varchar(25)", nullable: false),
                    Role = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fare = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TransactionStatus = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_transaction_bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "bookings",
                        principalColumn: "BookingId");
                });

            migrationBuilder.CreateTable(
                name: "seat",
                columns: table => new
                {
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seat", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_seat_trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "trains",
                        principalColumn: "TrainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bankCred",
                columns: table => new
                {
                    BankCredId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankName = table.Column<string>(type: "varchar(50)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankCred", x => x.BankCredId);
                    table.ForeignKey(
                        name: "FK_bankCred_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_tickets_transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "transaction",
                        principalColumn: "TransactionId");
                    table.ForeignKey(
                        name: "FK_tickets_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bankCred_UserId",
                table: "bankCred",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_seat_TrainId",
                table: "seat",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_TransactionId",
                table: "tickets",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_UserId",
                table: "tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_BookingId",
                table: "transaction",
                column: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bankCred");

            migrationBuilder.DropTable(
                name: "passenger");

            migrationBuilder.DropTable(
                name: "seat");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "trains");

            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "bookings");
        }
    }
}
