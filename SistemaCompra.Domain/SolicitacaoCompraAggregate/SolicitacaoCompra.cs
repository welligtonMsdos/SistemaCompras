using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        [NotMapped]
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }

        [NotMapped]
        public NomeFornecedor NomeFornecedor { get; private set; }

        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        //public Money TotalGeral { get; private set; }
        public decimal TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }

        [NotMapped]
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        public SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor, Produto produto, int qtde)
        {
            Itens = new List<Item>();

            AdicionarItem(produto, qtde);

            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;

            TotalGeral = qtde * produto.Preco;

            CondicaoPagamento = TotalGeral > 50000 ? new CondicaoPagamento(30) : new CondicaoPagamento(0);
            if (Itens.Count == 0) throw new BusinessRuleException("O total de itens de compra deve ser maior que 0.");
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {           
        }
    }
}
