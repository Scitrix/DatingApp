using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class protocolUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Protocols_AspNetUsers_CreatorId",
                table: "Protocols");

            migrationBuilder.DropIndex(
                name: "IX_Protocols_CreatorId",
                table: "Protocols");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Protocols_CreatorId",
                table: "Protocols",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Protocols_AspNetUsers_CreatorId",
                table: "Protocols",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
