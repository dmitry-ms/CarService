using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarService.Data.EF.Migrations
{
    public partial class add_serviceManRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceManRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceManId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceManRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceManRole_Person_ServiceManId",
                        column: x => x.ServiceManId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceManRole_ServiceManId",
                table: "ServiceManRole",
                column: "ServiceManId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceManRole");
        }
    }
}
