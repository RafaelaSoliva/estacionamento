using System.Runtime.InteropServices;

namespace Estacionamento.Models;

public class Estacionamento {
    public List<Veiculo> CarrosEstacionados { get; set; }
    public List<Veiculo> MotosEstacionadas { get; set; }
    public int CapacidadeParaCarros { get; set; }
    public int CapacidadeParaMotos { get; set; }
    public decimal ValorInicialCarro { get; set; }
    public decimal ValorInicialMoto { get; set; }
    public decimal AdicionalPorHoraCarro { get; set; }
    public decimal AdicionalPorHoraMoto { get; set; }

    public Estacionamento (int capacidadeParaCarros, int capacidadeParaMotos,
                          decimal valorInicialCarro, decimal valorInicialMoto,
                          decimal adicionalPorHoraCarro, decimal adicionalPorHoraMoto) {

        CapacidadeParaCarros = capacidadeParaCarros;
        CapacidadeParaMotos = capacidadeParaMotos;
        ValorInicialCarro = valorInicialCarro;
        ValorInicialMoto = valorInicialMoto;
        AdicionalPorHoraCarro = adicionalPorHoraCarro;
        AdicionalPorHoraMoto = adicionalPorHoraMoto;
        CarrosEstacionados = new List<Veiculo>(CapacidadeParaCarros);
        MotosEstacionadas = new List<Veiculo>(CapacidadeParaMotos);
    }

    public string ObterStatus () {
        return "Carros: " + CarrosEstacionados.Count + "/" + CapacidadeParaCarros +
               "\nMotos: " + MotosEstacionadas.Count + "/" + CapacidadeParaMotos;
    }

    public bool TemEspacoParaCarro () {
        return CarrosEstacionados.Count < CapacidadeParaCarros;
    }

    public bool TemEspacoParaMoto () {
        return MotosEstacionadas.Count < CapacidadeParaMotos;
    }

    private bool CarroEstaEstacionado (string placa) {
        return CarrosEstacionados.Exists(carro => carro.Placa == placa.ToUpper());
    }

    private bool MotoEstaEstacionada (string placa) {
        return MotosEstacionadas.Exists(moto => moto.Placa == placa.ToUpper());
    }

    private int ObterIndexCarro (string placa) {
        return CarrosEstacionados.FindIndex(carro => carro.Placa == placa.ToUpper());
    }

    private int ObterIndexMoto (string placa) {
        return MotosEstacionadas.FindIndex(moto => moto.Placa == placa.ToUpper());
    }

    public void EstacionarCarro (string cor, string placa) {
        if (!TemEspacoParaCarro()) {
            throw new Exception("Não há vagas.");
        } else if (CarroEstaEstacionado(placa)) {
            throw new Exception("Placa já registrada.");
        } else {
            Veiculo veiculo = new Veiculo(1, cor, placa);
        }
    }

    public void EstacionarMoto (string cor, string placa) {
        if (!TemEspacoParaMoto()) {
            throw new Exception("Não há vagas.");
        } else if (MotoEstaEstacionada(placa)) {
            throw new Exception("Placa já registrada.");
        } else {
            Veiculo veiculo = new Veiculo(2, cor, placa);
        }
    }

    public decimal CalcularValorCarro (string placa) {
        if (!CarroEstaEstacionado(placa)) {
            throw new Exception("Veículo não registrado!");
        } else {
            int index = ObterIndexCarro(placa);
            int horasEstacionadas = CarrosEstacionados[index].ObterHorasEstacionadas();

            return horasEstacionadas * AdicionalPorHoraCarro + ValorInicialCarro;
        }
    }

    public decimal CalcularValorMoto (string placa) {
        if (!MotoEstaEstacionada(placa)) {
            throw new Exception("Veículo não registrado!");
        } else {
            int index = ObterIndexMoto(placa);
            int horasEstacionadas = MotosEstacionadas[index].ObterHorasEstacionadas();

            return horasEstacionadas * AdicionalPorHoraMoto + ValorInicialMoto;
        }
    }

    public bool RemoverCarro (string placa) {
        if (!CarroEstaEstacionado(placa)) {
            throw new Exception("Veículo não registrado!");
        } else {
            int index = ObterIndexCarro(placa);
            CarrosEstacionados.Remove(CarrosEstacionados[index]);
            return true;
        }
    }

    public bool RemoverMoto (string placa) {
        if (!MotoEstaEstacionada(placa)) {
            throw new Exception("Veículo não registrado!");
        } else {
            int index = ObterIndexMoto(placa);
            MotosEstacionadas.Remove(MotosEstacionadas[index]);
            return true;
        }
    }
}