﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrBeleBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addfieee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Order");
        }
    }
}
