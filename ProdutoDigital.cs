public class ProdutoDigital : Produto
{
    private string? nomeprodutodigital;
    private double precoprodutodigital;
    private int codigoprodutodigital;

    public double TamanhoArquivo { get; set; }

    public string Formato { get; set; }

    public void setTamanhoArquivo(double tamanhoArquivo)
    {
        if (tamanhoArquivo >= 0)
        {
            this.TamanhoArquivo = tamanhoArquivo;
        }
        else
        {
            Console.WriteLine(" inválida ,não é permitido numero de arquivo negativo");
        }
    }



    public ProdutoDigital(string nome, decimal preco, int codigo, double tamanhoarquivo, string formato) : base(nome, (int)preco, codigo)
    {
        Nome = nome;
        Preco = preco;
        Codigo = codigo;
        TamanhoArquivo = tamanhoarquivo;
        Formato = formato;
    }




    public override decimal CalcularPrecoFinal()
    {
         double taxaDeDesconto = (double)Preco * 0.2;
        double precoFinal = (double)Preco - taxaDeDesconto;
        return (decimal)precoFinal;
    }



}