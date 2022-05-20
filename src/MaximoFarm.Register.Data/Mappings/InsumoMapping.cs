using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class InsumoMapping : IEntityTypeConfiguration<Insumos>
    {
        public void Configure(EntityTypeBuilder<Insumos> builder)
        {
            builder.ToTable("INSUMOS");

            builder.HasKey(p => p.CodInsumo).HasName("PK_INSUMOS");
            builder.Property(p => p.InsumoId).HasColumnName("ID_INSUMOS").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodInsumo).HasColumnName("CD_INSUMOS").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescInsumo).HasColumnName("DE_INSUMOS").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.CodFornecedor).HasColumnName("CD_FORNEC").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.CodMarca).HasColumnName("CD_MARCA").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.CodMedida).HasColumnName("CD_MEDIDA").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.CodGrupoProduto).HasColumnName("CD_GRUPO_PRODUTO").HasColumnType("INTEGER").IsRequired();

            builder.HasOne(p => p.Fornecedores)
                .WithMany(p => p.Insumos)
                .HasForeignKey(p => p.CodFornecedor)
                .HasConstraintName("FK_INSUMOS__FORNECEDORES")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Marcas)
                .WithMany(p => p.Insumos)
                .HasForeignKey(p => p.CodMarca)
                .HasConstraintName("FK_INSUMOS__MARCAS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Medidas)
                .WithMany(p => p.Insumos)
                .HasForeignKey(p => p.CodMedida)
                .HasConstraintName("FK_INSUMOS__MEDIDAS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.GrupoProduto)
                .WithMany(p => p.Insumos)
                .HasForeignKey(p => p.CodGrupoProduto)
                .HasConstraintName("FK_INSUMOS__INSUMOS")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
