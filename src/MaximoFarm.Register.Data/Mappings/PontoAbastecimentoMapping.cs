using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class PontoAbastecimentoMapping : IEntityTypeConfiguration<PontoAbastecimento>
    {
        public void Configure(EntityTypeBuilder<PontoAbastecimento> builder)
        {
            builder.ToTable("PONTO_ABAST");

            builder.HasKey(p => p.CodPontoAbastecimento).HasName("PK_PONTO_ABAST");
            builder.Property(p => p.PontoAbastecimentoId).HasColumnName("ID_PONTO_ABAST").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodPontoAbastecimento).HasColumnName("CD_PONTO_ABAST").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescPontoAbastecimento).HasColumnName("DE_PONTO_ABAST").HasColumnType("VARCHAR(45)").IsRequired();
        }
    }
}
