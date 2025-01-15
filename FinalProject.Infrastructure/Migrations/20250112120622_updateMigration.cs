using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ReservationId",
                table: "TicketDatas",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "long");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ReservationId",
                table: "TicketDatas",
                type: "long",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
