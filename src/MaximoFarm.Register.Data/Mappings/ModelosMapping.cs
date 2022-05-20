using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class ModelosMapping : IEntityTypeConfiguration<Modelos>
    {
        public void Configure(EntityTypeBuilder<Modelos> builder)
        {
            builder.ToTable("MODELOS");

            builder.HasKey(p => p.CodModelo).HasName("ID_MODELO");
            builder.Property(p => p.ModeloId).HasColumnName("ID_MODELO").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodModelo).HasColumnName("CD_MODELO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescModelo).HasColumnName("DE_MODELO").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.CodMarca).HasColumnName("CD_MARCA").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.CodMedida).HasColumnName("CD_MEDIDA").HasColumnType("INTEGER").IsRequired();

            builder.HasOne(p => p.Marcas)
                .WithMany(p => p.Modelos)
                .HasForeignKey(p => p.CodMarca)
                .HasConstraintName("FK_MODELOS__MARCAS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Medidas)
                .WithMany(p => p.Modelos)
                .HasForeignKey(p => p.CodMedida)
                .HasConstraintName("FK_MODELOS__MEDIDAS")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}