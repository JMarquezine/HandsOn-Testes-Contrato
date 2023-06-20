using HandsonTesteContrato.Models;
using HandsonTesteContrato.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace HandsonTesteContrato.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IObterProdutoUseCase _getProductUseCase;

    public ProductsController(IObterProdutoUseCase getProductUseCase)
    {
        _getProductUseCase = getProductUseCase;
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> Get(int id)
    {
        var product = _getProductUseCase.ObterProdutoPorId(id);

        if (product == null)
        {
            var error = new Error { Message = $"Produto com o ID {id} não encontrado." };
            return NotFound(error);
        }

        return Ok(product);
    }
}
