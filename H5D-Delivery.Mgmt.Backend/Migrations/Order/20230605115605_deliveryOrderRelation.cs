using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H5D_Delivery.Mgmt.Backend.Migrations.Order
{
    /// <inheritdoc />
    public partial class deliveryOrderRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryOrderId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedRobotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrder_DeliveryPlan_DeliveryPlanId",
                        column: x => x.DeliveryPlanId,
                        principalTable: "DeliveryPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepSequence = table.Column<int>(type: "int", nullable: false),
                    DeliveryType = table.Column<int>(type: "int", nullable: false),
                    DeliveryPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorizationKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Coordinates_X = table.Column<int>(type: "int", nullable: false),
                    Coordinates_Y = table.Column<int>(type: "int", nullable: false),
                    PlannedDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RealDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryStep_DeliveryPlan_DeliveryPlanId",
                        column: x => x.DeliveryPlanId,
                        principalTable: "DeliveryPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryOrderId",
                table: "Order",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrder_DeliveryPlanId",
                table: "DeliveryOrder",
                column: "DeliveryPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryStep_DeliveryPlanId",
                table: "DeliveryStep",
                column: "DeliveryPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryOrder_DeliveryOrderId",
                table: "Order",
                column: "DeliveryOrderId",
                principalTable: "DeliveryOrder",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryOrder_DeliveryOrderId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "DeliveryOrder");

            migrationBuilder.DropTable(
                name: "DeliveryStep");

            migrationBuilder.DropTable(
                name: "DeliveryPlan");

            migrationBuilder.DropIndex(
                name: "IX_Order_DeliveryOrderId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryOrderId",
                table: "Order");
        }
    }
}
