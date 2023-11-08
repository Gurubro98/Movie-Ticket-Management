using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Ticket_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Movies");

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
        }
    }
}
