using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeMath.Infra.Migrations
{
    public partial class ColumnTextAlternative : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Alternatives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Alternatives");
        }
    }
}
