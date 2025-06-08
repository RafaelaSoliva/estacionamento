using Models;

bool isRunning = true;
Estacionamento estacionamento = IniciarSistema();

while (isRunning) {
    Console.Clear();
    Console.WriteLine("Estado:");
    Console.WriteLine(estacionamento.ObterStatus());

    Console.WriteLine("\nEstacionamento:");
    
    if (estacionamento.CarrosEstacionados.Count == 0 && estacionamento.MotosEstacionadas.Count == 0) {
        Console.WriteLine("\nNão há veículos registrados.");
    } else {
        Console.WriteLine("\n1 - Listar Veículos");
    }
    
    if (estacionamento.CarrosEstacionados.Count == estacionamento.CapacidadeParaCarros) {
        Console.WriteLine("Estacionamento para carros lotado!");
    } else {
        Console.WriteLine("2 - Estacionar Carro");
    }

    if (estacionamento.MotosEstacionadas.Count == estacionamento.CapacidadeParaMotos) {
        Console.WriteLine("Estacionamento para motos lotado!");
    } else {
        Console.WriteLine("3 - Estacionar Moto");
    }
    
    if (estacionamento.CarrosEstacionados.Count == 0) {
        Console.WriteLine("Não há carros registrados.");
    } else {
        Console.WriteLine("4 - Liberar Carro");
    }

    if (estacionamento.MotosEstacionadas.Count == 0) {
        Console.WriteLine("Não há motos registradas.");
    } else {
        Console.WriteLine("5 - Liberar Moto\n");
    }

    Console.WriteLine("\nRegistro do caixa:");

    Console.WriteLine("\n6 - Registrar Receita");
    Console.WriteLine("7 - Registrar Despesa");
    Console.WriteLine("8 - Exibir Registros do Caixa");

    Console.WriteLine("\nEncerrar Programa:");

    Console.WriteLine("\n9 - Encerrar (Os dados serão perdidos).\n");

    string entradaUsuario = Console.ReadLine();


    switch (entradaUsuario) {
        case "1": {
            if (estacionamento.CarrosEstacionados.Count == 0 && estacionamento.MotosEstacionadas.Count == 0) {
                Console.WriteLine("\nNenhum veículo registrado.");
            } else if (estacionamento.CarrosEstacionados.Count == 0) {
                Console.WriteLine("\nNão há carros registrados.");
            } else if (estacionamento.MotosEstacionadas.Count == 0) {
                Console.WriteLine("\nNão há motos registradas.");
            } 
            
            if (estacionamento.CarrosEstacionados.Count > 0) {
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine("Carros:");
                Console.WriteLine("--------------------------------------------------");

                foreach (var veiculo in estacionamento.CarrosEstacionados) {
                    Console.WriteLine($"Placa: {veiculo.Placa}  |  Cor: {veiculo.Cor}  |  Tempo de estacionamento: {veiculo.ObterHorasEstacionadas()}  |  Valor Parcial: {estacionamento.CalcularValorCarro(veiculo.Placa)}");
                }
            }

            if (estacionamento.MotosEstacionadas.Count > 0) {
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine("Motos:");
                Console.WriteLine("--------------------------------------------------");

                foreach (var veiculo in estacionamento.MotosEstacionadas) {
                    Console.WriteLine($"Placa: {veiculo.Placa}  |  Cor: {veiculo.Cor}  |  Tempo de estacionamento: {veiculo.ObterHorasEstacionadas()}  |  Valor Parcial: {estacionamento.CalcularValorMoto(veiculo.Placa)}");
                }
            }
            
            Console.WriteLine("\nPressione Enter para voltar..");
            Console.ReadLine();
        } break;

        case "2": {
            if (estacionamento.CarrosEstacionados.Count == estacionamento.CapacidadeParaCarros) {
                Console.WriteLine("\nEstacionamento para carros lotado!");
                Console.WriteLine($"\nPressione Enter para continuar..");
                Console.ReadLine();
            } else {
                Console.WriteLine("\nPlaca:");
                string placa = Console.ReadLine().ToUpper();
                Console.WriteLine("Cor:");
                string cor = Console.ReadLine().ToUpper();

                try {
                    estacionamento.EstacionarCarro(cor, placa);
                    Console.WriteLine($"\nCarro {cor}, placa {placa} registrado!");
                    Console.WriteLine($"\nPressione Enter para continuar..");
                } catch (ApplicationException error) {
                    Console.WriteLine(error.Message);
                    Console.WriteLine($"\nPressione Enter para continuar..");
                } finally {
                    Console.ReadLine();
                }
            }
        } break;
        
        case "3" : {
            if (estacionamento.MotosEstacionadas.Count == estacionamento.CapacidadeParaMotos) {
                Console.WriteLine("\nEstacionamento para motos lotado!");
                Console.WriteLine($"\nPressione Enter para continuar..");
                Console.ReadLine();
            } else {
                Console.WriteLine("\nPlaca:");
                string placa = Console.ReadLine().ToUpper();
                Console.WriteLine("Cor:");
                string cor = Console.ReadLine().ToUpper();

                try {
                    estacionamento.EstacionarMoto(cor, placa);
                    Console.WriteLine($"\nMoto {cor}, placa {placa} registrado!");
                    Console.WriteLine($"\nPressione Enter para continuar..");
                } catch (ApplicationException error) {
                    Console.WriteLine(error.Message);
                    Console.WriteLine($"\nPressione Enter para continuar..");
                } finally {
                    Console.ReadLine();
                }
            }
        } break;

        case "4": {
            if (estacionamento.CarrosEstacionados.Count == 0) {
                Console.WriteLine("\nNão há carros registrados.");
                Console.WriteLine($"\nPressione Enter para continuar..");
                Console.ReadLine();
            } else {
                Console.WriteLine("\nPlaca:");
                string placa = Console.ReadLine().ToUpper();

                try {
                    estacionamento.LiberarCarro(placa, out int horasEstacionadas, out decimal valorDevido);
                    Console.WriteLine($"\nTempo de estacionamento: {horasEstacionadas} horas");
                    Console.WriteLine($"Valor inicial: {estacionamento.ValorInicialCarro}");
                    Console.WriteLine($"Adicional por hora: {estacionamento.AdicionalPorHoraCarro}");
                    Console.WriteLine($"Valor total: {valorDevido}");
                    Console.WriteLine($"\nPressione Enter para confirmar o pagamento..");
                    Console.ReadLine();
                    Console.WriteLine($"Pagamento confirmado! Pressione Enter para continuar..");
                } catch (ApplicationException error) {
                    Console.WriteLine(error.Message);
                    Console.WriteLine($"\nPressione Enter para continuar..");
                } catch (Exception error) {
                    Console.WriteLine(error.Message);
                    Console.WriteLine($"\nPressione Enter para continuar..");
                } finally {
                    Console.ReadLine();
                }
            }
        } break;

        case "5": {
            if (estacionamento.MotosEstacionadas.Count == 0) {
                Console.WriteLine("\nNão há motos registradas.");
                Console.WriteLine($"\nPressione Enter para continuar..");
                Console.ReadLine();
            } else {
                Console.WriteLine("\nPlaca:");
                string placa = Console.ReadLine().ToUpper();

                try {
                    estacionamento.LiberarMoto(placa, out int horasEstacionadas, out decimal valorDevido);
                    Console.WriteLine($"\nTempo de estacionamento: {horasEstacionadas} horas");
                    Console.WriteLine($"Valor inicial: {estacionamento.ValorInicialMoto}");
                    Console.WriteLine($"Adicional por hora: {estacionamento.AdicionalPorHoraMoto}");
                    Console.WriteLine($"Valor total: {valorDevido}");
                    Console.WriteLine($"\nPressione Enter para confirmar o pagamento..");
                    Console.ReadLine();
                    Console.WriteLine($"Pagamento confirmado! Pressione Enter para continuar..");
                } catch (ApplicationException error) {
                    Console.WriteLine(error.Message);
                    Console.WriteLine("\nPressione Enter para continuar..");
                } finally {
                    Console.ReadLine();
                }
            }
        } break;

        case "6": {
            try {
                Console.WriteLine("\nInforme o valor (Formato xx,yy):");
                decimal valor = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Digite a descrição:");
                string descricao = Console.ReadLine();
                estacionamento.LivroCaixa.RegistrarReceita(valor, descricao);
            } catch (Exception error) {
                Console.WriteLine(error.Message);
            } finally {
                Console.WriteLine("\nPressione Enter para continuar..");
                Console.ReadLine();
            }
        } break;

        case "7": {
            try {
                Console.WriteLine("\nInforme o valor (Formato xx,yy):");
                decimal valor = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Digite a descrição:");
                string descricao = Console.ReadLine();
                estacionamento.LivroCaixa.RegistrarDespesa(valor, descricao);
            } catch (Exception error) {
                Console.WriteLine(error.Message);
            } finally {
                Console.WriteLine("\nPressione Enter para continuar..");
                Console.ReadLine();
            }
        } break;

        case "8": {
            estacionamento.LivroCaixa.Exibir();
            Console.WriteLine("\nPressione Enter para continuar..");
            Console.ReadLine();
        } break;

        case "9": {
            isRunning = false;
        } break;

        default: {
            Console.WriteLine("Entrada inválida!");
            Console.WriteLine("Informe um número de 1 a 4.");
            Console.WriteLine($"\nPressione Enter para continuar..");
            Console.ReadLine();
        } break;
    }
}


