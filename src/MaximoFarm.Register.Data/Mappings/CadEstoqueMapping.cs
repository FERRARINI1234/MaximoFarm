using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaximoFarm.Register.Data.Mappings
{
    public class CadEstoqueMapping : IEntityTypeConfiguration<CadEstoque>
    {
        public void Configure(EntityTypeBuilder<CadEstoque> builder)
        {
            builder.ToTable("CAD_ESTOQUE");
            builder.HasKey(p => p.CodCadEstoque).HasName("PK_CAD_ESTOQUE");
            builder.Property(p => p.CadEstoqueId).HasColumnName("ID_CAD_ESTOQUE").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodCadEstoque).HasColumnName("CD_ESTOQUE").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescCadEstoque).HasColumnName("DE_ESTOQUE").HasColumnType("VARCHAR(45)").IsRequired();
        }
    }
}
