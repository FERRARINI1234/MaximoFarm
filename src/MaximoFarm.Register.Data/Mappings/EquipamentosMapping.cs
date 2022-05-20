using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class EquipamentosMapping : IEntityTypeConfiguration<Equipamentos>
    {
        public void Configure(EntityTypeBuilder<Equipamentos> builder)
        {
            builder.ToTable("EQUIPTOS");

            builder.HasKey(p => p.CodEquipamento).HasName("PK_EQUIPTO");

            builder.Property(p => p.CodEquipamento).HasColumnName("CD_EQUIPTO").HasColumnType("INTEGER").IsRequired();

            builder.Property(p => p.AnoFabricacao).HasColumnName("ANO_FABR").HasColumnType("INTEGER");

            builder.Property(p => p.Placa).HasColumnName("PLACA").HasColumnType("VARCHAR(45)");

            builder.Property(p => p.Chassi).HasColumnName("CHASSI").HasColumnType("VARCHAR(45)");

            builder.Property(p => p.Renavan).HasColumnName("RENAVAN").HasColumnType("VARCHAR(45)");

            builder.Property(p => p.DataCadastro).HasColumnName("DT_CADASTRO").HasColumnType("TIMESTAMP");

            builder.Property(p => p.DataAquisicao).HasColumnName("DT_AQUISICAO").HasColumnType("DATE");

            builder.Property(p => p.Ativo).HasColumnName("ATIVO").HasColumnType("BOOLEAN").IsRequired();

            builder.Property(p => p.CodTipoEquipamento).HasColumnName("CD_TIPO_EQUIPTO").HasColumnType("INT").IsRequired();

            builder.Property(p => p.CodFornecedor).HasColumnName("CD_FORNEC").HasColumnType("INT").IsRequired();

            builder.Property(p => p.CodCentroCusto).HasColumnName("CD_CCUSTO").HasColumnType("INT").IsRequired();

            builder.Property(p => p.CodGrupoEquipamento).HasColumnName("CD_GRUPO_EQUIPTO").HasColumnType("INT").IsRequired();

            builder.Property(p => p.CodModelo).HasColumnName("CD_MODELO").HasColumnType("INT").IsRequired();

            builder.HasOne(p => p.TipoEquipamento)
                .WithMany(p => p.Equipamentos)
                .HasForeignKey(p => p.CodTipoEquipamento)
                .HasConstraintName("FK_EQUIPAMENTO__TIPO_EQUIPTO")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Fornecedores)
                .WithMany(p => p.Equipamentos)
                .HasForeignKey(p => p.CodFornecedor)
                .HasConstraintName("FK_EQUIPAMENTO__FORNECEDORES")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.CentroCusto)
                .WithMany(p => p.Equipamentos)
                .HasForeignKey(p => p.CodCentroCusto)
                .HasConstraintName("FK_EQUIPAMENTO__CCUSTO")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.GrupoEquipamento)
                .WithMany(p => p.Equipamentos)
                .HasForeignKey(p => p.CodGrupoEquipamento)
                .HasConstraintName("FK_EQUIPAMENTO__GRUPO_EQUIPTO")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Modelos)
                .WithMany(p => p.Equipamentos)
                .HasForeignKey(p => p.CodModelo)
                .HasConstraintName("FK_EQUIPAMENTO__MODELOS")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
