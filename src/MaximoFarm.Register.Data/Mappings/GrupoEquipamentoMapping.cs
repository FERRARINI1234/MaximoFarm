using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class GrupoEquipamentoMapping : IEntityTypeConfiguration<GrupoEquipamento>
    {
        public void Configure(EntityTypeBuilder<GrupoEquipamento> builder)
        {
            builder.ToTable("GRUPO_EQUIPTO");

            builder.HasKey(p => p.CodGrupoEquipamento).HasName("PK_GRUPO_EQUIPTO");
            builder.Property(p => p.GrupoEquipamentoId).HasColumnName("ID_GRUPO_EQUIPTO").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodGrupoEquipamento).HasColumnName("CD_GRUPO_EQUIPTO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescGrupoEquipamento).HasColumnName("DE_GRUPO_EQUIPTO").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.Ativo).HasColumnName("ATIVO").HasColumnType("BOOLEAN").IsRequired();
        }
    }
}
