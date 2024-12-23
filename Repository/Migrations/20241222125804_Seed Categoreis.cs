using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoreis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0455586d-7051-4bdb-b9bd-1876aebeafa6"), "Embedded Systems" },
                    { new Guid("2465616e-4c3e-4b8b-ab30-6ca5c9b5e415"), "Frontend" },
                    { new Guid("29c4638e-420a-4e2b-8366-f823b2830096"), "Game Development" },
                    { new Guid("3e752dd9-a938-4c7c-a7eb-b88742670ae8"), "Networks" },
                    { new Guid("904efdea-fc65-48d9-9547-4a053cb684a6"), "Artificial Intelligence" },
                    { new Guid("a6169928-f023-4c03-9f98-ed71bf69a1c7"), "Mobile Development" },
                    { new Guid("a7c8aae2-0baa-4c24-94b5-7dd27fb46051"), "Cloud Computing" },
                    { new Guid("c3de1407-89f7-4b7a-9d0d-acf585c8cdd4"), "Data Science" },
                    { new Guid("c7a12c23-ac69-4cef-b52f-77a744afe96f"), "Backend" },
                    { new Guid("c9d9e0e8-b548-4e86-a0c8-07240f363a66"), "DevOps" },
                    { new Guid("ec2d623f-3fb8-49e5-bcb9-44e0ca1def8b"), "Cybersecurity" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0455586d-7051-4bdb-b9bd-1876aebeafa6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2465616e-4c3e-4b8b-ab30-6ca5c9b5e415"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("29c4638e-420a-4e2b-8366-f823b2830096"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3e752dd9-a938-4c7c-a7eb-b88742670ae8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("904efdea-fc65-48d9-9547-4a053cb684a6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a6169928-f023-4c03-9f98-ed71bf69a1c7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a7c8aae2-0baa-4c24-94b5-7dd27fb46051"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c3de1407-89f7-4b7a-9d0d-acf585c8cdd4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7a12c23-ac69-4cef-b52f-77a744afe96f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c9d9e0e8-b548-4e86-a0c8-07240f363a66"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ec2d623f-3fb8-49e5-bcb9-44e0ca1def8b"));
        }
    }
}
