﻿using MediatR;
using System;

namespace SistemaCompra.Application.SolicitacaoCompra.Query.ObterSolicitacaoCompra
{
    public class ObterSolicitacaoCompraQuery : IRequest<ObterSolicitacaoCompraViewModel>
    {
        public Guid Id { get; set; }
    }
}
