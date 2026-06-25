using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lab2_Programming.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    last_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    third_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    teacher_class = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    salary = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("teacher_pkey", x => x.teacher_id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    last_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    third_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    avarage_grade = table.Column<double>(type: "double precision", nullable: true),
                    teacher_id = table.Column<int>(type: "integer", nullable: false),
                    parents_phone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("student_pkey", x => x.student_id);
                    table.ForeignKey(
                        name: "student_teacher_id_fkey",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_teacher_id",
                table: "student",
                column: "teacher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "teacher");
        }
    }
}
