using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rubic.Migrations
{
    public partial class addUserIdToMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moneys_Users_UserId",
                table: "Moneys");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Moneys");

            migrationBuilder.DropColumn(
                name: "Summ",
                table: "Moneys");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Moneys",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Moneys",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Sum",
                table: "Moneys",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Moneys_Users_UserId",
                table: "Moneys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moneys_Users_UserId",
                table: "Moneys");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Moneys");

            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Moneys");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Moneys",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Moneys",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Summ",
                table: "Moneys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Moneys_Users_UserId",
                table: "Moneys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
