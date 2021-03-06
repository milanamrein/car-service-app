﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarService.Service.Migrations
{
    public partial class UpdateWorksheetsTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Worksheets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_ReservationId",
                table: "Worksheets",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheets_Reservations_ReservationId",
                table: "Worksheets",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worksheets_Reservations_ReservationId",
                table: "Worksheets");

            migrationBuilder.DropIndex(
                name: "IX_Worksheets_ReservationId",
                table: "Worksheets");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Worksheets");
        }
    }
}
