using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Infra.Data.EntitiesConfiguration
{
    public class ProprietarioConfiguration : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Documento).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Endereco).WithOne(x => x.Proprietario).HasForeignKey<Endereco>(x => x.ProprietarioId);

        }
    }
}
