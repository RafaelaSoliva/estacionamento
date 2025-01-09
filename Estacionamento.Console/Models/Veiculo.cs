namespace Models;

public class Veiculo {
    public string Placa { get; set; }
    private string Marca { get; set; }
    private string Cor { get; set; }
    private DateTime Entrada { get; set; }
    private DateTime Saida { get; set; }

    public Veiculo (string placa, string marca, string cor) {
        Placa = placa;
        Marca = marca;
        Cor = cor;
        Entrada = DateTime.Now;
    }

    public void ExibirVeiculo () {
        Console.WriteLine($"| Placa: {Placa} | Marca: {Marca} | Cor: {Cor} |");
    }

    public decimal CalcularValorAReceber (decimal precoInicial, decimal precoPorHora) {
        // Registra o horário atual como horário de saída
        Saida = DateTime.Now;

         // Calcula a diferença de horas entre a entrada e a saída
        TimeSpan timeSpan = Saida - Entrada;

        // Calcula o valor a receber com base no tempo estacionado
        decimal ValorAReceber = precoInicial + (precoPorHora * timeSpan.Hours);

        return ValorAReceber;
    }
}