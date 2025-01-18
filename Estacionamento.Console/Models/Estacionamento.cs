namespace Models;

public class Estacionamento {
    private LivroCaixa LivroCaixa { get; set; }
    private List<Veiculo> VeiculosEstacionados { get; set; }
    private decimal PrecoInicial { get; set; }
    private decimal PrecoPorHora { get; set; }

    public Estacionamento (decimal precoInicial, decimal precoPorHora) {
        LivroCaixa = new LivroCaixa();
        VeiculosEstacionados = new List<Veiculo> ();
        PrecoInicial = precoInicial;
        PrecoPorHora = precoPorHora;
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
            Console.WriteLine("Marca: ");
            string marca = Console.ReadLine();
            Console.WriteLine("Cor: ");
            string cor = Console.ReadLine();

            // Adiciona o veículo
            Veiculo veiculoAdicionado = new Veiculo (placa, marca, cor);
            VeiculosEstacionados.Add(veiculoAdicionado);
            Console.WriteLine("Veículo registrado com sucesso!");
            veiculoAdicionado.Exibir();

            // Verifica se o usuário deseja registrar outro veículo e chama o método caso necessário
            Console.WriteLine("Registrar outro veiculo? (s/n)");
            string resposta = Console.ReadLine();
            if (resposta == "s" || resposta == "S") {
                AdicionarVeiculo();
            }

        } else { // Caso o veículo já esteja registrado
            Console.WriteLine("Veículo já registrado! Registrar outra placa? (s/n)");
            string resposta = Console.ReadLine();
            if (resposta == "s" || resposta == "S") {
                AdicionarVeiculo();
            }
        }
    }

    public void RemoverVeiculo () {
        // Recebe a placa do veiculo
        Console.WriteLine("Placa: ");
        string placa = Console.ReadLine();

        // Verifica se a placa inserida pertence a um veículo estacionado
        if (VeiculoEstaEstacionado(placa)) {
            // Encontra o veículo na lista
            Veiculo veiculoARemover = VeiculosEstacionados.Find(x => x.Placa == placa);

            // Calcula o valor a receber e exibe
            decimal valorAReceber = veiculoARemover.CalcularValorAReceber(PrecoInicial, PrecoPorHora);
            Console.WriteLine($"Confirmar pagamento de R$ {valorAReceber}? - Pressione Enter");
            Console.ReadLine();
            
            // Registra a receita no livro caixa
            LivroCaixa.RegistrarReceitaPorVeiculoEstacionado(valorAReceber);

            // Remove o veículo da lista
            VeiculosEstacionados.Remove(veiculoARemover);

            // Retorna a confirmação para o usuário
            Console.WriteLine($"Veículo placa {veiculoARemover.Placa} liberado!");
        } else { // Caso a placa inserida não pertença a um veículo estacionado
            Console.WriteLine("Veículo não encontrado! Tentar novamente? (s/n)");
            string resposta = Console.ReadLine();
            if (resposta == "s" || resposta == "S") {
                RemoverVeiculo();
            }
        }
    }

    public void ExibirVeiculosEstacionados () {
        Console.WriteLine("|            Veículos Estacionados:          |\n");
        foreach (var veiculo in VeiculosEstacionados) {
            veiculo.Exibir();
        }
    }

    public void RegistrarReceita (decimal valorReceita, string descricao) {
        LivroCaixa.RegistrarOutraReceita (valorReceita, descricao);
    }

    public void RegistrarDespesa (decimal valorDespesa, string descricao) {
        LivroCaixa.RegistrarDespesa(valorDespesa, descricao);
    }

    public void ExibirLivroCaixa () {
        LivroCaixa.Exibir();
    }
}