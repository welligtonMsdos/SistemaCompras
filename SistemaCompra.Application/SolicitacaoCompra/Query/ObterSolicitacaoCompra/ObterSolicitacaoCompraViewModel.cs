using System;

namespace SistemaCompra.Application.SolicitacaoCompra.Query.ObterSolicitacaoCompra
{
    public class ObterSolicitacaoCompraViewModel
    {
        public DateTime Data { get; set; }
        public string NomeFornecedor { get; set; }
        public string UsuarioSolicitante { get; set; }
    }
}
