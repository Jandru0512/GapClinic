using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gap.Clinic.Persistence.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 320, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Document = table.Column<int>(nullable: false),
                    DocumentTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 320, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "DocumentTypeId", "Name" },
                values: new object[] { 1, "Cédula de ciudadanía" });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "DocumentTypeId", "Name" },
                values: new object[] { 2, "Tarjeta de identidad" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Date", "Email", "LastName", "Name", "Password", "Status", "UserName" },
                values: new object[] { 1, new DateTime(1997, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 19, 15, 16, 18, 551, DateTimeKind.Local), "jandru0512@gmail.com", "Restrepo", "Andrés", "123456789", true, "jarestrepo" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "BirthDate", "Date", "Document", "DocumentTypeId", "Email", "LastName", "Name", "Status" },
                values: new object[] { 1, new DateTime(1997, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 19, 15, 16, 18, 549, DateTimeKind.Local), 1234567890, 1, "jandru0512@gmail.com", "Restrepo", "Andrés", true });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DocumentTypeId",
                table: "Patients",
                column: "DocumentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DocumentTypes");
        }
    }
}
