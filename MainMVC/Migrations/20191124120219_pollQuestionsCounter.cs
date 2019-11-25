using Microsoft.EntityFrameworkCore.Migrations;

namespace MainMVC.Migrations
{
    public partial class pollQuestionsCounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Polls",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionsCount",
                table: "Polls",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionsCount",
                table: "Polls");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Polls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
