using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scaffold.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    League = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    EYear = table.Column<int>(type: "int", nullable: true),
                    StadiumName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teams__123AE7B910C8BF0E", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ShirtNumber = table.Column<int>(type: "int", nullable: true),
                    NumberOfGoals = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Players__4A4E74A8B59801F2", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK__Players__TeamID__398D8EEE",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
