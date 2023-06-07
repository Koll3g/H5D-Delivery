using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H5D_Delivery.Mgmt.Backend.Migrations.OrderHistory
{
    /// <inheritdoc />
    public partial class addedCustomerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "OrderHistory",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "OrderHistory");
        }
    }
}
