using HandsonTesteContrato.Models;

namespace HandsonTesteContrato.UseCase;

public class ObterProdutoUseCase : IObterProdutoUseCase
{
    private readonly List<Produto> _products;

    public ObterProdutoUseCase()
    {
        _products = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Produto A", QuantidadeEmEstoque = 15, Descricao = "Descrição do Produto A" },
            new Produto { Id = 2, Nome = "Produto B", QuantidadeEmEstoque = 5, Descricao = "Descrição do Produto B" },
            new Produto { Id = 3, Nome = "Produto C", QuantidadeEmEstoque = 2, Descricao = "Descrição do Produto C" }
        };
    }

    public Produto ObterProdutoPorId(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return product;
    }
}