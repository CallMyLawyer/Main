using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MehdiRahimiProject1.Migrations
{
    /// <inheritdoc />
    public partial class DistenationAndOriginAndTicketPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Buss",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Buss",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TicketPrice",
                table: "Buss",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Buss");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Buss");

            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Buss");
        }
    }
}
