using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PeriodIdNulleableForSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Period_PeriodID",
                table: "Session");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodID",
                table: "Session",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Period_PeriodID",
                table: "Session",
                column: "PeriodID",
                principalTable: "Period",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Period_PeriodID",
                table: "Session");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodID",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Period_PeriodID",
                table: "Session",
                column: "PeriodID",
                principalTable: "Period",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
