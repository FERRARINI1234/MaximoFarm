using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class CargosMapping : IEntityTypeConfiguration<Cargos>
    {
        public void Configure(EntityTypeBuilder<Cargos> builder)
        {
            builder.ToTable("CARGOS");

            builder.HasKey(p => p.CodCargo).HasName("PK_CARGO");
            builder.Property(p => p.CargoId).HasColumnName("ID_CARGO").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodCargo).HasColumnName("CD_CARGO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescCargo).HasColumnName("DE_CARGO").HasColumnType("VARCHAR(45)").IsRequired();
        }
    }
}
