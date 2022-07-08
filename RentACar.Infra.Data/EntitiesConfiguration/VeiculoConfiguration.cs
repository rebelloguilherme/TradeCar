using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Infra.Data.EntitiesConfiguration
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StatusVeiculo).IsRequired();
            builder.Property(x => x.Quilometragem).IsRequired();
            builder.Property(x => x.Valor).HasPrecision(10,2).IsRequired();
            builder.Property(x => x.AnoModelo).IsRequired();
            builder.Property(x => x.AnoFabricacao).IsRequired();
            builder.Property(x => x.Modelo).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Renavam).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Marca).WithMany(x => x.Veiculos).HasForeignKey(x => x.MarcaId);
            builder.HasOne(x => x.Proprietario).WithMany(x => x.Veiculos).HasForeignKey(x => x.ProprietarioId);
            
        }
    }
}
