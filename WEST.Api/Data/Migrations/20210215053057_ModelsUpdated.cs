using Microsoft.EntityFrameworkCore.Migrations;

namespace WEST.Api.Data.Migrations
{
    public partial class ModelsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Learners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Learners_UserId",
                table: "Learners",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Learners_Users_UserId",
                table: "Learners",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Learners_Users_UserId",
                table: "Learners");

            migrationBuilder.DropIndex(
                name: "IX_Learners_UserId",
                table: "Learners");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Learners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
