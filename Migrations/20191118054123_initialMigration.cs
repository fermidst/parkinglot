using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ParkingLot.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    location_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.location_id);
                });

            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    owner_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ownername = table.Column<string>(name: "owner name", nullable: false),
                    phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.owner_id);
                });

            migrationBuilder.CreateTable(
                name: "rate",
                columns: table => new
                {
                    rate_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(nullable: false),
                    cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rate", x => x.rate_id);
                });

            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    registration_number = table.Column<string>(nullable: false),
                    owner_id = table.Column<long>(nullable: false),
                    vehicle_brand = table.Column<string>(nullable: false),
                    color = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.registration_number);
                    table.ForeignKey(
                        name: "FK_car_owner_owner_id",
                        column: x => x.owner_id,
                        principalTable: "owner",
                        principalColumn: "owner_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    ticket_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    registration_number = table.Column<string>(nullable: false),
                    arrival_date = table.Column<DateTime>(nullable: false),
                    departure_date = table.Column<DateTime>(nullable: false),
                    car_location = table.Column<long>(nullable: false),
                    rate = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.ticket_id);
                    table.ForeignKey(
                        name: "FK_ticket_location_car_location",
                        column: x => x.car_location,
                        principalTable: "location",
                        principalColumn: "location_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticket_rate_rate",
                        column: x => x.rate,
                        principalTable: "rate",
                        principalColumn: "rate_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticket_car_registration_number",
                        column: x => x.registration_number,
                        principalTable: "car",
                        principalColumn: "registration_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_car_owner_id",
                table: "car",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_car_location",
                table: "ticket",
                column: "car_location");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_rate",
                table: "ticket",
                column: "rate");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_registration_number",
                table: "ticket",
                column: "registration_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "rate");

            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "owner");
        }
    }
}
