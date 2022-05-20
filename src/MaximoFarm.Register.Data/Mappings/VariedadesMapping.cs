using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class VariedadesMapping : IEntityTypeConfiguration<Variedades>
    {
        public void Configure(EntityTypeBuilder<Variedades> builder)
        {
            builder.ToTable("VARIEDADES");

            builder.HasKey(p => p.CodVariedade).HasName("PK_VARIEDADE");
            builder.Property(p => p.VariedadeId).HasColumnName("ID_VARIEDADE").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodVariedade).HasColumnName("CD_VARIEDADE").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescAbrevVariedade).HasColumnName("DA_VARIEDADE").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.DescVariedade).HasColumnName("DE_VARIEDADE").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.CodMedida).HasColumnName("CD_MEDIDA").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.CodFornecedor).HasColumnName("CD_FORNEC").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.CodCiclo).HasColumnName("CD_CICLO").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.CodEspacamento).HasColumnName("CD_ESPACAMENTO").HasColumnType("INTEGER").IsRequired();

            builder.HasOne(p => p.Medidas)
                .WithMany(p => p.Variedades)
                .HasForeignKey(p => p.CodMedida)
                .HasConstraintName("FK_VARIEDADES__MEDIDAS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Fornecedores)
                .WithMany(p => p.Variedades)
                .HasForeignKey(p => p.CodFornecedor)
                .HasConstraintName("FK_VARIEDADES__FORNECEDORES")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Ciclo)
                .WithMany(p => p.Variedades)
                .HasForeignKey(p => p.CodCiclo)
                .HasConstraintName("FK_VARIEDADES__CICLOS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Espacamento)
                .WithMany(p => p.Variedades)
                .HasForeignKey(p => p.VariedadeId)
                .HasConstraintName("FK_VARIEDADES__VARIEDADES")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
