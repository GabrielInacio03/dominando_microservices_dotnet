using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShooping.ProductAPI.Data.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly Repository.IProductRepository _repository;
        
        public ProductController(Repository.IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("BuscarTodos")]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Get()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<ProductVO>> GetById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost("Criar")]
        public async Task<ActionResult<ProductVO>> Post([FromBody] ProductVO product)
        {
            if (product == null) return BadRequest();
            var createdProduct = await _repository.Create(product);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }
        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<ProductVO>> Put([FromBody] ProductVO product)
        {
            if (product == null) return BadRequest();
            var updatedProduct = await _repository.Update(product);
            if (updatedProduct == null) return NotFound();
            return Ok(updatedProduct);
        }
        [HttpDelete("Deletar/{id}")]
        public async Task<ActionResult<ProductVO>> Delete(long id)
        {
            var deleted = await _repository.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}