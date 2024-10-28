public class Loja
{
    public List<Produto> Produtos { get; set; }
    public List<Cliente> Clientes { get; set; }
    public List<Pedido> Pedidos { get; set; }
    public List<ProdutoFisico> ProdutosFisicos { get; set; }
    public List<ProdutoDigital> ProdutosDigitais { get; set; }

    public Loja(List<ProdutoFisico> produtosfisicos, List<ProdutoDigital> produtosdigitais, List<Produto> produtos, List<Cliente> clientes)
    {
        Produtos = produtos;
        Clientes = clientes;
        ProdutosFisicos = produtosfisicos;
        ProdutosDigitais = produtosdigitais;
        Pedidos = new List<Pedido>();
    }

    public bool CadastrarCliente(string nome, string numeroidentificacao, string endereco, string contato)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(numeroidentificacao) ||
        string.IsNullOrEmpty(endereco) || string.IsNullOrEmpty(contato))
        {
            Console.WriteLine("Todos os campos são obrigatórios.\n");
            return false;
        }

        if (Clientes.Any(c => c.NumeroIdentificacao == numeroidentificacao))
        {
            Console.WriteLine("Cliente já cadastrado.");
            return false;
        }

        Cliente novoCliente = new Cliente(nome, numeroidentificacao, endereco, contato);
        Clientes.Add(novoCliente);
        Console.WriteLine("Cliente cadastrado com sucesso.");
        return true;
    }

    public void CadastrarProduto(Produto produto)
    {
        if (Produtos == null) Produtos = new List<Produto>();

        if (produto is ProdutoFisico)
        {
            ProdutosFisicos.Add((ProdutoFisico)produto);
        }
        else if (produto is ProdutoDigital)
        {
            ProdutosDigitais.Add((ProdutoDigital)produto);
        }

        Produtos.Add(produto);
        Console.WriteLine("Produto cadastrado com sucesso!\n");
    }

    public Cliente ConsultarClientePorId(string numeroIdentificacao)
    {
        Cliente clienteEncontrado = Clientes.FirstOrDefault(c => c.NumeroIdentificacao == numeroIdentificacao);

        if (clienteEncontrado != null)
        {
            Console.WriteLine($"Cliente encontrado: Nome: {clienteEncontrado.Nome}, Número de Identificação: {clienteEncontrado.NumeroIdentificacao}");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }

        return clienteEncontrado;
    }

    public Pedido CriarPedido(Cliente cliente)
    {
        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado.");
            return null;
        }

        Pedido novoPedido = new Pedido(new List<Produto>(), cliente, DateTime.Now, "Em andamento");
        Pedidos.Add(novoPedido);
        Console.WriteLine("Novo pedido criado com sucesso.");
        return novoPedido;
    }



    public Produto ConsultarProdutoPorCodigo(int codigo)
    {
        Produto produtoEncontrado = Produtos.FirstOrDefault(p => p.Codigo == codigo);

        if (produtoEncontrado != null)
        {
            Console.WriteLine($"Produto encontrado: Nome: {produtoEncontrado.Nome}, Código: {produtoEncontrado.Codigo}, Preço: {produtoEncontrado.Preco}");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }

        return produtoEncontrado;
    }




    public void ListarPedidos()
    {
        if (Pedidos.Count == 0)
        {
            Console.WriteLine("Não há pedidos para exibir.");
            return;
        }

        Console.WriteLine("Lista de Pedidos:");
        foreach (var pedido in Pedidos)
        {
            Console.WriteLine($"Pedido ID: {pedido.Cliente.NumeroIdentificacao} - Data: {pedido.DataPedido} - Status: {pedido.Status}");
            Console.WriteLine("Produtos no pedido:");
            foreach (var produto in pedido.Produtos)
            {
                Console.WriteLine($"- {produto.Nome} (Código: {produto.Codigo}, Preço: {produto.Preco})\n");
            }
            
        }
    }
    public void ListarClientes()
    {
        if (Clientes.Count == 0)
        {
            Console.WriteLine("Não há clientes cadastrados.");
            return;
        }

        Console.WriteLine("Lista de Clientes:");
        foreach (var cliente in Clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}, Número de Identificação: {cliente.NumeroIdentificacao}\n");
            Console.WriteLine("Obs: nem todas as informações estão visíveis para meios de segurança");

        }
    }
    public Cliente ConsultarCliente(string numeroIdentificacao)
    {
        Cliente clienteEncontrado = Clientes.FirstOrDefault(c => c.NumeroIdentificacao == numeroIdentificacao);

        if (clienteEncontrado != null)
        {
            Console.WriteLine("Cliente encontrado:");
            Console.WriteLine($"Nome: {clienteEncontrado.Nome}");
            Console.WriteLine($"Número de Identificação: {clienteEncontrado.NumeroIdentificacao}");
            Console.WriteLine("Obs: nem todas as informações estão visíveis para meios de segurança");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }

        return clienteEncontrado;
    }
    public void ListarProdutos()
    {
        if (Produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("Lista de Produtos:");
        foreach (var produto in Produtos)
        {
            Console.WriteLine($"Nome: {produto.Nome}");
            Console.WriteLine($"Código: {produto.Codigo}");
            Console.WriteLine($"Preço: {produto.Preco}");

            if (produto is ProdutoFisico produtoFisico)
            {
                Console.WriteLine($"Peso: {produtoFisico.Peso} kg");
                Console.WriteLine($"Altura: {produtoFisico.altura} m");
                Console.WriteLine($"Largura: {produtoFisico.largura} m");
                Console.WriteLine($"Profundidade: {produtoFisico.profundidade} m");
                Console.WriteLine($"Categoria: {produtoFisico.Categoria}");
            }
            else if (produto is ProdutoDigital produtoDigital)
            {
                Console.WriteLine($"Tamanho do Arquivo: {produtoDigital.TamanhoArquivo} MB");
                Console.WriteLine($"Formato: {produtoDigital.Formato}");
            }
        }
    }
    public void ConsultarProduto(int codigo)
{
    var produto = Produtos.FirstOrDefault(p => p.Codigo == codigo);

    if (produto != null)
    {
        Console.WriteLine("Detalhes do Produto:");
        Console.WriteLine($"Nome: {produto.Nome}");
        Console.WriteLine($"Código: {produto.Codigo}");
        Console.WriteLine($"Preço: {produto.Preco}");
        
        if (produto is ProdutoFisico produtoFisico)
        {
            Console.WriteLine($"Peso: {produtoFisico.Peso} kg");
            Console.WriteLine($"Altura: {produtoFisico.altura} m");
            Console.WriteLine($"Largura: {produtoFisico.largura} m");
            Console.WriteLine($"Profundidade: {produtoFisico.profundidade} m");
            Console.WriteLine($"Categoria: {produtoFisico.Categoria}");
        }
        else if (produto is ProdutoDigital produtoDigital)
        {
            Console.WriteLine($"Tamanho do Arquivo: {produtoDigital.TamanhoArquivo} MB");
            Console.WriteLine($"Formato: {produtoDigital.Formato}");
        }
    }
    else
    {
        Console.WriteLine("Produto não encontrado.");
    }
}


}
