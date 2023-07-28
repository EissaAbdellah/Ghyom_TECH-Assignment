using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhyomAssignment.Migrations
{
    public partial class EdideMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NWC_Rreal_Estate_Types_Code",
                table: "NWC_Rreal_Estate_Types",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NWC_Rreal_Estate_Types_Code",
                table: "NWC_Rreal_Estate_Types",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
