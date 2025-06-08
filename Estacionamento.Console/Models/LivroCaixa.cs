namespace Models;

public class LivroCaixa {
    public List<string> Registros { get; set; }
    public decimal TotalReceitas { get; set; }
    public decimal TotalDespesas { get; set; }
    public decimal ValorEmCaixa { get; set; }

    public LivroCaixa () {
        Registros = new List<string> ();

        string cabecalho = "Data/Hora:              | Valor:   | Descrição:\n";
        Registros.Add(cabecalho);

        TotalReceitas = 0.0m;
        TotalDespesas = 0.0m;
        ValorEmCaixa = 0.0m;
    }

    public void Exibir () {
        foreach (var registro in Registros) {
            Console.WriteLine(registro);
        }
        
        Console.WriteLine($"\nReceitas totais: {TotalReceitas}");
        Console.WriteLine($"Despesas totais: {TotalDespesas}");
        Console.WriteLine($"Valor em caixa: {ValorEmCaixa}");
    }

    private void SomarReceita (decimal receita) {
        TotalReceitas =+ receita;
    }

    private void SomarDespesa (decimal despesa) {
        TotalDespesas =+ despesa;
    }

    public void RegistrarReceita (decimal receita, string descricao) {
        string registro = $"{DateTime.Now}     |  {receita}     | {descricao}";
        SomarReceita(receita);
        Registros.Add(registro);
    }

    public void RegistrarDespesa (decimal despesa, string descricao) {
        string registro = $"{DateTime.Now}     | {-despesa}     | {descricao}";
        SomarDespesa(despesa);
        Registros.Add(registro);
    }
}