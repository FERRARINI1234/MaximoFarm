using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class ClasseManutencaoMapping : IEntityTypeConfiguration<ClasseManutencao>
    {
        public void Configure(EntityTypeBuilder<ClasseManutencao> builder)
        {
            builder.ToTable("CLASS_MANU");

            builder.HasKey(p => p.CodClasseManutencao).HasName("PK_CLASS_MANU");
            builder.Property(p => p.ClasseManutencaoId).HasColumnName("ID_CLASS_MANU").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodClasseManutencao).HasColumnName("CD_CLASS_MANU").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescClasseManutencao).HasColumnName("DE_CLASS_MANU").HasColumnType("VARCHAR(45)").IsRequired();
        }
    }
}
