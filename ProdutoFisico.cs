
public class ProdutoFisico : Produto
{
    private double preco;
    public double altura;
    public double largura;
    public double profundidade;

    public double Peso { get; set; }
    
    public string Categoria { get; set; }

    public Dimensoes DimensoesProduto { get; set; }
    
    




    public ProdutoFisico(double peso, string categoria, string nome, decimal preco, double altura, double largura, int codigo, double profundidade):base(nome,codigo,preco)
    {
        Peso = peso;
        Categoria = categoria;
        Nome = nome;
        Preco = preco;
        this.altura = altura;
        this.largura = largura;
        Codigo = codigo;
        this.profundidade = profundidade;
    }

    public void setPeso(double peso) {
    if(peso >= 0)
    {
        this.Peso = peso;
    }
    else
    {
        Console.WriteLine("Inválido, não é permitido peso negativo ");
    }

}
public class Dimensoes
{
    protected double Altura{get; set;}
    public double Largura{get; set;}
    public double Profundidade{get; set;}

    public Dimensoes(double altura,double largura, double profundidade)
    {
        Altura = altura;
        Largura = largura;
        Profundidade = profundidade;
    }

    public void setDimensoes(double altura,double largura,double profundidade)
    {
        if(altura>= 0 || largura >= 0 || profundidade >= 0)
        {
           this.Altura = altura;
            this.Largura = largura;
            this.Profundidade = profundidade;

        }
        else
        {
            Console.WriteLine("Inválido, não permitido nenhuma dimenção");
        }
    }

}
    public override decimal CalcularPrecoFinal()
    {
       double taxaDeImposto = (double)Preco * 0.1;
        double precoComImposto = (double)Preco + taxaDeImposto;
        double precoPorKg = 5;
        double custoEnvio = Peso * precoPorKg;
        double precoTotal = precoComImposto + custoEnvio;
        return (decimal)precoTotal;

        
         
        
       
    }

}