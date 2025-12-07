using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaItensEmprestados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exemplares_Emprestimos_EmprestimoId",
                table: "Exemplares");

            migrationBuilder.DropIndex(
                name: "IX_Exemplares_EmprestimoId",
                table: "Exemplares");

            migrationBuilder.DropColumn(
                name: "EmprestimoId",
                table: "Exemplares");

            migrationBuilder.CreateTable(
                name: "EmprestimoExemplar",
                columns: table => new
                {
                    EmprestimosId = table.Column<int>(type: "int", nullable: false),
                    ExemplaresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmprestimoExemplar", x => new { x.EmprestimosId, x.ExemplaresId });
                    table.ForeignKey(
                        name: "FK_EmprestimoExemplar_Emprestimos_EmprestimosId",
                        column: x => x.EmprestimosId,
                        principalTable: "Emprestimos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmprestimoExemplar_Exemplares_ExemplaresId",
                        column: x => x.ExemplaresId,
                        principalTable: "Exemplares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmprestimoExemplar_ExemplaresId",
                table: "EmprestimoExemplar",
                column: "ExemplaresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmprestimoExemplar");

            migrationBuilder.AddColumn<int>(
                name: "EmprestimoId",
                table: "Exemplares",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exemplares_EmprestimoId",
                table: "Exemplares",
                column: "EmprestimoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exemplares_Emprestimos_EmprestimoId",
                table: "Exemplares",
                column: "EmprestimoId",
                principalTable: "Emprestimos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
