public class Cliente
{
    public string Nome { get; set; }
    public string NumeroIdentificacao { get; set; }

    protected string Endereco { get; set; }
    protected string Contato { get; set; }

    public Cliente(string nome, string numeroIdentificacao, string endereco, string contato)
    {
        Nome = nome;
        NumeroIdentificacao = numeroIdentificacao;
        Endereco = endereco;
        Contato = contato;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine("Informações do Cliente:");
        Console.WriteLine($"Número de Identificação: {NumeroIdentificacao}");
        Console.WriteLine("Obs: nem todas as informações estão visíveis para meios de segurança");
    }
}