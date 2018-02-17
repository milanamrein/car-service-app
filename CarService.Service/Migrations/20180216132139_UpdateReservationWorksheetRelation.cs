using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarService.Service.Migrations
{
    public partial class UpdateReservationWorksheetRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Worksheets_ReservationId",
                table: "Worksheets");

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_ReservationId",
                table: "Worksheets",
                column: "ReservationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Worksheets_ReservationId",
                table: "Worksheets");

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_ReservationId",
                table: "Worksheets",
                column: "ReservationId");
        }
    }
}
