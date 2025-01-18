namespace Models;

public class Veiculo {
    public string Placa { get; set; }
    private string Marca { get; set; }
    private string Cor { get; set; }
    private DateTime Entrada { get; set; }
    private DateTime Saida { get; set; }

    public Veiculo (string placa, string marca, string cor) {
        Placa = placa.ToUpper();
        Marca = marca;
        Cor = cor;
        Entrada = DateTime.Now;
    }

    public void Exibir () {
        Console.WriteLine($"| Placa: {Placa} | Marca: {Marca} | Cor: {Cor} |");
    }

    public decimal CalcularValorAReceber (decimal precoInicial, decimal precoPorHora) {
        // Registra o horário atual como horário de saída
        Saida = DateTime.Now;

        // Exibe os horários de entrada e saída
        Console.WriteLine($"Entrada: {Entrada}");
        Console.WriteLine($"Saída: {Saida}");

         // Calcula a diferença de horas entre a entrada e a saída
        TimeSpan timeSpan = Saida - Entrada;

        // Exibe o tempo estacionado
        Console.WriteLine($"Tempo de estacionamento: {timeSpan.Hours}");

        // Calcula o valor a receber com base no tempo estacionado
        decimal ValorAReceber = precoInicial + (precoPorHora * timeSpan.Hours);

        return ValorAReceber;
    }
}