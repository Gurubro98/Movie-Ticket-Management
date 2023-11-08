using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Ticket_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a441de7-ebd1-4a22-8642-0bae237085c8", "AQAAAAIAAYagAAAAELUFtbWeD2/BEn1BCna37Geb6EYQgLX9cSkc63grJm3BuN4L7uFFyhkyKPVA4s6uig==", "1d128d66-86d4-49c8-b8ef-ce1eb3ba8ec8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "903fbf95-a2a4-4574-85fb-33aecc2c79aa", "AQAAAAIAAYagAAAAEIrfPalIK0gwIV5xYCmBUkD/P1JB7W8VS9ACHn7bqQp9gv1VEUleK0lrstul95jufA==", "f7a81763-99d6-4f6c-b7ef-3719023ece55" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7b5c775-16ce-454f-ae44-9f368564258d", "AQAAAAIAAYagAAAAEMstMpf0+/QMs2UAWvYEr+xwmVZfIhjU/O/N8eY8RAMz941ArMpbitTC36crWkB/dg==", "80ab60ef-5884-40df-8b8b-58a6fe91221a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c658fff7-392f-4893-8ec8-96a8e320ab57", "AQAAAAIAAYagAAAAEL3UeZb2fy2Kqpt7tRvs+vYjFCEK9iIRGvlh5/cbcSJoxxYZHXOMTH4rBK5cqK4rfQ==", "19029a61-2706-48d5-b04c-c0065732d05b" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "IsBooked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "IsBooked",
                value: false);
        }
    }
}
