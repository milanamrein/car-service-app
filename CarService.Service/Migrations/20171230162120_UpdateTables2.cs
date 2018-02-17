using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarService.Service.Migrations
{
    public partial class UpdateTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ReservationMechanicId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ReservationPartnerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorksheetMaterials_Materials_MaterialWorksheetId",
                table: "WorksheetMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_WorksheetMaterials_Worksheets_WorksheetMaterialId",
                table: "WorksheetMaterials");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorksheetMaterials",
                table: "WorksheetMaterials");

            migrationBuilder.DropIndex(
                name: "IX_WorksheetMaterials_MaterialWorksheetId",
                table: "WorksheetMaterials");

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
                name: "WorksheetMaterialId",
                table: "WorksheetMaterials");

            migrationBuilder.DropColumn(
                name: "MaterialWorksheetId",
                table: "WorksheetMaterials");

            migrationBuilder.DropColumn(
                name: "ReservationMechanicId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationPartnerId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "MechanicId",
                table: "Worksheets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartnerId",
                table: "Worksheets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Worksheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WorksheetMaterials");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WorksheetMaterials",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "WorksheetMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorksheetId",
                table: "WorksheetMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MechanicId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartnerId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorksheetId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorksheetMaterials",
                table: "WorksheetMaterials",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_MechanicId",
                table: "Worksheets",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_PartnerId",
                table: "Worksheets",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_ReservationId",
                table: "Worksheets",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetMaterials_MaterialId",
                table: "WorksheetMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetMaterials_WorksheetId",
                table: "WorksheetMaterials",
                column: "WorksheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MechanicId",
                table: "Reservations",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PartnerId",
                table: "Reservations",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_WorksheetId",
                table: "Reservations",
                column: "WorksheetId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Reservations_Worksheets_WorksheetId",
                table: "Reservations",
                column: "WorksheetId",
                principalTable: "Worksheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorksheetMaterials_Materials_MaterialId",
                table: "WorksheetMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorksheetMaterials_Worksheets_WorksheetId",
                table: "WorksheetMaterials",
                column: "WorksheetId",
                principalTable: "Worksheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheets_Reservations_ReservationId",
                table: "Worksheets",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_MechanicId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_PartnerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Worksheets_WorksheetId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorksheetMaterials_Materials_MaterialId",
                table: "WorksheetMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_WorksheetMaterials_Worksheets_WorksheetId",
                table: "WorksheetMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_Worksheets_AspNetUsers_MechanicId",
                table: "Worksheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worksheets_AspNetUsers_PartnerId",
                table: "Worksheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worksheets_Reservations_ReservationId",
                table: "Worksheets");

            migrationBuilder.DropIndex(
                name: "IX_Worksheets_MechanicId",
                table: "Worksheets");

            migrationBuilder.DropIndex(
                name: "IX_Worksheets_PartnerId",
                table: "Worksheets");

            migrationBuilder.DropIndex(
                name: "IX_Worksheets_ReservationId",
                table: "Worksheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorksheetMaterials",
                table: "WorksheetMaterials");

            migrationBuilder.DropIndex(
                name: "IX_WorksheetMaterials_MaterialId",
                table: "WorksheetMaterials");

            migrationBuilder.DropIndex(
                name: "IX_WorksheetMaterials_WorksheetId",
                table: "WorksheetMaterials");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_MechanicId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PartnerId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_WorksheetId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "MechanicId",
                table: "Worksheets");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "Worksheets");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Worksheets");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "WorksheetMaterials");

            migrationBuilder.DropColumn(
                name: "WorksheetId",
                table: "WorksheetMaterials");

            migrationBuilder.DropColumn(
                name: "MechanicId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "WorksheetId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "WorksheetMechanicId",
                table: "Worksheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorksheetPartnerId",
                table: "Worksheets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorksheetReservationId",
                table: "Worksheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WorksheetMaterials",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "WorksheetMaterialId",
                table: "WorksheetMaterials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialWorksheetId",
                table: "WorksheetMaterials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReservationMechanicId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReservationPartnerId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorksheetMaterials",
                table: "WorksheetMaterials",
                columns: new[] { "WorksheetMaterialId", "MaterialWorksheetId" });

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_WorksheetMechanicId",
                table: "Worksheets",
                column: "WorksheetMechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_WorksheetPartnerId",
                table: "Worksheets",
                column: "WorksheetPartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_WorksheetReservationId",
                table: "Worksheets",
                column: "WorksheetReservationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetMaterials_MaterialWorksheetId",
                table: "WorksheetMaterials",
                column: "MaterialWorksheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationMechanicId",
                table: "Reservations",
                column: "ReservationMechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationPartnerId",
                table: "Reservations",
                column: "ReservationPartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ReservationMechanicId",
                table: "Reservations",
                column: "ReservationMechanicId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ReservationPartnerId",
                table: "Reservations",
                column: "ReservationPartnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorksheetMaterials_Materials_MaterialWorksheetId",
                table: "WorksheetMaterials",
                column: "MaterialWorksheetId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorksheetMaterials_Worksheets_WorksheetMaterialId",
                table: "WorksheetMaterials",
                column: "WorksheetMaterialId",
                principalTable: "Worksheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheets_AspNetUsers_WorksheetMechanicId",
                table: "Worksheets",
                column: "WorksheetMechanicId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheets_AspNetUsers_WorksheetPartnerId",
                table: "Worksheets",
                column: "WorksheetPartnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheets_Reservations_WorksheetReservationId",
                table: "Worksheets",
                column: "WorksheetReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
