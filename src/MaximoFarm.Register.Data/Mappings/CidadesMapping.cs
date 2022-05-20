using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaximoFarm.Register.Data.Mappings
{
    public class CidadesMapping : IEntityTypeConfiguration<Cidades>
    {
        public void Configure(EntityTypeBuilder<Cidades> builder)
        {
            builder.ToTable("CIDADES");

            builder.HasKey(p => p.CodCidade).HasName("PK_CIDADE");
            builder.Property(p => p.CidadeId).HasColumnName("ID_CIDADE").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodCidade).HasColumnName("CD_CIDADE").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescCidade).HasColumnName("DE_CIDADE").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.CodEstado).HasColumnName("CD_ESTADO").HasColumnType("INTEGER").IsRequired();

            builder.HasOne(p => p.Estados)
                .WithMany(p => p.Cidades)
                .HasForeignKey(p => p.CodEstado)
                .HasConstraintName("FK_CIDADES__ESTADOS")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
