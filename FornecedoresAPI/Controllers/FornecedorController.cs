using FornecedoresAPI.Models;
using FornecedoresAPI.Pagination;
using FornecedoresAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FornecedoresAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class FornecedoresController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        public FornecedoresController(IUnitOfWork context)
        {
            _uof = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> Get([FromQuery] 
            FornecedoresParameters fornecedoresParameters)
        {
            var result = await _uof.FornecedorRepository.GetFornecedores(fornecedoresParameters);

            var metaData = new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            return result;
        }

        [HttpGet("{id:int}", Name = "ObterFornecedor")]
        public async Task<ActionResult<Fornecedor>> Get(int id)
        {
            var result = await _uof.FornecedorRepository.GetById(c => c.FornecedorId == id);
            if (result == null)
            {
                return NotFound("Fornecedor não encontrado");
            }
            return result;
        }
        [HttpPost]
        public ActionResult Post(Fornecedor fornecedor)
        {
            _uof.FornecedorRepository.Add(fornecedor);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterFornecedor",
               new { id = fornecedor.FornecedorId }, fornecedor);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.FornecedorId)
            {
                return BadRequest("Fornecedor não encontrado!");
            }

            _uof.FornecedorRepository.Update(fornecedor);
            _uof.Commit();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var fornecedor = await _uof.FornecedorRepository.GetById(c => c.FornecedorId == id);
            if (fornecedor is null)
            {
                return NotFound("Fornecedor não existe");
            }
            _uof.FornecedorRepository.Delete(fornecedor);
            await _uof.Commit();
            return Ok();
        }
    }
}
