using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MehdiRahimiProject1.Migrations
{
    /// <inheritdoc />
    public partial class miomio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passenger_PassengerId",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservedTicketCount",
                table: "Buss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Passenger_PassengerId",
                table: "Ticket",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passenger_PassengerId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ReservedTicketCount",
                table: "Buss");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Passenger_PassengerId",
                table: "Ticket",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id");
        }
    }
}
