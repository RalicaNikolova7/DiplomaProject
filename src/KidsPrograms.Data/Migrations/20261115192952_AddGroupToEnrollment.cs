using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidsPrograms.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupToEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_GroupId",
                table: "Enrollments",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Groups_GroupId",
                table: "Enrollments",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Groups_GroupId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_GroupId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Enrollments");
        }
    }
}
