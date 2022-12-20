using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class Nullableobjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ToDos_ToDoID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Topic_TopicID",
                table: "ToDos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_PersonalData_PersonalDataID",
                table: "UserData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserData",
                table: "UserData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalData",
                table: "PersonalData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "UserData",
                newName: "UserDatas");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "PersonalData",
                newName: "PersonalDatas");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_UserData_PersonalDataID",
                table: "UserDatas",
                newName: "IX_UserDatas_PersonalDataID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ToDoID",
                table: "Comments",
                newName: "IX_Comments_ToDoID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedDate",
                table: "ToDos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDatas",
                table: "UserDatas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalDatas",
                table: "PersonalDatas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User_ToDo_Relations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToDoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_ToDo_Relations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_ToDo_Relations_ToDos_ToDoID",
                        column: x => x.ToDoID,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_ToDo_Relations_UserDatas_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ToDo_Relations_ToDoID",
                table: "User_ToDo_Relations",
                column: "ToDoID");

            migrationBuilder.CreateIndex(
                name: "IX_User_ToDo_Relations_UserId",
                table: "User_ToDo_Relations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ToDos_ToDoID",
                table: "Comments",
                column: "ToDoID",
                principalTable: "ToDos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Topics_TopicID",
                table: "ToDos",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDatas_PersonalDatas_PersonalDataID",
                table: "UserDatas",
                column: "PersonalDataID",
                principalTable: "PersonalDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ToDos_ToDoID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Topics_TopicID",
                table: "ToDos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDatas_PersonalDatas_PersonalDataID",
                table: "UserDatas");

            migrationBuilder.DropTable(
                name: "User_ToDo_Relations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDatas",
                table: "UserDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalDatas",
                table: "PersonalDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "UserDatas",
                newName: "UserData");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "Topic");

            migrationBuilder.RenameTable(
                name: "PersonalDatas",
                newName: "PersonalData");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_UserDatas_PersonalDataID",
                table: "UserData",
                newName: "IX_UserData_PersonalDataID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ToDoID",
                table: "Comment",
                newName: "IX_Comment_ToDoID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedDate",
                table: "ToDos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserData",
                table: "UserData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalData",
                table: "PersonalData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ToDos_ToDoID",
                table: "Comment",
                column: "ToDoID",
                principalTable: "ToDos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Topic_TopicID",
                table: "ToDos",
                column: "TopicID",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_PersonalData_PersonalDataID",
                table: "UserData",
                column: "PersonalDataID",
                principalTable: "PersonalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
