using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TaskManager.API.Data;

#nullable disable

namespace TaskManager.API.Data.Migrations;

[DbContext(typeof(AppDbContext))]
partial class AppDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.0")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("TaskManager.API.Models.Tarefa", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("int");
            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

            b.Property<string>("Titulo").IsRequired().HasMaxLength(200).HasColumnType("nvarchar(200)");
            b.Property<string>("Descricao").IsRequired().HasMaxLength(1000).HasDefaultValue("").HasColumnType("nvarchar(1000)");
            b.Property<string>("Status").IsRequired().HasDefaultValue("Pendente").HasColumnType("nvarchar(max)");
            b.Property<string>("Prioridade").IsRequired().HasDefaultValue("Média").HasColumnType("nvarchar(max)");
            b.Property<DateTime>("DataCriacao").HasDefaultValueSql("GETUTCDATE()").HasColumnType("datetime2");
            b.Property<DateTime?>("DataAtualizacao").HasColumnType("datetime2");

            b.HasKey("Id");
            b.ToTable("Tarefas");
        });
#pragma warning restore 612, 618
    }
}
