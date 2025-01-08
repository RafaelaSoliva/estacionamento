using Models;

public class VeiculoTests
{
    Veiculo veiculo = new Veiculo("RAF2304", "Honda", "Vermelho");

    [Theory] // Testa o método CalcularValorAReceber
    [InlineData(20.0, 2.20, 20.0)]
    [InlineData(12.0, 2.20, 12.0)]
    public void CalculaValorAReceber(decimal precoInicial, decimal precoPorHora, decimal resultadoEsperado) {
        // Act
        var resultado = veiculo.CalcularValorAReceber(precoInicial, precoPorHora);

        // Assert
        Assert.Equal(resultado, resultadoEsperado);
    }
}