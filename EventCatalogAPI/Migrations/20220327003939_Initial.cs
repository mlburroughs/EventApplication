using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventMetroCities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetroCity = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMetroCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventOrganizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrganizerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizerBio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizerPageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOrganizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    MainEventImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalEventImagesUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalEventImagesUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalEventImagesUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalEventImagesUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    RefundPolicy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tag1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    EventCategoryId = table.Column<int>(type: "int", nullable: false),
                    EventMetroCityId = table.Column<int>(type: "int", nullable: false),
                    EventOrganizerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventCategories_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventMetroCities_EventMetroCityId",
                        column: x => x.EventMetroCityId,
                        principalTable: "EventMetroCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventOrganizers_EventOrganizerId",
                        column: x => x.EventOrganizerId,
                        principalTable: "EventOrganizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventCategoryId",
                table: "Events",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventMetroCityId",
                table: "Events",
                column: "EventMetroCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventOrganizerId",
                table: "Events",
                column: "EventOrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropTable(
                name: "EventMetroCities");

            migrationBuilder.DropTable(
                name: "EventOrganizers");

            migrationBuilder.DropTable(
                name: "EventTypes");
        }
    }
}
