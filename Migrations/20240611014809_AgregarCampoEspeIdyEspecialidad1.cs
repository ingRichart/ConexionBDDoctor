using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Students2.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoEspeIdyEspecialidad1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<Guid>(
                name: "EspecialidadId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_EspecialidadId",
                table: "Doctors",
                column: "EspecialidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Especialidades_EspecialidadId",
                table: "Doctors",
                column: "EspecialidadId",
                principalTable: "Especialidades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Especialidades_EspecialidadId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_EspecialidadId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "EspecialidadId",
                table: "Doctors");

          
        }
    }
}
