using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuremberg.Data.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "TestModels",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                TestModelName = table.Column<string>(type: "text", nullable: false),
                TestModelOtherProp = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TestModels", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "TestModels");
    }
}