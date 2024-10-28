public class Pedido : ICarriavel
{
    public Cliente Cliente { get; set; }
    public DateTime DataPedido { get; set; }
    public string Status { get; set; }
    public List<Produto> Produtos { get; set; }

    public Pedido(List<Produto> produtos, Cliente cliente, DateTime datapedido, string status)
    {
        Produtos = produtos;
        Cliente = cliente;
        DataPedido = datapedido;
        Status = status;
    }

    public void AdicionarProduto(Produto produto)
    {
        if (Produtos.Any(p => p.Codigo == produto.Codigo))
        {
            Console.WriteLine("Já existe um produto com esse código.");
        }
        else
        {
            Produtos.Add(produto);
            Console.WriteLine("Produto adicionado com sucesso");
        }
    }

    public bool RemoverProduto(int codigoproduto)
    {
        Produto produtoRemover = Produtos.FirstOrDefault(p => p.Codigo == codigoproduto);
        if (produtoRemover != null)
        {
            Produtos.Remove(produtoRemover);
            return true;
        }
        return false;
    }

    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var item in Produtos)
        {
            if (item is ProdutoFisico produtoFisico)
            {
                total += produtoFisico.CalcularPrecoFinal();
            }
            else if (item is ProdutoDigital produtoDigital)
            {
                total += produtoDigital.CalcularPrecoFinal();
            }
        }
        return total;
    }

    public void FinalizarPedido()
    {
        if (Status == "Concluido")
        {
            Console.WriteLine("Este pedido já foi concluído.");
            return;
        }
        if (Status == "Cancelado")
        {
            Console.WriteLine("Este pedido foi cancelado e não pode ser finalizado.");
            return;
        }

        Status = "Concluido";
        Console.WriteLine("Pedido finalizado com sucesso.");
        Produtos.Clear();
        Console.WriteLine("Todos os produtos foram removidos após finalizar o pedido.");
    }
}