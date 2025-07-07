﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemekGelsin.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryColumnRestarantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Restaurants",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Restaurants");
        }
    }
}
