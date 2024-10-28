public abstract class Produto
{
    public string Nome { get; set; }
    public int Codigo { get; set; }
    public decimal Preco { get; set; }

    public Produto(string nome, int codigo, decimal preco)
    {
        Nome = nome;
        Codigo = codigo;
        Preco = preco;
    }

    public abstract decimal CalcularPrecoFinal();
}