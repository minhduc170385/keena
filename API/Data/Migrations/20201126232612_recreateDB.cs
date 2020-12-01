using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class recreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_DoctoerId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "DoctoerId",
                table: "Patients",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_DoctoerId",
                table: "Patients",
                newName: "IX_Patients_DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_DoctorId",
                table: "Patients",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_DoctorId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Patients",
                newName: "DoctoerId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                newName: "IX_Patients_DoctoerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_DoctoerId",
                table: "Patients",
                column: "DoctoerId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
