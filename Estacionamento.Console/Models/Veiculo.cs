namespace Estacionamento.Models;

public class Veiculo {
    public int Tipo { get; set; }
    public string Cor { get; set; }
    public string Placa { get; set; }
    public DateTime Entrada { get; set; }

    public Veiculo (int tipo, string cor, string placa) {
        // Tipo 1: Carro
        // Tipo 2: Moto
        Tipo = tipo;
        Cor = cor;
        Placa = placa;
        Entrada = DateTime.Now;
    }

    public int ObterHorasEstacionadas () {
        TimeSpan ts = DateTime.Now - Entrada;
        return ts.Hours;
    }
}