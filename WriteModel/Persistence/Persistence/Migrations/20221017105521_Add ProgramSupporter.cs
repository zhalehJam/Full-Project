using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddProgramSupporter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramSupporter",
                schema: "TicketContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    SupporterPersonID = table.Column<int>(type: "Int", nullable: false),
                    Program = table.Column<Guid>(type: "UniqueIdentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramSupporter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramSupporter_Program_Program",
                        column: x => x.Program,
                        principalSchema: "TicketContext",
                        principalTable: "Program",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramSupporter_Program",
                schema: "TicketContext",
                table: "ProgramSupporter",
                column: "Program");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramSupporter",
                schema: "TicketContext");
        }
    }
}
