using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MehdiRahimiProject1.Migrations
{
    /// <inheritdoc />
    public partial class problems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CancelReservedTickets",
                table: "Buss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CancelSoldTickets",
                table: "Buss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservedTicketsIncome",
                table: "Buss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoldTicketsIncome",
                table: "Buss",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelReservedTickets",
                table: "Buss");

            migrationBuilder.DropColumn(
                name: "CancelSoldTickets",
                table: "Buss");

            migrationBuilder.DropColumn(
                name: "ReservedTicketsIncome",
                table: "Buss");

            migrationBuilder.DropColumn(
                name: "SoldTicketsIncome",
                table: "Buss");
        }
    }
}
