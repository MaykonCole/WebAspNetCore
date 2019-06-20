﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoWeb.Models;

namespace ProjetoWeb.Migrations
{
    [DbContext(typeof(ProjetoWebContext))]
    [Migration("20190620153259_Reset")]
    partial class Reset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetoWeb.Models.Departament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Departament");
                });

            modelBuilder.Entity("ProjetoWeb.Models.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<int?>("DepartamentId");

                    b.Property<int?>("FuncionarioCpf");

                    b.Property<int>("StatusOS");

                    b.Property<double>("Valor");

                    b.HasKey("IdPedido");

                    b.HasIndex("DepartamentId");

                    b.HasIndex("FuncionarioCpf");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("ProjetoWeb.Models.Vendedor", b =>
                {
                    b.Property<int>("Cpf")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cargo");

                    b.Property<int>("Celular");

                    b.Property<int?>("DpId");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.HasKey("Cpf");

                    b.HasIndex("DpId");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("ProjetoWeb.Models.Pedido", b =>
                {
                    b.HasOne("ProjetoWeb.Models.Departament", "Departament")
                        .WithMany()
                        .HasForeignKey("DepartamentId");

                    b.HasOne("ProjetoWeb.Models.Vendedor", "Funcionario")
                        .WithMany("Pedidos")
                        .HasForeignKey("FuncionarioCpf");
                });

            modelBuilder.Entity("ProjetoWeb.Models.Vendedor", b =>
                {
                    b.HasOne("ProjetoWeb.Models.Departament", "Dp")
                        .WithMany("Vendedores")
                        .HasForeignKey("DpId");
                });
#pragma warning restore 612, 618
        }
    }
}
