using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuremberg.Data.Migrations
{
    public partial class SeedTestModelsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TestModels",
                columns: new[] { "Id", "TestModelName", "TestModelOtherProp" },
                values: new object[,]
                {
                    { new Guid("19fa43c7-1498-4803-8017-e4af79ef08da"), "Sec name", "Some sec property name" },
                    { new Guid("382ef73d-e794-42a1-947c-01e6f25d8c12"), "First name", "Some other property name" },
                    { new Guid("c2300b30-d6bf-4e04-a6ac-2bb5beae3090"), "Tres name", "Some tres property name" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TestModels",
                keyColumn: "Id",
                keyValue: new Guid("19fa43c7-1498-4803-8017-e4af79ef08da"));

            migrationBuilder.DeleteData(
                table: "TestModels",
                keyColumn: "Id",
                keyValue: new Guid("382ef73d-e794-42a1-947c-01e6f25d8c12"));

            migrationBuilder.DeleteData(
                table: "TestModels",
                keyColumn: "Id",
                keyValue: new Guid("c2300b30-d6bf-4e04-a6ac-2bb5beae3090"));
        }
    }
}