using Microsoft.EntityFrameworkCore.Migrations;

namespace WEST.Api.Data.Migrations
{
    public partial class ReWriteDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Learners_LearnerId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Learners_Group_GroupId",
                table: "Learners");

            migrationBuilder.DropForeignKey(
                name: "FK_Learners_Users_UserId",
                table: "Learners");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organisations_OrganisationId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organisations",
                table: "Organisations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Learners",
                table: "Learners");

            migrationBuilder.DropIndex(
                name: "IX_Learners_GroupId",
                table: "Learners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LearnerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Learners");

            migrationBuilder.DropColumn(
                name: "LearnerId",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Organisations",
                newName: "Organisation");

            migrationBuilder.RenameTable(
                name: "Learners",
                newName: "Learner");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "User",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_OrganisationId",
                table: "User",
                newName: "IX_User_OrganisationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Learner",
                newName: "LearnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Learners_UserId",
                table: "Learner",
                newName: "IX_Learner_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Learner",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organisation",
                table: "Organisation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Learner",
                table: "Learner",
                column: "LearnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LearnerCourse",
                columns: table => new
                {
                    LearnerId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnerCourse", x => new { x.LearnerId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_LearnerCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearnerCourse_Learner_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "Learner",
                        principalColumn: "LearnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearnerGroup",
                columns: table => new
                {
                    LearnerId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnerGroup", x => new { x.LearnerId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_LearnerGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearnerGroup_Learner_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "Learner",
                        principalColumn: "LearnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_TypeId",
                table: "User",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerCourse_CourseId",
                table: "LearnerCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerGroup_GroupId",
                table: "LearnerGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerGroup_LearnerId",
                table: "LearnerGroup",
                column: "LearnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Learner_User_UserId",
                table: "Learner",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Organisation_OrganisationId",
                table: "User",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserTypes_TypeId",
                table: "User",
                column: "TypeId",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Learner_User_UserId",
                table: "Learner");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Organisation_OrganisationId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserTypes_TypeId",
                table: "User");

            migrationBuilder.DropTable(
                name: "LearnerCourse");

            migrationBuilder.DropTable(
                name: "LearnerGroup");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TypeId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organisation",
                table: "Organisation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Learner",
                table: "Learner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Organisation",
                newName: "Organisations");

            migrationBuilder.RenameTable(
                name: "Learner",
                newName: "Learners");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Users",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_User_OrganisationId",
                table: "Users",
                newName: "IX_Users_OrganisationId");

            migrationBuilder.RenameColumn(
                name: "LearnerId",
                table: "Learners",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Learner_UserId",
                table: "Learners",
                newName: "IX_Learners_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Learners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Learners",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LearnerId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organisations",
                table: "Organisations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Learners",
                table: "Learners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Learners_GroupId",
                table: "Learners",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LearnerId",
                table: "Courses",
                column: "LearnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Learners_LearnerId",
                table: "Courses",
                column: "LearnerId",
                principalTable: "Learners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Learners_Group_GroupId",
                table: "Learners",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Learners_Users_UserId",
                table: "Learners",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organisations_OrganisationId",
                table: "Users",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
