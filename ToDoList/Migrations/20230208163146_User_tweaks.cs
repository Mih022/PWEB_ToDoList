using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class Usertweaks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PersonalDatas_PersonalDataID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonalDataID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "PersonalDatas");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "PersonalDatas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PersonalDatas");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PersonalDatas");

            migrationBuilder.DropColumn(
                name: "PersonalDataID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "PersonalDatas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "PersonalDatas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PersonalDatas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PersonalDatas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PersonalDataID",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonalDataID",
                table: "AspNetUsers",
                column: "PersonalDataID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PersonalDatas_PersonalDataID",
                table: "AspNetUsers",
                column: "PersonalDataID",
                principalTable: "PersonalDatas",
                principalColumn: "Id");
        }
    }
}
