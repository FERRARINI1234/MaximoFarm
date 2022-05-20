using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class MedidasMapping : IEntityTypeConfiguration<Medidas>
    {
        public void Configure(EntityTypeBuilder<Medidas> builder)
        {
            builder.ToTable("MEDIDAS");

            builder.HasKey(p => p.CodMedida).HasName("PK_MEDIDA");
            builder.Property(p => p.MedidaId).HasColumnName("ID_MEDIDA").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodMedida).HasColumnName("CD_MEDIDA").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescAbrevMedida).HasColumnName("DA_MEDIDA").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.DescMedida).HasColumnName("DE_MEDIDA").HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}