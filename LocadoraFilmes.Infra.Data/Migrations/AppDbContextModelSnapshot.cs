﻿// <auto-generated />
using System;
using LocadoraFilmes.Infra.Data.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraFilmes.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocadoraFilmes.Domain.Models.Filme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GeneroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.ToTable("Filme");
                });

            modelBuilder.Entity("LocadoraFilmes.Domain.Models.Genero", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genero");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d9b1e988-7366-41e5-a845-3fef66acf0b2"),
                            Ativo = true,
                            DataCriacao = new DateTime(2023, 9, 8, 4, 47, 58, 395, DateTimeKind.Local).AddTicks(5959),
                            Nome = "Ação"
                        },
                        new
                        {
                            Id = new Guid("4e378b57-3f46-4552-8442-4dc4ff06bfb2"),
                            Ativo = true,
                            DataCriacao = new DateTime(2023, 9, 8, 4, 47, 58, 395, DateTimeKind.Local).AddTicks(5977),
                            Nome = "Aventura"
                        },
                        new
                        {
                            Id = new Guid("fcb9988e-a87f-42e2-a7ea-f8b37dc4e65a"),
                            Ativo = true,
                            DataCriacao = new DateTime(2023, 9, 8, 4, 47, 58, 395, DateTimeKind.Local).AddTicks(5979),
                            Nome = "Drama"
                        },
                        new
                        {
                            Id = new Guid("8514a6c6-c958-4dd7-950b-ce058b921225"),
                            Ativo = true,
                            DataCriacao = new DateTime(2023, 9, 8, 4, 47, 58, 395, DateTimeKind.Local).AddTicks(5982),
                            Nome = "Comédia"
                        },
                        new
                        {
                            Id = new Guid("64437865-abc3-4566-a7c0-a6d8a38fdf1d"),
                            Ativo = true,
                            DataCriacao = new DateTime(2023, 9, 8, 4, 47, 58, 395, DateTimeKind.Local).AddTicks(5984),
                            Nome = "Terror"
                        });
                });

            modelBuilder.Entity("LocadoraFilmes.Domain.Models.Locacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CpfCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Locacao");
                });

            modelBuilder.Entity("LocadoraFilmes.Domain.Models.LocacaoFilme", b =>
                {
                    b.Property<Guid>("LocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocacaoId", "FilmeId");

                    b.HasIndex("FilmeId");

                    b.ToTable("LocacaoFilme");
                });

            modelBuilder.Entity("LocadoraFilmes.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8eb11624-86a4-4c5c-9490-960e846c6d24"),
                            Login = "root",
                            Nome = "Usuário Master",
                            Password = "123",
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("LocadoraFilmes.Domain.Models.Filme", b =>
                {
                    b.HasOne("LocadoraFilmes.Domain.Models.Genero", "Genero")
                        .WithMany("Filmes")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("LocadoraFilmes.Domain.Models.LocacaoFilme", b =>
                {
                    b.HasOne("LocadoraFilmes.Domain.Models.Filme", "Filme")
                        .WithMany("Locacoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LocadoraFilmes.Domain.Models.Locacao", "Locacao")
                        .WithMany("Filmes")
                        .HasForeignKey("LocacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Locacao");
                });

            modelBuilder.Entity("LocadoraFilmes.Domain.Models.Filme", b =>
                {
                    b.Navigation("Locacoes");
                });

            modelBuilder.Entity("LocadoraFilmes.Domain.Models.Genero", b =>
                {
                    b.Navigation("Filmes");
                });

            modelBuilder.Entity("LocadoraFilmes.Domain.Models.Locacao", b =>
                {
                    b.Navigation("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}
