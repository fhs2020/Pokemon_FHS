// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokemon.API.Context;

namespace Pokemon.API.Migrations
{
    [DbContext(typeof(PokemonContext))]
    [Migration("20220107011207_Nova propriedade PokemonCapturado")]
    partial class NovapropriedadePokemonCapturado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Pokemon.API.Domain.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<int>("Idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("PokemonFoiCapturado")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("ehPokemonMestre")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
