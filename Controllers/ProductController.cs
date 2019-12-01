using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ex_api_inicial.Models;
using ex_api_inicial.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ex_api_inicial.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController: Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            try
            {
                var result = await _productRepository.GetAll();

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
          
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Product>> GetById(Guid id)
        {
            try
            {
                var result = await _productRepository.GetById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);

            }
            catch (Exception)
            { 
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPost("Add")]
        public async Task<ActionResult<Product>> Add([FromBody]Product entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest("Client object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                await _productRepository.Add(entity);

                return CreatedAtAction(nameof(GetById), new { id = entity.ProductId }, entity);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery]Guid id, [FromBody]Product entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest("Client object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                if (id != entity.ProductId)
                {
                    return BadRequest();
                }

                await _productRepository.Update(entity);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}