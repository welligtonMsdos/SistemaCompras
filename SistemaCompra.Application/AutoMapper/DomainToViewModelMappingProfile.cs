using AutoMapper;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using SistemaCompra.Application.SolicitacaoCompra.Query.ObterSolicitacaoCompra;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            //CreateMap<ProdutoAgg.Produto, ObterProdutoViewModel>()
            //    .ForMember(d=> d.Preco, o=> o.MapFrom(src=> src.Preco.Value));

            CreateMap<ProdutoAgg.Produto, ObterProdutoViewModel>()
                .ForMember(d => d.Preco, o => o.MapFrom(src => src.Preco));

            CreateMap< SistemaCompraAgg.SolicitacaoCompra,  ObterSolicitacaoCompraViewModel>()
                .ForMember(d => d.UsuarioSolicitante, o => o.MapFrom(src => src.UsuarioSolicitante.Nome))
                .ForMember(d => d.NomeFornecedor, o => o.MapFrom(src => src.NomeFornecedor.Nome)).ReverseMap();
        }
    }
}
