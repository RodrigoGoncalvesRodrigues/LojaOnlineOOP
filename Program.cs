using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private Pedido pedidoAtual;
    private Cliente clienteAtual;

    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }

    public void Run()
    {
        Loja loja = new Loja(new List<ProdutoFisico>(), new List<ProdutoDigital>(), new List<Produto>(), new List<Cliente>());

        while (true)
        {
            Console.WriteLine("█░░░ █▀▀█ ░░▀ █▀▀█   █▀▀▀█ █▀▀▄ █░░ ░▀░ █▀▀▄ █▀▀");
            Console.WriteLine("█░░░ █░░█ ░░█ █▄▄█   █░░▒█ █░░█ █░░ ▀█▀ █░░█ █▀▀");
            Console.WriteLine("█▄▄█ ▀▀▀▀ █▄█ ▀░░▀   █▄▄▄█ ▀░░▀ ▀▀▀ ▀▀▀ ▀░░▀ ▀▀▀");

            Console.WriteLine("1-Cadastrar novo cliente ");
            Console.WriteLine("2-Entrar ");
            Console.WriteLine("3-Sair ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":

                    Console.WriteLine("Digite o nome do cliente:");
                    string nome = Console.ReadLine();

                    Console.WriteLine("Digite o número de identificação do cliente:");
                    string numeroIdentificacao = Console.ReadLine();

                    Console.WriteLine("Digite o endereço do cliente:");
                    string endereco = Console.ReadLine();

                    Console.WriteLine("Digite o contato do cliente:");
                    string contato = Console.ReadLine();


                    
                    


                    loja.CadastrarCliente(nome, numeroIdentificacao, endereco, contato);
                    break;

                case "2":
                    Console.WriteLine("Escreva o número identificador do cliente (Pode ser CPF ou RG):");
                    string identificador = Console.ReadLine();
                    clienteAtual = loja.ConsultarClientePorId(identificador);

                    if (clienteAtual != null)
                    {
                        Console.WriteLine("Identificador encontrado. Continuando...\n");


                        bool continuar = true;
                        while (continuar)
                        {
                            Console.WriteLine("\n1- Cadastrar Produto ");
                            Console.WriteLine("2-Fazer pedido");
                            Console.WriteLine("3- Finalizar pedido ");
                            Console.WriteLine("0- Sair");

                            string escolha = Console.ReadLine();
                            switch (escolha)
                            {
                                case "1":
                                    Console.WriteLine("A-Produto Fisico");
                                    Console.WriteLine("B-Produto Digital");
                                    string tipoProduto = Console.ReadLine();
                                    if (tipoProduto == "A")
                                    {

                                        Console.WriteLine("Digite o peso do produto:");
                                        double peso = Convert.ToDouble(Console.ReadLine());


                                        Console.WriteLine("Digite a categoria do produto: ");
                                        string categoria = Console.ReadLine();

                                        Console.WriteLine("Digite o nome do produto:");
                                        string nomeProduto = Console.ReadLine();

                                        Console.WriteLine("Digite o preço do produto:");
                                        double preco = Convert.ToDouble(Console.ReadLine());

                                        Console.WriteLine("Digite a altura do produto:");
                                        double altura = Convert.ToDouble(Console.ReadLine());

                                        Console.WriteLine("Digite a largura do produto:");
                                        double largura = Convert.ToDouble(Console.ReadLine());

                                        Console.Write("Digite a profundidade:");
                                        double profundidade = Convert.ToDouble(Console.ReadLine());

                                        Console.WriteLine("Digite o código  do produto");
                                        int codigo = Convert.ToInt32(Console.ReadLine());

                                        if (string.IsNullOrWhiteSpace(categoria) || string.IsNullOrWhiteSpace(nomeProduto) || preco == null || altura == null || largura == null || profundidade == null || codigo == null)
                                        {
                                            Console.WriteLine("Todos os campos devem ser preenchidos com valores válidos. Por favor, tente novamente.");
                                        }

                                        if (loja.Produtos.Any(p => p.Codigo == codigo))
                                        {
                                            Console.WriteLine("Código já existente. Escolha outro código para o produto.\n");
                                        }
                                        else
                                        {

                                            ProdutoFisico novoProdutoFisico = new ProdutoFisico(peso, categoria, nomeProduto, (decimal)preco, altura, largura, codigo, profundidade);
                                            loja.CadastrarProduto(novoProdutoFisico);
                                        }
                                    }
                                    else if (tipoProduto == "B")
                                    {
                                        
                                        Console.WriteLine("Digite o nome do produto:");
                                        string nomeProdutoDigital = Console.ReadLine();

                                        Console.WriteLine("Digite o preço do produto:");
                                        double precoDigital = Convert.ToDouble(Console.ReadLine());

                                        Console.WriteLine("Digite o código  do produto");
                                        int codigoProdutoDigital = Convert.ToInt32(Console.ReadLine());

                                        if (loja.Produtos.Any(p => p.Codigo == codigoProdutoDigital))
                                        {
                                            Console.WriteLine("Código já existente. Escolha outro código para o produto.\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Digite o tamanho do arquivo  do produto(MB,GB)");
                                            double tamanhoArquivo = Convert.ToDouble(Console.ReadLine());

                                            Console.WriteLine("Digite o formato do arquivo  do produto(MB,GB)");
                                            string formato = Console.ReadLine();

                                            if (string.IsNullOrWhiteSpace(nomeProdutoDigital) || precoDigital == null || codigoProdutoDigital == null || tamanhoArquivo == null || formato == null)
                                            {
                                                Console.WriteLine("Preencha todos os campos");
                                                continue;

                                            }

                                            ProdutoDigital novoProdutoDigital = new ProdutoDigital(nomeProdutoDigital, (decimal)precoDigital, codigoProdutoDigital, tamanhoArquivo, formato);
                                            loja.CadastrarProduto(novoProdutoDigital);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Digite uma letra válida \n");
                                    }
                                    break;

                                case "2":
                                    if (pedidoAtual == null)
                                    {
                                        pedidoAtual = loja.CriarPedido(clienteAtual);
                                        Console.WriteLine("Pedido criado. Você pode adicionar produtos a ele.");
                                    }



                                    while (true)
                                    {
                                        Console.WriteLine("1-Adicionar Produto ao carrinho");
                                        Console.WriteLine("2-Remover produto do carrinho");
                                        Console.WriteLine("3-Listar pedido");
                                        Console.WriteLine("4-Calcular Preço Final");
                                        Console.WriteLine("5-Exibir informações do cliente");
                                        Console.WriteLine("6-Listar clientes");
                                        Console.WriteLine("7-Consultar cliente");
                                        Console.WriteLine("8-Calcular Total");
                                        Console.WriteLine("9-Listar Produtos");
                                        Console.WriteLine("10-Consultar Produto ");




                                        Console.WriteLine("0- Voltar");

                                        string escolhaPedido = Console.ReadLine();
                                        switch (escolhaPedido)
                                        {
                                            case "1":
                                                Console.WriteLine("Digite o código do produto que deseja adicionar:");
                                                int codigoproduto = Convert.ToInt32(Console.ReadLine());
                                                Produto produtoselecionado = loja.Produtos.FirstOrDefault(p => p.Codigo == codigoproduto);

                                                if (produtoselecionado != null)
                                                {
                                                    Console.WriteLine($"Produto selecionado: {produtoselecionado.Nome} ");
                                                    Console.WriteLine($"Preço: {produtoselecionado.Preco} ");
                                                    pedidoAtual.AdicionarProduto(produtoselecionado);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Produto não encontrado");
                                                }
                                                break;

                                            case "2":
                                                Console.WriteLine("Digite o código do produto que deseja remover:");
                                                int codigoProdutoRemover = Convert.ToInt32(Console.ReadLine());
                                                bool removido = pedidoAtual.RemoverProduto(codigoProdutoRemover);

                                                if (removido)
                                                {
                                                    Console.WriteLine("Produto removido do pedido com sucesso.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Produto não encontrado no pedido.");
                                                }
                                                break;




                                            case "3":
                                                loja.ListarPedidos();
                                                break;

                                            case "4":
                                                if (pedidoAtual.Produtos.Count == 0)
                                                {
                                                    Console.WriteLine("Nenhum produto no pedido.");
                                                }
                                                else
                                                {
                                                    decimal totalPrecoFinal = 0;

                                                    foreach (var produto in pedidoAtual.Produtos)
                                                    {
                                                        totalPrecoFinal += produto.CalcularPrecoFinal();  
                                                    }

                                                    Console.WriteLine($"Preço total do pedido: {totalPrecoFinal}");
                                                }
                                                break;

                                            case "5":
                                                clienteAtual.ExibirInformacoes();
                                                break;


                                            case "6":
                                                loja.ListarClientes();
                                                break;

                                            case "7":
                                                Console.WriteLine("Digite o número de identificação do cliente:");
                                                string numeroIdentificacaoConsulta = Console.ReadLine();
                                                loja.ConsultarCliente(numeroIdentificacaoConsulta);
                                                break;



                                            case "8":
                                                if (pedidoAtual != null && pedidoAtual.Produtos.Count > 0)
                                                {
                                                    decimal total = pedidoAtual.CalcularTotal();
                                                    Console.WriteLine($"Total do pedido: {total}");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Nenhum produto no pedido para calcular o total.");
                                                }
                                                break;

                                            case "9":
                                                loja.ListarProdutos();
                                                break;

                                            case "10":
                                                Console.WriteLine("Digite o código do produto que deseja consultar:");
                                                int codigoProdutoConsulta = Convert.ToInt32(Console.ReadLine());
                                                loja.ConsultarProduto(codigoProdutoConsulta);
                                                break;



                                            case "0":
                                                break;

                                            default:
                                                Console.WriteLine("Opção inválida. Tente novamente.");
                                                break;
                                        }

                                        if (string.IsNullOrEmpty(escolhaPedido) || escolhaPedido == "0")
                                        {
                                            break; 
                                        }
                                    }
                                    break;

                                case "3":
                                    if (pedidoAtual == null || pedidoAtual.Produtos.Count == 0)
                                    {
                                        Console.WriteLine("Nenhum pedido para finalizar.");
                                        break;
                                    }

                                    var valor_total = pedidoAtual.CalcularTotal();
                                    Console.WriteLine($"Valor total do pedido: {valor_total:C}");
                                    Console.WriteLine("Escolha o método de pagamento:");
                                    Console.WriteLine("1- PIX");
                                    Console.WriteLine("2- Cartão");
                                    Console.WriteLine("3- Dinheiro");

                                    string pagamento = Console.ReadLine();

                                    switch (pagamento)
                                    {
                                        case "1":
                                            Console.WriteLine("Chave PIX: 948.653.571-23");
                                            Console.WriteLine("Pagamento realizado via PIX. Pedido finalizado.");
                                            pedidoAtual.FinalizarPedido();
                                            pedidoAtual = null;
                                            break;

                                        case "2":
                                            Console.WriteLine("Escolha a forma de pagamento:");
                                            Console.WriteLine("1- Débito");
                                            Console.WriteLine("2- Crédito");

                                            string dc = Console.ReadLine();
                                            if (dc == "1")
                                            {
                                                Console.WriteLine("Pagamento por Débito. Insira ou aproxime o cartão.");
                                                pedidoAtual.FinalizarPedido();
                                                pedidoAtual = null;
                                            }
                                            else if (dc == "2")
                                            {
                                                Console.WriteLine("Pagamento por Crédito. Insira ou aproxime o cartão.");
                                                pedidoAtual.FinalizarPedido();
                                                pedidoAtual = null;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Opção inválida para pagamento com cartão. Tente novamente.");
                                            }
                                            break;

                                        case "3":
                                            Console.WriteLine("Pague o valor diretamente ao dono da loja.");
                                            pedidoAtual.FinalizarPedido();
                                            pedidoAtual = null;
                                            break;

                                        default:
                                            Console.WriteLine("Método de pagamento inválido. Tente novamente.");
                                            break;
                                    }
                                    break;






                                case "0":
                                    continuar = false;
                                    break;

                                default:
                                    Console.WriteLine("Opção inválida. Tente novamente.");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Identificador não encontrado. Tente novamente.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Saindo do programa.");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
