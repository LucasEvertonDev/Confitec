using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confitec.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class includeescolaridade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Escolaridades",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1, "Infantil" });

            migrationBuilder.InsertData(
                table: "Escolaridades",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 2, "Fundamental" });

            migrationBuilder.InsertData(
                table: "Escolaridades",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 3, "Médio" });

            migrationBuilder.InsertData(
                table: "Escolaridades",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 4, "Superior" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Escolaridades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
               table: "Escolaridades",
               keyColumn: "Id",
               keyValue: 2);

            migrationBuilder.DeleteData(
               table: "Escolaridades",
               keyColumn: "Id",
               keyValue: 3);

            migrationBuilder.DeleteData(
               table: "Escolaridades",
               keyColumn: "Id",
               keyValue: 4);
        }
    }
}
