using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        [NotMapped]
        public UsuarioSolicitante UsuarioSolicitanteValidacao { get; private set; }

        public string UsuarioSolicitante { get; private set; }

        [NotMapped]
        public NomeFornecedor NomeFornecedorValidacao { get; private set; }
        public string NomeFornecedor { get; private set; }

        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }

        [NotMapped]
        public Money TotalGeralValidacao { get; private set; }  
        public decimal TotalGeral { get;private set; }
        public Situacao Situacao { get; private set; }

        [NotMapped]
        public CondicaoPagamento CondicaoPagamentoValidacao { get; private set; }
        public int CondicaoPagamento { get; private set; }

        public SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitanteValidacao = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedorValidacao = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;

            UsuarioSolicitante = UsuarioSolicitanteValidacao.Nome;
            NomeFornecedor = NomeFornecedorValidacao.Nome;
        }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor, Produto produto, int qtde)
        {
            Itens = new List<Item>();

            AdicionarItem(produto, qtde);

            Id = Guid.NewGuid();
            UsuarioSolicitanteValidacao = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedorValidacao = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;

            TotalGeralValidacao = new Money(qtde * produto.Preco);

            CondicaoPagamentoValidacao = TotalGeralValidacao.Value > 50000 ? new CondicaoPagamento(30) : new CondicaoPagamento(0);
            if (Itens.Count == 0) throw new BusinessRuleException("O total de itens de compra deve ser maior que 0.");

            TotalGeral = TotalGeralValidacao.Value;
            CondicaoPagamento = CondicaoPagamentoValidacao.Valor;
            UsuarioSolicitante = UsuarioSolicitanteValidacao.Nome;
            NomeFornecedor = NomeFornecedorValidacao.Nome;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itensProd)
        {
            var total = itensProd.ToList().Count;

            if (total == 0) throw new BusinessRuleException("A solicitação de compra deve possuir itens!");
        }
    }
}
