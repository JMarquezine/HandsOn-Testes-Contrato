using HandsonTesteContrato.Models;

namespace HandsonTesteContrato.UseCase;

public interface IObterProdutoUseCase
{
    Produto ObterProdutoPorId(int id);
}