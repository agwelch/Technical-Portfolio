using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingFinal2024.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProjectsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Projects_ParticipatingProjectsProjectID",
                table: "ProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Users_UsersUserID",
                table: "ProjectUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectUser",
                table: "ProjectUser");

            migrationBuilder.RenameTable(
                name: "ProjectUser",
                newName: "UserProjects");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectUser_UsersUserID",
                table: "UserProjects",
                newName: "IX_UserProjects_UsersUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProjects",
                table: "UserProjects",
                columns: new[] { "ParticipatingProjectsProjectID", "UsersUserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_Projects_ParticipatingProjectsProjectID",
                table: "UserProjects",
                column: "ParticipatingProjectsProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_Users_UsersUserID",
                table: "UserProjects",
                column: "UsersUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_Projects_ParticipatingProjectsProjectID",
                table: "UserProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_Users_UsersUserID",
                table: "UserProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProjects",
                table: "UserProjects");

            migrationBuilder.RenameTable(
                name: "UserProjects",
                newName: "ProjectUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserProjects_UsersUserID",
                table: "ProjectUser",
                newName: "IX_ProjectUser_UsersUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectUser",
                table: "ProjectUser",
                columns: new[] { "ParticipatingProjectsProjectID", "UsersUserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_Projects_ParticipatingProjectsProjectID",
                table: "ProjectUser",
                column: "ParticipatingProjectsProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_Users_UsersUserID",
                table: "ProjectUser",
                column: "UsersUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
