using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackerBuddy.Sql.Migrations
{
    /// <inheritdoc />
    public partial class TeamupRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamupRequestID",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamupRequestID1",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamupRequests",
                columns: table => new
                {
                    TeamupRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterID = table.Column<int>(type: "int", nullable: false),
                    ReceiverID = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamupRequests", x => x.TeamupRequestID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TeamupRequestID",
                table: "Persons",
                column: "TeamupRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TeamupRequestID1",
                table: "Persons",
                column: "TeamupRequestID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_TeamupRequests_TeamupRequestID",
                table: "Persons",
                column: "TeamupRequestID",
                principalTable: "TeamupRequests",
                principalColumn: "TeamupRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_TeamupRequests_TeamupRequestID1",
                table: "Persons",
                column: "TeamupRequestID1",
                principalTable: "TeamupRequests",
                principalColumn: "TeamupRequestID");

            migrationBuilder.InsertData(
           table: "Skills",
           columns: new[] { "SkillID", "SkillName" },
           values: new object[,]
           {
                { 1, "Frontend Development" },
                { 2, "Backend Development" },
                { 3, "Database Administration" },
                { 4, "Cloud Computing" },
                { 5, "DevOps" },
                { 6, "AI/ML Development" },
                { 7, "UI/UX Design" },
                { 8, "Mobile App Development" },
                { 9, "Cybersecurity" },
                { 10, "Full Stack Development" }
           });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_TeamupRequests_TeamupRequestID",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_TeamupRequests_TeamupRequestID1",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "TeamupRequests");

            migrationBuilder.DropIndex(
                name: "IX_Persons_TeamupRequestID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_TeamupRequestID1",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TeamupRequestID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TeamupRequestID1",
                table: "Persons");
        }
    }
}
