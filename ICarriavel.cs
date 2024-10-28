public interface ICarriavel
{
    public  void  AdicionarProduto(Produto produto);
    public  bool RemoverProduto(int codigoproduto);
    public  decimal CalcularTotal();
}