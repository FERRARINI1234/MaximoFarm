using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class ContaDebitoMapping : IEntityTypeConfiguration<ContaDebito>
    {
        public void Configure(EntityTypeBuilder<ContaDebito> builder)
        {
            builder.ToTable("CDEBITO");

            builder.HasKey(p => p.CodContaDebito).HasName("PK_CDEBITO");
            builder.Property(p => p.ContaDebitoId).HasColumnName("ID_CDEBITO").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodContaDebito).HasColumnName("CD_CDEBITO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescContaDebito).HasColumnName("DE_CDEBITO").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.Ativo).HasColumnName("ATIVO").HasColumnType("BOOLEAN").IsRequired();
        }
    }
}
