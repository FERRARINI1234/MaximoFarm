using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class TipoEquipamentoMapping : IEntityTypeConfiguration<TipoEquipamento>
    {
        public void Configure(EntityTypeBuilder<TipoEquipamento> builder)
        {
            builder.ToTable("TIPO_EQUIPTO");

            builder.HasKey(p => p.CodTipo).HasName("PK_TP_EQUIPTO");
            builder.Property(p => p.TipoId).HasColumnName("ID_TP_EQUIPTO").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodTipo).HasColumnName("CD_TP_EQUIPTO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescTipo).HasColumnName("DE_TP_EQUIPTO").HasColumnType("VARCHAR(45)").IsRequired();
        }
    }
}
