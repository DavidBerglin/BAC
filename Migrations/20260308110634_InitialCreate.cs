using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    userRole = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "OwnerId" },
                values: new object[,]
                {
                    { 1, "Olles hemliga recept", "Olle" },
                    { 2, "Admin: Serverlösenord 'Admin123'", "Admin" },
                    { 3, "Sara: Min dagbok", "Sara" },
                    { 4, "Admin: Mötesanteckningar", "Admin" },
                    { 5, "Olle: Tandläkare kl 10", "Olle" },
                    { 6, "Sara: Köp presenter", "Sara" },
                    { 7, "Admin: Budget 2026", "Admin" },
                    { 8, "Olle: Kom ihåg mjölk", "Olle" },
                    { 9, "Sara: Semesterplaner", "Sara" },
                    { 10, "Admin: Systemfixar", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Name", "password", "userRole" },
                values: new object[,]
                {
                    { 1, "Admin", "password123", 1 },
                    { 2, "Olle", "123", 0 },
                    { 3, "Sara", "password", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
