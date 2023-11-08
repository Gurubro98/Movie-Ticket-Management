using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Ticket_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class addBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingCarts_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fbef032-4d12-4eab-9408-59f9cd1938b0", "AQAAAAIAAYagAAAAEM6/xERHR8s0iIcZxf+Jk9eFzF72V8WZ5W62JzYac9XB6me8NsQMoZa9b1pK5S39gA==", "a554f7e9-efdf-4a40-b7d6-1795d5901095" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "061605cc-9249-4529-a775-5d395da7d995", "AQAAAAIAAYagAAAAEAxGndCA22ZiUj/xAoLhvFIBPDF87wD77zvPTeKDrx1xIUhtHeRBAvo2GdL0yaV2iA==", "f56c7eec-73e9-487f-947c-b6ccd13a7adf" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingCarts_MovieId",
                table: "BookingCarts",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCarts_UserId",
                table: "BookingCarts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingCarts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5e0df37-28e2-4e0b-b220-057f83c40137", "AQAAAAIAAYagAAAAEMIPPpwDs6hc3pRw+CeQV1NQ83ebzfxDOCGu7ouP20tJBuyIMwFUszU06w+znhTmhQ==", "a58f1a5b-e962-4c25-8b20-d7cdd515949a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "725b9599-7849-4f71-8f2a-a5a69bae291c", "AQAAAAIAAYagAAAAEO3c7NZe8+l/ivV1LS6iNy2alIGKHWrJIVirWApN6zefRCWkiV4YvAxDkPAeLXb2Fg==", "61b8ef2a-5e47-40bd-b0c0-a15ce1eadb5f" });
        }
    }
}
