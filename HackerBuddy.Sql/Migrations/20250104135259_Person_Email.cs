using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackerBuddy.Sql.Migrations
{
    /// <inheritdoc />
    public partial class Person_Email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Persons");
        }
    }
}
