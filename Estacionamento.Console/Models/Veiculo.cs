namespace Models;

public class Veiculo {
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Cor { get; set; }
    public DateTime Entrada { get; set; }
    public DateTime Saida { get; set; }

    public Veiculo (string placa, string marca, string cor, DateTime entrada) {
        Placa = placa;
        Marca = marca;
        Cor = cor;
        Entrada = entrada;
    }
}