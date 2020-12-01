using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctoerId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctoerId",
                table: "Patients",
                column: "DoctoerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_DoctoerId",
                table: "Patients",
                column: "DoctoerId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_DoctoerId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DoctoerId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DoctoerId",
                table: "Patients");
        }
    }
}
