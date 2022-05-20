using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class EspacamentoMapping : IEntityTypeConfiguration<Espacamento>
    {
        public void Configure(EntityTypeBuilder<Espacamento> builder)
        {
            builder.ToTable("ESPACAMENTOS");

            builder.HasKey(p => p.CodEspacamento).HasName("PK_ESPACAMENTO");
            builder.Property(p => p.EspacamentoId).HasColumnName("ID_ESPACAMENTO").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodEspacamento).HasColumnName("CD_ESPACAMENTO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescEspacamento).HasColumnName("DE_ESPACAMENTO").HasColumnType("VARCHAR(45)").IsRequired();
        }
    }
}