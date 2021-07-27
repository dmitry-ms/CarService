using Microsoft.EntityFrameworkCore.Migrations;

namespace CarService.Data.EF.Migrations
{
    public partial class add_common_type_engine_transmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Engine_EngineId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Transmission_TransmissionId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transmission",
                table: "Transmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Engine",
                table: "Engine");

            migrationBuilder.RenameTable(
                name: "Transmission",
                newName: "Transmissions");

            migrationBuilder.RenameTable(
                name: "Engine",
                newName: "Engines");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transmissions",
                table: "Transmissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Engines",
                table: "Engines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Engines_EngineId",
                table: "Vehicles",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Transmissions_TransmissionId",
                table: "Vehicles",
                column: "TransmissionId",
                principalTable: "Transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Engines_EngineId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Transmissions_TransmissionId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transmissions",
                table: "Transmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Engines",
                table: "Engines");

            migrationBuilder.RenameTable(
                name: "Transmissions",
                newName: "Transmission");

            migrationBuilder.RenameTable(
                name: "Engines",
                newName: "Engine");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transmission",
                table: "Transmission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Engine",
                table: "Engine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Engine_EngineId",
                table: "Vehicles",
                column: "EngineId",
                principalTable: "Engine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Transmission_TransmissionId",
                table: "Vehicles",
                column: "TransmissionId",
                principalTable: "Transmission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
