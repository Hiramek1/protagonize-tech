using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.API.Data.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Tarefas",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Titulo = table.Column<string>(maxLength: 200, nullable: false),
                Descricao = table.Column<string>(maxLength: 1000, nullable: false, defaultValue: ""),
                Status = table.Column<string>(nullable: false, defaultValue: "Pendente"),
                Prioridade = table.Column<string>(nullable: false, defaultValue: "Média"),
                DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                DataAtualizacao = table.Column<DateTime>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tarefas", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Tarefas");
    }
}
