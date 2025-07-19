using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatePaymentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Payments",
                newName: "TotalPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Payments",
                newName: "Amount");
        }
    }
}
