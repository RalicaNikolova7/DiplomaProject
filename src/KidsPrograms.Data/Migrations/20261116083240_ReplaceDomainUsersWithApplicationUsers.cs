using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidsPrograms.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceDomainUsersWithApplicationUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DomainUsers_DomainUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildParents_DomainUsers_ParentsId",
                table: "ChildParents");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_DomainUsers_UserId",
                table: "Instructors");

            migrationBuilder.DropTable(
                name: "DomainUsers");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildParents",
                table: "ChildParents");

            migrationBuilder.DropIndex(
                name: "IX_ChildParents_ParentsId",
                table: "ChildParents");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DomainUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "DomainUserId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ParentsId",
                table: "ChildParents",
                newName: "ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildParents",
                table: "ChildParents",
                columns: new[] { "ApplicationUserId", "ChildrenId" });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_ApplicationUserId",
                table: "Instructors",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChildParents_ChildrenId",
                table: "ChildParents",
                column: "ChildrenId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildParents_AspNetUsers_ApplicationUserId",
                table: "ChildParents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AspNetUsers_ApplicationUserId",
                table: "Instructors",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildParents_AspNetUsers_ApplicationUserId",
                table: "ChildParents");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AspNetUsers_ApplicationUserId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_ApplicationUserId",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildParents",
                table: "ChildParents");

            migrationBuilder.DropIndex(
                name: "IX_ChildParents_ChildrenId",
                table: "ChildParents");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ChildParents",
                newName: "ParentsId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DomainUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildParents",
                table: "ChildParents",
                columns: new[] { "ChildrenId", "ParentsId" });

            migrationBuilder.CreateTable(
                name: "DomainUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChildParents_ParentsId",
                table: "ChildParents",
                column: "ParentsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DomainUserId",
                table: "AspNetUsers",
                column: "DomainUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DomainUsers_DomainUserId",
                table: "AspNetUsers",
                column: "DomainUserId",
                principalTable: "DomainUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildParents_DomainUsers_ParentsId",
                table: "ChildParents",
                column: "ParentsId",
                principalTable: "DomainUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_DomainUsers_UserId",
                table: "Instructors",
                column: "UserId",
                principalTable: "DomainUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
