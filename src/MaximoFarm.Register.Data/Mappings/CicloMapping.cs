using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class CicloMapping : IEntityTypeConfiguration<Ciclo>
    {
        public void Configure(EntityTypeBuilder<Ciclo> builder)
        {
            builder.ToTable("CICLO");

            builder.HasKey(p => p.CodCiclo).HasName("PK_CICLO");
            builder.Property(p => p.CicloId).HasColumnName("ID_CICLO").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodCiclo).HasColumnName("CD_CICLO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescCiclo).HasColumnName("DE_CICLO").HasColumnType("VARCHAR(45)").IsRequired();
        }
    }
}
