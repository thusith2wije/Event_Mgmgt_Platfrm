using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TIQRI.EMP.Infrastructure.Migrations
{
    public partial class ClientTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog");

            migrationBuilder.RenameTable(
                name: "Catalog",
                newName: "Client");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Catalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog",
                column: "Id");
        }
    }
}
