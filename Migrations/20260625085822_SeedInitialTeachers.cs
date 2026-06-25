using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab2_Programming.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "teacher",
                columns: new[] { "teacher_id", "last_name", "name", "phone_number", "salary", "teacher_class", "third_name" },
                values: new object[,]
                {
                    { 1, "Шевченко", "Олена", "0991234567", 15000, "10-А", "Іванівна" },
                    { 2, "Коваленко", "Ігор", "0987654321", 16000, "11-Б", "Петрович" },
                    { 3, "Чайка", "Василь", "0995314367", 15000, "9-Б", "Олегович" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "teacher",
                keyColumn: "teacher_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "teacher",
                keyColumn: "teacher_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "teacher",
                keyColumn: "teacher_id",
                keyValue: 3);
        }
    }
}
