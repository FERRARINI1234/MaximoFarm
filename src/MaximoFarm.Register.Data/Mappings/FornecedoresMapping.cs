using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class FornecedoresMapping : IEntityTypeConfiguration<Fornecedores>
    {
        public void Configure(EntityTypeBuilder<Fornecedores> builder)
        {
            builder.ToTable("FORNECEDORES");

            builder.HasKey(p => p.CodFornecedor).HasName("ID_FORNEC");
            builder.Property(p => p.FornecedorId).HasColumnName("ID_FORNEC").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.CodFornecedor).HasColumnName("CD_FORNEC").HasColumnType("INTEGER").IsRequired();
            builder.Property(p => p.DescFornecedor).HasColumnName("DE_FORNEC").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.TipoPessoa).HasColumnName("TP_PESSOA").HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(p => p.EnderecoId).HasColumnName("CD_ENDERECO").HasColumnType("INTEGER").IsRequired();

            builder.HasOne(p => p.Enderecos)
                .WithMany(p => p.Fornecedores)
                .HasForeignKey(p => p.EnderecoId)
                .HasConstraintName("FK_FORNECEDORES__ENDERECOS")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}