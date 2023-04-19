using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SistemaCompra.Application.SolicitacaoCompra.Query.ObterSolicitacaoCompra;
using System;

namespace SistemaCompra.API.SolicitacaoCompra
{
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator) => (_mediator) = (mediator);

        [HttpPost, Route("solicitacaoCompra/registrarCompra")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult RegistrarCompra([FromBody] RegistrarCompraCommand registrarCompraCommand)
        {
            _mediator.Send(registrarCompraCommand);
            return StatusCode(201);
        }

        [HttpGet, Route("solicitacaoCompra/{id}")]
        public IActionResult Obter(Guid id)
        {
            var query = new ObterSolicitacaoCompraQuery() { Id = id };
            var produtoViewModel = _mediator.Send(query);
            return Ok(produtoViewModel);
        }
    }
}
