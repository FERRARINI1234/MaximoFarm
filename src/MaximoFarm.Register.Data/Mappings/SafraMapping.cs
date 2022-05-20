using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class SafraMapping : IEntityTypeConfiguration<Safra>
    {
        public void Configure(EntityTypeBuilder<Safra> builder)
        {
            builder.ToTable("SAFRA");

            builder.HasKey(p => p.CodSafra).HasName("PK_SAFRA");
            builder.Property(p => p.SafraId).HasColumnName("ID_SAFRA").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodSafra).HasColumnName("CD_SAFRA").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescSafra).HasColumnName("DE_SAFRA").HasColumnType("VARCHAR(45)").IsRequired();
        }
    }
}
