﻿// <auto-generated />
using System;
using DesafioTecnico.Softplan.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioTecnico.Softplan.Infra.Migrations
{
    [DbContext(typeof(DesafioTecnicoSoftPlanDbContext))]
    [Migration("20210814221029_Eliton-Alteracao-Porcentagem")]
    partial class ElitonAlteracaoPorcentagem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesafioTecnico.Softplan.Domain.Classes.Juros", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2021, 8, 14, 19, 10, 28, 624, DateTimeKind.Local).AddTicks(4597));

                    b.Property<decimal>("Porcentagem")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("ID");

                    b.ToTable("Juros");
                });
#pragma warning restore 612, 618
        }
    }
}
