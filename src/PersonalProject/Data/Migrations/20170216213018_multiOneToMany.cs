using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalProject.Data.Migrations
{
    public partial class multiOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserTableId",
                table: "Remixes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserTableId",
                table: "Gigs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Remixes_UserTableId",
                table: "Remixes",
                column: "UserTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Gigs_UserTableId",
                table: "Gigs",
                column: "UserTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_AspNetUsers_UserTableId",
                table: "Gigs",
                column: "UserTableId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Remixes_AspNetUsers_UserTableId",
                table: "Remixes",
                column: "UserTableId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_AspNetUsers_UserTableId",
                table: "Gigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Remixes_AspNetUsers_UserTableId",
                table: "Remixes");

            migrationBuilder.DropIndex(
                name: "IX_Remixes_UserTableId",
                table: "Remixes");

            migrationBuilder.DropIndex(
                name: "IX_Gigs_UserTableId",
                table: "Gigs");

            migrationBuilder.DropColumn(
                name: "UserTableId",
                table: "Remixes");

            migrationBuilder.DropColumn(
                name: "UserTableId",
                table: "Gigs");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
