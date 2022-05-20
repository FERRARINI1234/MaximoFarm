using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaximoFarm.Register.Data.Mappings
{
    public class GrupoProdutoMapping : IEntityTypeConfiguration<GrupoProduto>
    {
        public void Configure(EntityTypeBuilder<GrupoProduto> builder)
        {
            builder.ToTable("GRUPO_PRODUTO");

            builder.HasKey(p => p.CodGrupoProduto).HasName("PK_GRUPO_PROD");
            builder.Property(p => p.GrupoProdutoId).HasColumnName("ID_GRUPO_PROD").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodGrupoProduto).HasColumnName("CD_GRUPO_PROD").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescGrupoProduto).HasColumnName("DE_GRUPO_PROD").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.Ativo).HasColumnName("ATIVO").HasColumnType("BOOLEAN").IsRequired();
        }
    }
}