Estacionamento IniciarSistema () {
    Console.Clear();

    Console.WriteLine("Bem vindo ao gerente de estacionamento!");

    Console.WriteLine("\nInforme a capacidade para estacionar carros:");
    int.TryParse(Console.ReadLine(), out int capacidadeParaCarros);

    Console.WriteLine("\nInforme a capacidade para estacionar motos:");
    int.TryParse(Console.ReadLine(), out int capacidadeParaMotos);

    Console.WriteLine("\nInforme o valor inicial a cobrar por carro (Formato xx,yy):");
    decimal.TryParse(Console.ReadLine(), out decimal valorInicialCarro);

    Console.WriteLine("\nInforme o valor inicial a cobrar por moto (Formato xx,yy):");
    decimal.TryParse(Console.ReadLine(), out decimal valorInicialMoto);

    Console.WriteLine("\nInforme o valor adicional a cobrar por horas para carro (Formato xx,yy):");
    decimal.TryParse(Console.ReadLine(), out decimal adicionalPorHoraCarro);

    Console.WriteLine("\nInforme o valor adicional a cobrar por horas para moto (Formato xx,yy):");
    decimal.TryParse(Console.ReadLine(), out decimal adicionalPorHoraMoto);

    Console.WriteLine("\nSistema iniciado! Pressione Enter para continuar..");
    Console.ReadLine();
    Console.Clear();

    Estacionamento estacionamento = new Estacionamento(capacidadeParaCarros, capacidadeParaMotos,
                                                       valorInicialCarro, valorInicialMoto,
                                                       adicionalPorHoraCarro, adicionalPorHoraMoto);

    return estacionamento;
}