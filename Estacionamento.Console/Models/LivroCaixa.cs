namespace Models;

public class LivroCaixa {
    private List<string> Registro { get; set; }
    private decimal TotalReceitas { get; set; } = 0;
    private decimal TotalDespesas { get; set; } = 0;
    private decimal ValorEmCaixa { get; set; } = 0;

    public LivroCaixa () {
        Registro = new List<string> ();

        // Cabeçalho dos registros
        Registro.Add("|     Data do Recibo    |      Valor     |            Descrição            |"); 
    }

    private void SomarValor (decimal valorReceita) {
        TotalReceitas = TotalReceitas + valorReceita;
        ValorEmCaixa = ValorEmCaixa + valorReceita;
    }

    private void SubtrairValor (decimal valorDespesa) {
        TotalDespesas = TotalDespesas - valorDespesa;
        ValorEmCaixa = ValorEmCaixa - valorDespesa;
    }

    public void RegistrarReceitaPorVeiculoEstacionado (decimal valorReceita) {
        // Registra a alteração dos valores
        SomarValor(valorReceita);

        // Registra o horário do recebimento
        DateTime dataRecibo = DateTime.Now;

        // Adiciona registro ao LivroCaixa
        string registro = $"|  {dataRecibo}  |  Valor: {valorReceita}  |  Descrição: Veículo estacionado |";
        Registro.Add(registro);
    }

    public void RegistrarOutraReceita () {
        Console.WriteLine("Insira o valor da receita no formato xx,yy:");
        bool valorEValido = Decimal.TryParse(Console.ReadLine(), out decimal valorReceita);

        if (!valorEValido) {
            Console.WriteLine("Valor inválido!");
            Console.WriteLine("Utilize o formato xx,yy");
            RegistrarOutraReceita();
        }

        // Registra a alteração dos valores
        SomarValor(valorReceita);

        // Registra o horário do recebimento
        DateTime dataRecibo = DateTime.Now;

        // Recebe a descrição
        Console.WriteLine("\nInsira a descrição da receita: ");
        string descricao = Console.ReadLine();

        // Adiciona registro ao LivroCaixa
        string registro = $"|  {dataRecibo}  |  Valor: {valorReceita}  |  Descrição: {descricao} |";
        Registro.Add(registro);
    }

    public void RegistrarDespesa () {
        Console.WriteLine("Insira o valor da despesa no formato xx,yy:");
        bool valorEValido = Decimal.TryParse(Console.ReadLine(), out decimal valorDespesa);

        if (!valorEValido) {
            Console.WriteLine("Valor inválido!");
            Console.WriteLine("Utilize o formato xx,yy");
            RegistrarOutraReceita();
        }
        
        // Registra a alteração dos valores
        SubtrairValor (valorDespesa);

        // Registra o horário da despesa
        DateTime dataRecibo = DateTime.Now;

        // Recebe a descrição
        Console.WriteLine("\nInsira a descrição da despesa:");
        string descricao = Console.ReadLine();

        // Adiciona registro ao LivroCaixa
        string registro = $"|  {dataRecibo}  |  Valor: {-valorDespesa}  |  Descrição: {descricao} |";
        Registro.Add(registro);
    }

    public void Exibir () {
        if (Registro.Count <= 1) {
            Console.WriteLine("\nAinda não há registros!");
        } else {
            foreach (var registro in Registro) {
                Console.WriteLine(registro);
            }
        }

        Console.WriteLine($"\nReceitas totais: {TotalReceitas}");
        Console.WriteLine($"Despesas totais: {TotalDespesas}");
        Console.WriteLine($"\nValor em caixa: {ValorEmCaixa}");
    }
}