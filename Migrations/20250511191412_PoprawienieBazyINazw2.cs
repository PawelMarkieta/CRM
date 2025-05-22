using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRMCallCenter.Migrations
{
    /// <inheritdoc />
    public partial class PoprawienieBazyINazw2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZepolId",
                table: "Klienci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZepolId",
                table: "Klienci",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
