using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class MarcasMapping : IEntityTypeConfiguration<Marcas>
    {
        public void Configure(EntityTypeBuilder<Marcas> builder)
        {
            builder.ToTable("MARCAS");

            builder.HasKey(p => p.CodMarca).HasName("PK_MARCA");
            builder.Property(p => p.MarcaId).HasColumnName("ID_MARCA").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodMarca).HasColumnName("CD_MARCA").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescMarca).HasColumnName("DE_MARCA").HasColumnType("VARCHAR(45)").IsRequired();
        }
    }
}