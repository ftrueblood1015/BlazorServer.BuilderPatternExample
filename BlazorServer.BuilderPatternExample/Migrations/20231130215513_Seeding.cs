using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.BuilderPatternExample.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cpus",
                columns: new[] { "Id", "BaseSpeed", "Cores", "Cost", "Description", "Name", "Slug" },
                values: new object[] { 1, "1.5gHz", 4, 100, "Intel i5", "Intel i5", "BASE" });

            migrationBuilder.InsertData(
                table: "Cpus",
                columns: new[] { "Id", "BaseSpeed", "Cores", "Cost", "Description", "Name", "Slug" },
                values: new object[] { 2, "2.2gHz", 10, 250, "Intel i7", "Intel i7", "MID" });

            migrationBuilder.InsertData(
                table: "Cpus",
                columns: new[] { "Id", "BaseSpeed", "Cores", "Cost", "Description", "Name", "Slug" },
                values: new object[] { 3, "3gHz", 20, 500, "Intel i9", "Intel i9", "TOP" });

            migrationBuilder.InsertData(
                table: "Gpus",
                columns: new[] { "Id", "Cost", "Description", "Name", "Slug" },
                values: new object[] { 1, 300, "NVIDIA GeForce RTX 2070", "NVIDIA GeForce RTX 2070", "BASE" });

            migrationBuilder.InsertData(
                table: "Gpus",
                columns: new[] { "Id", "Cost", "Description", "Name", "Slug" },
                values: new object[] { 2, 500, "NVIDIA GeForce RTX 3070", "NVIDIA GeForce RTX 3070", "MID" });

            migrationBuilder.InsertData(
                table: "Gpus",
                columns: new[] { "Id", "Cost", "Description", "Name", "Slug" },
                values: new object[] { 3, 800, "NVIDIA GeForce RTX 4070", "NVIDIA GeForce RTX 4070", "TOP" });

            migrationBuilder.InsertData(
                table: "HardDrives",
                columns: new[] { "Id", "Cost", "Description", "Name", "Size", "Slug", "Type" },
                values: new object[] { 1, 50, "256GB SSD", "256GB SSD", 256, "BASE", "SSD" });

            migrationBuilder.InsertData(
                table: "HardDrives",
                columns: new[] { "Id", "Cost", "Description", "Name", "Size", "Slug", "Type" },
                values: new object[] { 2, 100, "512GB SSD", "512GB SSD", 512, "MID", "SSD" });

            migrationBuilder.InsertData(
                table: "HardDrives",
                columns: new[] { "Id", "Cost", "Description", "Name", "Size", "Slug", "Type" },
                values: new object[] { 3, 200, "1024GB SSD", "1024GB SSD", 1024, "TOP", "SSD" });

            migrationBuilder.InsertData(
                table: "PcLevels",
                columns: new[] { "Id", "Description", "Name", "Slug" },
                values: new object[] { 1, "Base Model", "Base Model", "BASE" });

            migrationBuilder.InsertData(
                table: "PcLevels",
                columns: new[] { "Id", "Description", "Name", "Slug" },
                values: new object[] { 2, "Mid Model", "Mid Model", "MID" });

            migrationBuilder.InsertData(
                table: "PcLevels",
                columns: new[] { "Id", "Description", "Name", "Slug" },
                values: new object[] { 3, "Top Model", "Top Model", "TOP" });

            migrationBuilder.InsertData(
                table: "Rams",
                columns: new[] { "Id", "Cost", "Description", "Name", "RamAmount", "Slug", "Type" },
                values: new object[] { 1, 50, "8GB DDR5", "8GB DDR5", 8, "BASE", "DDR5" });

            migrationBuilder.InsertData(
                table: "Rams",
                columns: new[] { "Id", "Cost", "Description", "Name", "RamAmount", "Slug", "Type" },
                values: new object[] { 2, 100, "16GB DDR5", "16GB DDR5", 16, "MID", "DDR5" });

            migrationBuilder.InsertData(
                table: "Rams",
                columns: new[] { "Id", "Cost", "Description", "Name", "RamAmount", "Slug", "Type" },
                values: new object[] { 3, 175, "32GB DDR5", "32GB DDR5", 32, "TOP", "DDR5" });

            migrationBuilder.InsertData(
                table: "CustomPcs",
                columns: new[] { "Id", "CpuId", "CustomerName", "Description", "GpuId", "HardDriveId", "Name", "PcLevelId", "RamId", "Slug", "TotalCost" },
                values: new object[] { 1, 3, "Fletcher", "Fletche Top Pc", 3, 3, "Fletcher Top Pc", 3, 3, "None", 1675 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cpus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cpus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomPcs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HardDrives",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HardDrives",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PcLevels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PcLevels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cpus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HardDrives",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PcLevels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
