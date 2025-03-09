using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_seguros_continental.Migrations
{
    /// <inheritdoc />
    public partial class newfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeInsuranceId",
                table: "Quote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quote_TypeInsuranceId",
                table: "Quote",
                column: "TypeInsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quote_TypeEnsurance_TypeInsuranceId",
                table: "Quote",
                column: "TypeInsuranceId",
                principalTable: "TypeEnsurance",
                principalColumn: "TypeInsuranceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quote_TypeEnsurance_TypeInsuranceId",
                table: "Quote");

            migrationBuilder.DropIndex(
                name: "IX_Quote_TypeInsuranceId",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "TypeInsuranceId",
                table: "Quote");
        }
    }
}
