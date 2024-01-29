using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MehdiRahimiProject1.Migrations
{
    /// <inheritdoc />
    public partial class mio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passenger_Buss_BussId",
                table: "Passenger");

            migrationBuilder.AlterColumn<int>(
                name: "BussId",
                table: "Passenger",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Passenger_Buss_BussId",
                table: "Passenger",
                column: "BussId",
                principalTable: "Buss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passenger_Buss_BussId",
                table: "Passenger");

            migrationBuilder.AlterColumn<int>(
                name: "BussId",
                table: "Passenger",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Passenger_Buss_BussId",
                table: "Passenger",
                column: "BussId",
                principalTable: "Buss",
                principalColumn: "Id");
        }
    }
}
