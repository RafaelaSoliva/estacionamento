using Models;

Console.Clear();

Console.WriteLine("Bem vindo ao gerente de estacionamento!\n");

Estacionamento estacionamento = new Estacionamento();

Console.WriteLine("Pressione Enter para continuar");
Console.ReadLine();
Console.Clear();

bool isRunning = true;

do {
    int acao = Menu();

    switch (acao) {
        case 1: {
            Console.Clear();
            estacionamento.ExibirVeiculosEstacionados();
            Console.WriteLine("\nPressione Enter para voltar");
            Console.ReadLine();
            Console.Clear();
            break;
            }
        case 2: {
            Console.Clear();
            estacionamento.AdicionarVeiculo(); 
            Console.WriteLine("\nPressione Enter para voltar");
            Console.ReadLine();
            Console.Clear();
            break;
        }
        case 3: {
            Console.Clear();
            estacionamento.RemoverVeiculo();
            Console.WriteLine("\nPressione Enter para voltar");
            Console.ReadLine();
            Console.Clear();
            break;
        }
        case 4: {
            Console.Clear();
            estacionamento.RegistrarReceita();
            Console.WriteLine("\nPressione Enter para voltar");
            Console.ReadLine();
            Console.Clear();
            break;
        }
        case 5: {
            Console.Clear();
            estacionamento.RegistrarDespesa();
            Console.WriteLine("\nPressione Enter para voltar");
            Console.ReadLine();
            Console.Clear();
            break;
        }
         case 6: {
            Console.Clear();
            estacionamento.ExibirLivroCaixa();
            Console.WriteLine("\nPressione Enter para voltar");
            Console.ReadLine();
            Console.Clear();
            break;
        }
        case 7: isRunning = false; break;
    }
    
} while (isRunning);


int Menu () {
    Console.WriteLine("\nSelecione uma ação:");
    Console.WriteLine("\nControle de veículos:");
    Console.WriteLine("1 - Listar veículos estacionados");
    Console.WriteLine("2 - Registrar veículo");
    Console.WriteLine("3 - Liberar veículo");
    Console.WriteLine("\nControle de caixa: ");
    Console.WriteLine("4 - Registrar receita");
    Console.WriteLine("5 - Registrar despesa");
    Console.WriteLine("6 - Exibir livro caixa");
    Console.WriteLine("\nENCERRAR - DIGITE 7");

    return SelecionarAcao();
}

int SelecionarAcao () {
    Console.WriteLine("\nDigite o número da ação desejada:");
    string entradaUsuario = Console.ReadLine();
    bool sucessoChar = Char.TryParse(entradaUsuario, out char digitoAcaoChar);
    string digitoAcaoString = digitoAcaoChar.ToString();
    bool sucessoInt = int.TryParse(digitoAcaoString, out int digitoAcaoInt);

    if (!sucessoChar || !sucessoInt || digitoAcaoInt < 1 || digitoAcaoInt > 7) {
        Console.WriteLine("\nAção inválida!");
        Console.WriteLine("Digite um número de 1 a 7");
        Menu();
        SelecionarAcao();
    }

    return digitoAcaoInt;
}