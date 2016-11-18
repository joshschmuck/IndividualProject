using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.Data.Migrations
{
    public partial class edit_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descrition",
                table: "Weather");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Weather",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Weather");

            migrationBuilder.AddColumn<string>(
                name: "Descrition",
                table: "Weather",
                nullable: true);
        }
    }
}
