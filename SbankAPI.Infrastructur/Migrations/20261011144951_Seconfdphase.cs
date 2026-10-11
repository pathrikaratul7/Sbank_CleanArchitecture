using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SbankAPI.Infrastructur.Migrations
{
    /// <inheritdoc />
    public partial class Seconfdphase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Users",
                table: "tbl_Users");

            migrationBuilder.RenameTable(
                name: "tbl_Users",
                newName: "Tbl_Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tbl_Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tbl_Users",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UPassword",
                table: "Tbl_Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tbl_Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Users",
                table: "Tbl_Users",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Users",
                table: "Tbl_Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tbl_Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tbl_Users");

            migrationBuilder.DropColumn(
                name: "UPassword",
                table: "Tbl_Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tbl_Users");

            migrationBuilder.RenameTable(
                name: "Tbl_Users",
                newName: "tbl_Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Users",
                table: "tbl_Users",
                column: "UserID");
        }
    }
}
