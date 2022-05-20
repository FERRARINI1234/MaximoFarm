using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class CentroReceitaMapping : IEntityTypeConfiguration<CentroReceita>
    {
        public void Configure(EntityTypeBuilder<CentroReceita> builder)
        {
            builder.ToTable("CENTRO_RECEITA");

            builder.HasKey(p => p.CodCentroReceita).HasName("PK_CENTRO_RECEITA");
           builder.Property(p => p.CentroReceitaId).HasColumnName("ID_CRECEITA").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodCentroReceita).HasColumnName("CD_CRECEITA").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescCentroReceita).HasColumnName("DE_CRECEITA").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.Ativo).HasColumnName("ATIVO").HasColumnType("BOOLEAN").IsRequired();
        }
    }
}
