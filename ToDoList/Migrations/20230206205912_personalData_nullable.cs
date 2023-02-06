using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class personalDatanullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PersonalDatas_PersonalDataID",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PersonalDatas_PersonalDataID",
                table: "AspNetUsers",
                column: "PersonalDataID",
                principalTable: "PersonalDatas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PersonalDatas_PersonalDataID",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PersonalDatas_PersonalDataID",
                table: "AspNetUsers",
                column: "PersonalDataID",
                principalTable: "PersonalDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
