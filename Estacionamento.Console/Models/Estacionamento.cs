namespace Models;

public class Estacionamento {
    private LivroCaixa LivroCaixa { get; set; }
    private List<Veiculo> VeiculosEstacionados { get; set; }
    private decimal PrecoInicial { get; set; }
    private decimal PrecoPorHora { get; set; }

    public Estacionamento () {
        LivroCaixa = new LivroCaixa();
        VeiculosEstacionados = new List<Veiculo> ();
        EntradaPrecoInicial();
        EntradaPrecoPorHora();
        Console.WriteLine("\nSistema iniciado com sucesso!\n");
    }

    private void EntradaPrecoInicial () {
        Console.WriteLine("Informe o preço inicial a ser cobrado:");
        string entradaUsuario = Console.ReadLine();
        bool sucesso = Decimal.TryParse(entradaUsuario, out decimal precoInicial);

        if (sucesso) {
            PrecoInicial = precoInicial;
        } else {
            Console.WriteLine("\nValor inválido!");
            Console.WriteLine("Utilize o formato xx.yy\n");
            EntradaPrecoInicial();
        }
    }

    private void EntradaPrecoPorHora () {
        Console.WriteLine("\nInforme o preço adicional por hora no formato xx,yy:");
        string entradaUsuario = Console.ReadLine();
        bool sucesso = Decimal.TryParse(entradaUsuario, out decimal precoPorHora);

        if (sucesso) {
            PrecoPorHora = precoPorHora;
        } else {
            Console.WriteLine("\nValor inválido!");
            Console.WriteLine("Utilize o formato xx,yy\n");
            EntradaPrecoPorHora();
        }
    }

    private bool VeiculoEstaEstacionado (string placa) {
        return VeiculosEstacionados.Exists(x => x.Placa == placa.ToUpper());
    }

    public void AdicionarVeiculo () {
        // Recebe a placa do veiculo
        Console.WriteLine("Placa: ");
        string placa = Console.ReadLine();

        // Verifica se a placa inserida já pertence a um veículo estacionado
        if (!VeiculoEstaEstacionado(placa)) {
            // Recebe os dados restantes
            Console.WriteLine("\nMarca: ");
            string marca = Console.ReadLine();
            Console.WriteLine("\nCor: ");
            string cor = Console.ReadLine();

            // Adiciona o veículo
            Veiculo veiculoAdicionado = new Veiculo (placa, marca, cor);
            VeiculosEstacionados.Add(veiculoAdicionado);
            Console.WriteLine("\nVeículo registrado com sucesso!\n");
            veiculoAdicionado.Exibir();

            // Verifica se o usuário deseja registrar outro veículo e chama o método caso necessário
            Console.WriteLine("\nRegistrar outro veiculo? (s/n)");
            string resposta = Console.ReadLine();
            if (resposta == "s" || resposta == "S") {
                Console.Clear();
                AdicionarVeiculo();
            }

        } else { // Caso o veículo já esteja registrado
            Console.WriteLine("Veículo já registrado! Registrar outra placa? (s/n)");
            string resposta = Console.ReadLine();
            if (resposta == "s" || resposta == "S") {
                Console.Clear();
                AdicionarVeiculo();
            }
        }
    }

    public void RemoverVeiculo () {
        // Recebe a placa do veiculo
        Console.WriteLine("Placa: ");
        string placa = Console.ReadLine();
        placa = placa.ToUpper();

        // Verifica se a placa inserida pertence a um veículo estacionado
        if (VeiculoEstaEstacionado(placa)) {
            // Encontra o veículo na lista
            int posicaoVeiculo = VeiculosEstacionados.FindIndex(x => x.Placa == placa);

            // Calcula o valor a receber e exibe
            decimal valorAReceber = VeiculosEstacionados[posicaoVeiculo].CalcularValorAReceber(PrecoInicial, PrecoPorHora);
            Console.WriteLine($"\nConfirmar pagamento de R$ {valorAReceber}? - Pressione Enter");
            Console.ReadLine();
            
            // Registra a receita no livro caixa
            LivroCaixa.RegistrarReceitaPorVeiculoEstacionado(valorAReceber);

            // Retorna a confirmação para o usuário
            Console.WriteLine($"Veículo placa {VeiculosEstacionados[posicaoVeiculo].Placa} liberado!");
            
            // Remove o veículo da lista
            VeiculosEstacionados.Remove(VeiculosEstacionados[posicaoVeiculo]);

        } else { // Caso a placa inserida não pertença a um veículo estacionado
            Console.WriteLine("\nVeículo não encontrado! Tentar novamente? (s/n)");
            string resposta = Console.ReadLine();
            if (resposta == "s" || resposta == "S") {
                Console.Clear();
                RemoverVeiculo();
            }
        }
    }

    public void ExibirVeiculosEstacionados () {
        if (VeiculosEstacionados.Count > 0) {
            Console.WriteLine("|            Veículos Estacionados:          |\n");
                foreach (var veiculo in VeiculosEstacionados) {
                veiculo.Exibir();
            }
        } else {
            Console.WriteLine("\nAinda não há veículos!");
        }
    }

    public void RegistrarReceita () {
        LivroCaixa.RegistrarOutraReceita();
    }

    public void RegistrarDespesa () {
        LivroCaixa.RegistrarDespesa();
    }

    public void ExibirLivroCaixa () {
        LivroCaixa.Exibir();
    }
}