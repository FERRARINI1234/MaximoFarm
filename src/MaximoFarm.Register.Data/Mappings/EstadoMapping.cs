using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class EstadoMapping : IEntityTypeConfiguration<Estados>
    {
        public void Configure(EntityTypeBuilder<Estados> builder)
        {
            builder.ToTable("ESTADOS");

            builder.HasKey(p => p.CodEstado).HasName("PK_ESTADO");
            builder.Property(p => p.EstadoId).HasColumnName("ID_ESTADO").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodEstado).HasColumnName("CD_ESTADO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescEstado).HasColumnName("DE_ESTADO").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.DescAbrevEstado).HasColumnName("DA_ESTADO").HasColumnType("VARCHAR(45)").IsRequired();
        }
    }
}