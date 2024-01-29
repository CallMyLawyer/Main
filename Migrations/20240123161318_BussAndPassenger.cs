using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MehdiRahimiProject1.Migrations
{
    /// <inheritdoc />
    public partial class BussAndPassenger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassengersSeat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerType = table.Column<int>(type: "int", nullable: false),
                    BussId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passenger_Buss_BussId",
                        column: x => x.BussId,
                        principalTable: "Buss",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_BussId",
                table: "Passenger",
                column: "BussId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passenger");
        }
    }
}
