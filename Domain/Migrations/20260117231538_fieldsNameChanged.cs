using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pressAgency.Domain.Migrations
{
    /// <inheritdoc />
    public partial class fieldsNameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
    name: "LockAt",
    table: "PostsLocks",
    newName: "LockedAt");

            migrationBuilder.RenameColumn(
                name: "LockedExpiresAt",
                table: "PostsLocks",
                newName: "LockExpiresAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
    name: "LockedAt",
    table: "PostsLocks",
    newName: "LockAt");

            migrationBuilder.RenameColumn(
                name: "LockExpiresAt",
                table: "PostsLocks",
                newName: "LockedExpiresAt");
        }
    }
}
