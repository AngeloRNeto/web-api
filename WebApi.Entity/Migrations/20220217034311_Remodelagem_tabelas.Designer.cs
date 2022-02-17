﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.Entity;

#nullable disable

namespace WebApi.Entity.Migrations
{
    [DbContext(typeof(WebContext))]
    [Migration("20220217034311_Remodelagem_tabelas")]
    partial class Remodelagem_tabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Domain.Models.Carrinho", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("clienteid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("data_alteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("data_criacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("produtoid")
                        .HasColumnType("integer");

                    b.Property<int>("quantidade")
                        .HasColumnType("integer");

                    b.Property<int>("situacao")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("clienteid");

                    b.HasIndex("produtoid");

                    b.ToTable("carrinhos");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("data_alteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("data_criacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("data_nascimento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("enderecoid")
                        .HasColumnType("integer");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("situacao")
                        .HasColumnType("integer");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("enderecoid");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("WebApi.Domain.Models.ClienteDados", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("clienteid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("data_alteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("data_criacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("situacao")
                        .HasColumnType("integer");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("clienteid");

                    b.ToTable("cliente_dados");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("complemento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("data_alteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("data_criacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("logradouro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("situacao")
                        .HasColumnType("integer");

                    b.Property<string>("uf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("enderecos");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("data_alteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("data_criacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("foto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("preco")
                        .HasColumnType("numeric");

                    b.Property<int>("situacao")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("data_alteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("data_criacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("situacao")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Carrinho", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Domain.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("produtoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("produto");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Cliente", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Endereco", "endereco")
                        .WithMany()
                        .HasForeignKey("enderecoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("endereco");
                });

            modelBuilder.Entity("WebApi.Domain.Models.ClienteDados", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Cliente", "cliente")
                        .WithMany("cliente_dados")
                        .HasForeignKey("clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Cliente", b =>
                {
                    b.Navigation("cliente_dados");
                });
#pragma warning restore 612, 618
        }
    }
}
