using System;
using System.Collections.Generic;
using DemoGraphQL.Server.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoGraphQL.Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    numberOfKeys = table.Column<string>(type: "INTEGER", nullable: false),
                    role = table.Column<string>(type: "TEXT", nullable: false),
                    inventory = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username", "numberOfKeys", "role","inventory" },
                values: new object[] { new Guid("10f8dac5-2e64-48a2-a3b0-ada65c4ed3d1"), "Armure", 0, UserRoles.Admin, new List<Item>() });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username", "numberOfKeys", "role", "inventory" },
                values: new object[] { new Guid("34686dae-a622-4464-921c-b7f682b61ecc"), "Rayhan", 0, UserRoles.User, new List<Item>() });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
