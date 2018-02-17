using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarService.Service.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Reservations_AspNetUsers_MechanicId",
            //    table: "Reservations");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Reservations_AspNetUsers_PartnerId",
            //    table: "Reservations");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Worksheets_AspNetUsers_MechanicId",
            //    table: "Worksheets");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Worksheets_AspNetUsers_PartnerId",
            //    table: "Worksheets");

            //migrationBuilder.DropIndex(
            //    name: "IX_Worksheets_MechanicId",
            //    table: "Worksheets");

            //migrationBuilder.DropIndex(
            //    name: "IX_Worksheets_PartnerId",
            //    table: "Worksheets");

            //migrationBuilder.DropIndex(
            //    name: "IX_Reservations_MechanicId",
            //    table: "Reservations");

            //migrationBuilder.DropIndex(
            //    name: "IX_Reservations_PartnerId",
            //    table: "Reservations");

            //migrationBuilder.DropColumn(
            //    name: "MechanicId",
            //    table: "Worksheets");

            //migrationBuilder.DropColumn(
            //    name: "PartnerId",
            //    table: "Worksheets");

            //migrationBuilder.DropColumn(
            //    name: "MechanicId",
            //    table: "Reservations");

            //migrationBuilder.DropColumn(
            //    name: "PartnerId",
            //    table: "Reservations");

            //migrationBuilder.AddColumn<string>(
            //    name: "WorksheetMechanicId",
            //    table: "Worksheets",
            //    type: "nvarchar(450)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "WorksheetPartnerId",
            //    table: "Worksheets",
            //    type: "nvarchar(450)",
            //    nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorksheetReservationId",
                table: "Worksheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "WorksheetMaterial",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "ReservationMechanicId",
            //    table: "Reservations",
            //    type: "nvarchar(450)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "ReservationPartnerId",
            //    table: "Reservations",
            //    type: "nvarchar(450)",
            //    nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Materials",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            //migrationBuilder.CreateIndex(
            //    name: "IX_Worksheets_WorksheetMechanicId",
            //    table: "Worksheets",
            //    column: "WorksheetMechanicId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Worksheets_WorksheetPartnerId",
            //    table: "Worksheets",
            //    column: "WorksheetPartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_WorksheetReservationId",
                table: "Worksheets",
                column: "WorksheetReservationId",
                unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reservations_ReservationMechanicId",
            //    table: "Reservations",
            //    column: "ReservationMechanicId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reservations_ReservationPartnerId",
            //    table: "Reservations",
            //    column: "ReservationPartnerId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Reservations_AspNetUsers_ReservationMechanicId",
            //    table: "Reservations",
            //    column: "ReservationMechanicId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Reservations_AspNetUsers_ReservationPartnerId",
            //    table: "Reservations",
            //    column: "ReservationPartnerId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Worksheets_AspNetUsers_WorksheetMechanicId",
            //    table: "Worksheets",
            //    column: "WorksheetMechanicId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Worksheets_AspNetUsers_WorksheetPartnerId",
            //    table: "Worksheets",
            //    column: "WorksheetPartnerId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheets_Reservations_WorksheetReservationId",
                table: "Worksheets",
                column: "WorksheetReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ReservationMechanicId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ReservationPartnerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Worksheets_AspNetUsers_WorksheetMechanicId",
                table: "Worksheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worksheets_AspNetUsers_WorksheetPartnerId",
                table: "Worksheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worksheets_Reservations_WorksheetReservationId",
                table: "Worksheets");

            migrationBuilder.DropIndex(
                name: "IX_Worksheets_WorksheetMechanicId",
                table: "Worksheets");

            migrationBuilder.DropIndex(
                name: "IX_Worksheets_WorksheetPartnerId",
                table: "Worksheets");

            migrationBuilder.DropIndex(
                name: "IX_Worksheets_WorksheetReservationId",
                table: "Worksheets");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationMechanicId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationPartnerId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "WorksheetMechanicId",
                table: "Worksheets");

            migrationBuilder.DropColumn(
                name: "WorksheetPartnerId",
                table: "Worksheets");

            migrationBuilder.DropColumn(
                name: "WorksheetReservationId",
                table: "Worksheets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "WorksheetMaterial");

            migrationBuilder.DropColumn(
                name: "ReservationMechanicId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationPartnerId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "MechanicId",
                table: "Worksheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartnerId",
                table: "Worksheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MechanicId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartnerId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Materials",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_MechanicId",
                table: "Worksheets",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_PartnerId",
                table: "Worksheets",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MechanicId",
                table: "Reservations",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PartnerId",
                table: "Reservations",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_MechanicId",
                table: "Reservations",
                column: "MechanicId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_PartnerId",
                table: "Reservations",
                column: "PartnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheets_AspNetUsers_MechanicId",
                table: "Worksheets",
                column: "MechanicId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheets_AspNetUsers_PartnerId",
                table: "Worksheets",
                column: "PartnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
