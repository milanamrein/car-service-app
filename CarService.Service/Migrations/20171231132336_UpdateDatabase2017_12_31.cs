using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarService.Service.Migrations
{
    public partial class UpdateDatabase2017_12_31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Worksheets_WorksheetId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_WorksheetId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "WorksheetId",
                table: "Reservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorksheetId",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_WorksheetId",
                table: "Reservations",
                column: "WorksheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Worksheets_WorksheetId",
                table: "Reservations",
                column: "WorksheetId",
                principalTable: "Worksheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
