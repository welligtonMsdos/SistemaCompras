using System;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        SolicitacaoCompra Obter(Guid id);
        void Registrar(SolicitacaoCompra entity);
        void Atualizar(SolicitacaoCompra entity);
        void Excluir(SolicitacaoCompra entity);
    }
}
