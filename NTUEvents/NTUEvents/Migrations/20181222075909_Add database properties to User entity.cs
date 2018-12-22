using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NTUEvents.Migrations
{
    public partial class AdddatabasepropertiestoUserentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ccas",
                columns: table => new
                {
                    CcaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Schedule = table.Column<string>(nullable: true),
                    Venue = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ccas", x => x.CcaId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CcaId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Venue = table.Column<string>(nullable: true),
                    Quota = table.Column<int>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Ccas_CcaId",
                        column: x => x.CcaId,
                        principalTable: "Ccas",
                        principalColumn: "CcaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CcaMemberships",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CcaId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcaMemberships", x => new { x.UserId, x.CcaId });
                    table.ForeignKey(
                        name: "FK_CcaMemberships_Ccas_CcaId",
                        column: x => x.CcaId,
                        principalTable: "Ccas",
                        principalColumn: "CcaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CcaMemberships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipations",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipations", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventParticipations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CcaMemberships_CcaId",
                table: "CcaMemberships",
                column: "CcaId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipations_EventId",
                table: "EventParticipations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CcaId",
                table: "Events",
                column: "CcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CcaMemberships");

            migrationBuilder.DropTable(
                name: "EventParticipations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ccas");
        }
    }
}
