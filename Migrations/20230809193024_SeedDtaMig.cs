using Microsoft.EntityFrameworkCore.Migrations;

namespace YoMarket.Migrations
{
    public partial class SeedDtaMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Descripton", "Name" },
                values: new object[] { 1, "مکمل ورزشی کراتین مونوهیدرات", "کراتین" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Descripton", "Name" },
                values: new object[] { 2, "انواع پروتئین نظیر پروتئین وی ,کازئین , ام پی سی", "پروتئین" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Descripton", "Name" },
                values: new object[] { 3, "انواع گینر های مس و ویت با طعم های مختلف", "گینر" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
