using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitarCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitarCompraAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitarCompraAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");

            builder.OwnsOne(c => c.UsuarioSolicitante, b => b.Property("Value").HasColumnName("UsuarioSolicitante"));           
        }
    }
}
