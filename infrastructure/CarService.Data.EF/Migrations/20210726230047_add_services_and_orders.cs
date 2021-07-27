using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarService.Data.EF.Migrations
{
    public partial class add_services_and_orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ClientCars_CarId",
                        column: x => x.CarId,
                        principalTable: "ClientCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxBatteryCapacity = table.Column<int>(type: "int", nullable: true),
                    MinBatteryCapacity = table.Column<int>(type: "int", nullable: true),
                    MaxEngineVolume = table.Column<int>(type: "int", nullable: true),
                    MinEngineVolume = table.Column<int>(type: "int", nullable: true),
                    MaxNumberCylinders = table.Column<int>(type: "int", nullable: true),
                    MinNumberCylinders = table.Column<int>(type: "int", nullable: true),
                    MaxNumberValves = table.Column<int>(type: "int", nullable: true),
                    MinNumberValves = table.Column<int>(type: "int", nullable: true),
                    DEF = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarParametersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    PriceByFourWheelDrive = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceByFrontWheelDriveOrMono = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceByRearWheelDrive = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TimeByFourWheelDrive = table.Column<TimeSpan>(type: "time", nullable: true),
                    TimeByFrontWheelDriveOrMono = table.Column<TimeSpan>(type: "time", nullable: true),
                    TimeByRearWheelDrive = table.Column<TimeSpan>(type: "time", nullable: true),
                    PriceByOneCylinder = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TimeByOneCylinder = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseCosts_Parameters_CarParametersId",
                        column: x => x.CarParametersId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_BaseCosts_CostsId",
                        column: x => x.CostsId,
                        principalTable: "BaseCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderService",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderService", x => new { x.OrdersId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_OrderService_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseCosts_CarParametersId",
                table: "BaseCosts",
                column: "CarParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderService_ServicesId",
                table: "OrderService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CostsId",
                table: "Services",
                column: "CostsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderService");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "BaseCosts");

            migrationBuilder.DropTable(
                name: "Parameters");
        }
    }
}
