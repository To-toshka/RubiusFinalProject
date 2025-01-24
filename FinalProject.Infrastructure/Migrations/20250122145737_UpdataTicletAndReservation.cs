using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdataTicletAndReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Operators_OperatorId1",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OperatorId1",
                table: "Tickets");

            migrationBuilder.AlterColumn<long>(
                name: "OperatorId",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "TicketNumber",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReservationNumber",
                table: "Reservations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OperatorId",
                table: "Tickets",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Operators_OperatorId",
                table: "Tickets",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Operators_OperatorId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OperatorId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ReservationNumber",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "OperatorId",
                table: "Tickets",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "OperatorId1",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OperatorId1",
                table: "Tickets",
                column: "OperatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Operators_OperatorId1",
                table: "Tickets",
                column: "OperatorId1",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
