namespace Models;

public class LivroCaixa {
    public List<string> Registro { get; set; }
    public decimal TotalRecebido { get; set; } = 0;
    public decimal TotalDespesas { get; set; } = 0;
    public decimal ValorEmCaixa { get; set; } = 0;

    public LivroCaixa () {
        Registro = new List<string> ();

        // Cabeçalho dos registros
        Registro.Add("|     Data do Recibo    |      Valor     |            Descrição            |"); 
    }

    private void SomarValor (decimal valorRecebido) {
        TotalRecebido = TotalRecebido + valorRecebido;
        ValorEmCaixa = ValorEmCaixa + valorRecebido;
    }

    private void SubtrairValor (decimal valorDespesa) {
        TotalDespesas = TotalDespesas - valorDespesa;
        ValorEmCaixa = ValorEmCaixa - valorDespesa;
    }
    public void RegistrarRecebimentoPorVeiculoEstacionado (decimal valorRecebido) {
        // Registra a alteração dos valores
        SomarValor(valorRecebido);

        // Registra o horário do recebimento
        DateTime dataRecibo = DateTime.Now;

        // Adiciona registro ao LivroCaixa
        string registro = $"|  {dataRecibo}  |  Valor: {valorRecebido}  |  Descrição: Veículo estacionado |";
        Registro.Add(registro);
    }

    public void RegistrarOutroRecebimento (decimal valorRecebido, string descricao) {
        // Registra a alteração dos valores
        SomarValor(valorRecebido);

        // Registra o horário do recebimento
        DateTime dataRecibo = DateTime.Now;

        // Adiciona registro ao LivroCaixa
        string registro = $"|  {dataRecibo}  |  Valor: {valorRecebido}  |  Descrição: {descricao} |";
        Registro.Add(registro);
    }

    public void RegistrarDespesa (decimal valorDespesa, string descricao) {
        // Registra a alteração dos valores
        SubtrairValor (valorDespesa);

        // Registra o horário do recebimento
        DateTime dataRecibo = DateTime.Now;

        // Adiciona registro ao LivroCaixa
        string registro = $"|  {dataRecibo}  |  Valor: {-valorDespesa}  |  Descrição: {descricao} |";
        Registro.Add(registro);
    }

    public void ExibirLivroCaixa () {
        foreach (var registro in Registro) {
            Console.WriteLine(registro);
        }

        Console.WriteLine($"\nGanhos totais: {TotalRecebido}");
        Console.WriteLine($"Despesas totais: {TotalDespesas}");
        Console.WriteLine($"\nValor em caixa: {ValorEmCaixa}");
    }
}