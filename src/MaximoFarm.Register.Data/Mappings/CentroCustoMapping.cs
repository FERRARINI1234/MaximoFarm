using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class CentroCustoMapping : IEntityTypeConfiguration<CentroCusto>
    {
        public void Configure(EntityTypeBuilder<CentroCusto> builder)
        {
            builder.ToTable("CENTRO_CUSTO");

            builder.HasKey(p => p.CodCentroCusto).HasName("PK_CCUSTO");
            builder.Property(p => p.CentroCustoId).HasColumnName("ID_CCUSTO").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodCentroCusto).HasColumnName("CD_CCUSTO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescCentroCusto).HasColumnName("DE_CCUSTO").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.Ativo).HasColumnName("ATIVO").HasColumnType("BOOLEAN").IsRequired();
        }
    }
}
