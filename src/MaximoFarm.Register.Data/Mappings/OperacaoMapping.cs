using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class OperacaoMapping : IEntityTypeConfiguration<Operacao>
    {
        public void Configure(EntityTypeBuilder<Operacao> builder)
        {
            builder.ToTable("OPERACOES");

            builder.HasKey(p => p.CodOperacao).HasName("PK_OPERACAO");
            builder.Property(p => p.OperacaoId).HasColumnName("ID_OPERACAO").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodOperacao).HasColumnName("CD_OPERACAO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescAbrevOperacao).HasColumnName("DA_OPERACAO").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.DescOperacao).HasColumnName("DE_OPERACAO").HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}
