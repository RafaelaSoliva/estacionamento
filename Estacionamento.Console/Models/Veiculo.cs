namespace Models;

public class Veiculo {
    public int Tipo { get; set; }
    public string Cor { get; set; }
    public string Placa { get; set; }
    public DateTime Entrada { get; set; }

    public Veiculo (string cor, string placa) {
        Cor = cor.ToUpper();
        Placa = placa.ToUpper();
        Entrada = DateTime.Now;
    }

    public int ObterHorasEstacionadas () {
        TimeSpan ts = DateTime.Now - Entrada;
        return ts.Hours;
    }
}