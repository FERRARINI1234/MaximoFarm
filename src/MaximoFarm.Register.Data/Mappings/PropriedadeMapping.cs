using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class PropriedadeMapping : IEntityTypeConfiguration<Propriedade>
    {
        public void Configure(EntityTypeBuilder<Propriedade> builder)
        {
            builder.ToTable("PROPRIEDADE_HE");

            builder.HasKey(p => p.CodPropriedade).HasName("ID_PROPRIEDADE");
            builder.Property(p => p.CodPropriedade).HasColumnName("CD_PROPRIEDADE").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescPropriedade).HasColumnName("DE_PROPRIEDADE").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.QuantidadeAreaTotal).HasColumnName("QT_AREA_TOT").HasColumnType("DECIMA(5,2)").IsRequired();
            builder.Property(p => p.Incra).HasColumnName("NO_INCRA").HasColumnType("VARCHAR(45)");
            builder.Property(p => p.Cadpro).HasColumnName("NO_CADPRO").HasColumnType("VARCHAR(45)") ;
            builder.Property(p => p.Ccir).HasColumnName("NO_CCIR").HasColumnType("VARCHAR(45)") ;
            builder.Property(p => p.CodCidade).HasColumnName("CD_CIDADE").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.CodFornecedor).HasColumnName("CD_FORNEC").HasColumnType("INTEGER").IsRequired();

            builder.HasOne(p => p.Cidades)
                .WithMany(p => p.Propriedade)
                .HasForeignKey(p => p.CodCidade)
                .HasConstraintName("FK_PROPRIEDADE__CIDADES")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Fornecedores)
                .WithMany(p => p.Propriedades)
                .HasForeignKey(p => p.CodFornecedor)
                .HasConstraintName("FK_PROPRIEDADE__FORNECEDOR")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
