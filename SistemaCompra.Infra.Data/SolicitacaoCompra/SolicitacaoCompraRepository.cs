using System;
using System.Linq;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository: SolicitacaoCompraAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext _context;

        public SolicitacaoCompraRepository(SistemaCompraContext context) => (_context) = (context);

        public void Atualizar(SolicitacaoCompraAgg.SolicitacaoCompra entity)
        {
            _context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Update(entity);
        }

        public void Excluir(SolicitacaoCompraAgg.SolicitacaoCompra entity)
        {
            _context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Remove(entity);
        }

        public SolicitacaoCompraAgg.SolicitacaoCompra Obter(Guid id)
        {
            return _context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Where(c => c.Id == id).FirstOrDefault();
        }

        public void Registrar(SolicitacaoCompraAgg.SolicitacaoCompra entity)
        {
            _context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Add(entity);
        }       
    }
}
