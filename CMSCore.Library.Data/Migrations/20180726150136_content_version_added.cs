using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCore.Library.Data.Migrations
{
    public partial class content_version_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentVersion_Content_ContentId",
                table: "ContentVersion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentVersion",
                table: "ContentVersion");

            migrationBuilder.RenameTable(
                name: "ContentVersion",
                newName: "ContentVersions");

            migrationBuilder.RenameIndex(
                name: "IX_ContentVersion_ContentId",
                table: "ContentVersions",
                newName: "IX_ContentVersions_ContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentVersions",
                table: "ContentVersions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentVersions_Content_ContentId",
                table: "ContentVersions",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentVersions_Content_ContentId",
                table: "ContentVersions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentVersions",
                table: "ContentVersions");

            migrationBuilder.RenameTable(
                name: "ContentVersions",
                newName: "ContentVersion");

            migrationBuilder.RenameIndex(
                name: "IX_ContentVersions_ContentId",
                table: "ContentVersion",
                newName: "IX_ContentVersion_ContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentVersion",
                table: "ContentVersion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentVersion_Content_ContentId",
                table: "ContentVersion",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
