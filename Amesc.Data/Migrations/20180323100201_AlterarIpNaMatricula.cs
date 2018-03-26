using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using Amesc.Data.Contexts;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Amesc.Data.Migrations
{
    public partial class AlterarIpNaMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Ip", "Matriculas");

            migrationBuilder.AddColumn<bool>(
                name: "Ip",
                table: "Matriculas",
                type: "bit",
                defaultValueSql:"0",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Ip", "Matriculas");

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "Matriculas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
