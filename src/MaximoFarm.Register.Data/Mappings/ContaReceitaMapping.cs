using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class ContaReceitaMapping : IEntityTypeConfiguration<ContaReceita>
    {
        public void Configure(EntityTypeBuilder<ContaReceita> builder)
        {
            builder.ToTable("CRECEITA");

            builder.HasKey(p => p.CodContaReceita).HasName("PK_CONTA_RECEITA");
            builder.Property(p => p.ContaReceitaId).HasColumnName("ID_CRECEITA").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodContaReceita).HasColumnName("CD_CRECEITA").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescContaReceita).HasColumnName("DE_CRECEITA").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.Ativo).HasColumnName("ATIVO").HasColumnType("BOOLEAN").IsRequired();
        }
    }
}
