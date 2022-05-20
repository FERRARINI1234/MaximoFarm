using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class PropriedadeItemMapping : IEntityTypeConfiguration<PropriedadeItem>
    {
        public void Configure(EntityTypeBuilder<PropriedadeItem> builder)
        {
            builder.ToTable("PROPRIEDADE_DE");

            builder.HasKey(p => p.CodPropriedade).HasName("PK_PROPRIEDADE");
            builder.Property(p => p.CodPropriedade).HasColumnName("CD_PROPRIEDADE").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.CodTalhao).HasColumnName("CD_TALHAO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.AreaTotal).HasColumnName("QT_AREA_TOT").HasColumnType("DECIMAL(5,2)").IsRequired();
            builder.Property(p => p.AreaProdutiva).HasColumnName("QT_AREA_PROD").HasColumnType("DECIMAL(5,2)").IsRequired();
            builder.Property(p => p.AreaDano).HasColumnName("QT_AREA_DANO").HasColumnType("DECIMAL(5,2)");
            builder.Property(p => p.Latitude).HasColumnName("LATITUDE").HasColumnType("DECIMAL(5,5)");
            builder.Property(p => p.Longitude).HasColumnName("LONGITUDE").HasColumnType("DECIMAL(5,5)");

            builder.HasOne(p => p.Propriedade)
                .WithMany(p => p.PropriedadeItem)
                .HasForeignKey(p => p.CodPropriedade)
                .HasConstraintName("FK_PROPRIEDADE__PROPRIEDADE_ITEM")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}