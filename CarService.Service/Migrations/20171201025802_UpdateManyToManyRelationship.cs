using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarService.Service.Migrations
{
    public partial class UpdateManyToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorksheetMaterial_Materials_MaterialWorksheetId",
                table: "WorksheetMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_WorksheetMaterial_Worksheets_WorksheetMaterialId",
                table: "WorksheetMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorksheetMaterial",
                table: "WorksheetMaterial");

            migrationBuilder.DropIndex(
                name: "IX_WorksheetMaterial_WorksheetMaterialId",
                table: "WorksheetMaterial");

            migrationBuilder.RenameTable(
                name: "WorksheetMaterial",
                newName: "WorksheetMaterials");

            migrationBuilder.RenameIndex(
                name: "IX_WorksheetMaterial_MaterialWorksheetId",
                table: "WorksheetMaterials",
                newName: "IX_WorksheetMaterials_MaterialWorksheetId");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "WorksheetMaterials",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorksheetMaterials",
                table: "WorksheetMaterials",
                columns: new[] { "WorksheetMaterialId", "MaterialWorksheetId" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorksheetMaterials_Materials_MaterialWorksheetId",
                table: "WorksheetMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_WorksheetMaterials_Worksheets_WorksheetMaterialId",
                table: "WorksheetMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorksheetMaterials",
                table: "WorksheetMaterials");

            migrationBuilder.RenameTable(
                name: "WorksheetMaterials",
                newName: "WorksheetMaterial");

            migrationBuilder.RenameIndex(
                name: "IX_WorksheetMaterials_MaterialWorksheetId",
                table: "WorksheetMaterial",
                newName: "IX_WorksheetMaterial_MaterialWorksheetId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WorksheetMaterial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorksheetMaterial",
                table: "WorksheetMaterial",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetMaterial_WorksheetMaterialId",
                table: "WorksheetMaterial",
                column: "WorksheetMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorksheetMaterial_Materials_MaterialWorksheetId",
                table: "WorksheetMaterial",
                column: "MaterialWorksheetId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorksheetMaterial_Worksheets_WorksheetMaterialId",
                table: "WorksheetMaterial",
                column: "WorksheetMaterialId",
                principalTable: "Worksheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
