using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice.Persistence.EFCore.Migrations
{
    public partial class addMyField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyField",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyField",
                table: "Order");
        }
    }
}
