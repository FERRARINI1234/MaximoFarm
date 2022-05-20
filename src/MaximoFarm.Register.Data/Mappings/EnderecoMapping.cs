using MaximoFarm.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MaximoFarm.Register.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Enderecos>
    {
        public void Configure(EntityTypeBuilder<Enderecos> builder)
        {
            builder.ToTable("ENDERECOS");

            builder.HasKey(p => p.EnderecoId).HasName("PK_ENDERECO");
            builder.Property(p => p.EnderecoId).HasColumnName("CD_ENDERECO").HasColumnType("INTEGER").ValueGeneratedOnAdd();
            builder.Property(p => p.Rua).HasColumnName("RUA").HasColumnType("VARCHAR(45)");
            builder.Property(p => p.Bairro).HasColumnName("BAIRRO").HasColumnType("VARCHAR(45)");
            builder.Property(p => p.Numero).HasColumnName("NUMERO").HasColumnType("INTEGER");
            builder.Property(p => p.Complemento).HasColumnName("COMPLEMENTO").HasColumnType("VARCHAR(45)");
            builder.Property(p => p.Telefone).HasColumnName("TELEFONE").HasColumnType("INTEGER");
            builder.Property(p => p.TelefoneAux).HasColumnName("TELEFONE_AUX").HasColumnType("INTEGER");
            builder.Property(p => p.Email).HasColumnName("EMAIL").HasColumnType("VARCHAR(45)");
            builder.Property(p => p.Latitude).HasColumnName("LATITUDE").HasColumnType("DECIMAL(5,5)");
            builder.Property(p => p.Longitude).HasColumnName("LONGITUDE").HasColumnType("DECIMAL(5,5)");
            builder.Property(p => p.CodCidade).HasColumnName("ID_CIDADE").HasColumnType("INTEGER").IsRequired();

            builder.HasOne(p => p.Cidades)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(c => c.CodCidade)
                    .HasConstraintName("FK_ENDERECO__CIDADE")
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
