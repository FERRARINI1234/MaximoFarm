using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class MateriaisMapping : IEntityTypeConfiguration<Materiais>
    {
        public void Configure(EntityTypeBuilder<Materiais> builder)
        {
            builder.ToTable("MATERIAIS");

            builder.HasKey(p => p.CodMaterial).HasName("ID_MATERIAL");
            builder.Property(p => p.MaterialId).HasColumnName("ID_MATERIAL").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodMaterial).HasColumnName("CD_MATERIAL").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescMaterial).HasColumnName("DE_MATERIAL").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.CodMedida).HasColumnName("CD_MEDIDA").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.CodGrupoProduto).HasColumnName("CD_GRUPO_PROD").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.CodEspacamento).HasColumnName("CD_ESPACAMENTO").HasColumnType("INTEGER").IsRequired();

            builder.HasOne(p => p.Medidas)
                .WithMany(p => p.Materiais)
                .HasForeignKey(p => p.CodMedida)
                .HasConstraintName("FK_MATERIAIS__MEDIDAS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.GrupoProduto)
                .WithMany(p => p.Materiais)
                .HasForeignKey(p => p.CodGrupoProduto)
                .HasConstraintName("FK_MATERIAIS__GRUPO_PROD")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Espacamento)
                .WithMany(p => p.Materiais)
                .HasForeignKey(p => p.CodEspacamento)
                .HasConstraintName("FK_MATERIAIS__ESPACAMENTO")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}