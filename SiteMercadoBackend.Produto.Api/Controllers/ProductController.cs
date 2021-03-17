using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SiteMercadoBackend.Produto.Commands;
using SiteMercadoBackend.Produto.Entities;
using SiteMercadoBackend.Produto.Handlers;
using SiteMercadoBackend.Produto.Repositories;

namespace SiteMercadoBackend.Produto.Api.Controllers {

    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Product> GetAll(
        [FromServices]IProductRepository repository)
        {
            return repository.GetAll();
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody]CreateProductCommand command,
        [FromServices]ProductHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody]UpdateProductCommand command,
        [FromServices]ProductHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{productId}")]
        [HttpDelete]
        public GenericCommandResult Delete(Guid productId,
        [FromServices]ProductHandler handler)
        {
            var command = new DeleteProductCommand(productId);
            return (GenericCommandResult)handler.Handle(command);
        }
        
    }
}