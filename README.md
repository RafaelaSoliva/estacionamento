### 🅿️ **Gerente de Estacionamento:**

Este projeto é um sistema de gerenciamento de estacionamento feito em C# para console. Ele permite a exibição do status, controle de vagas, registro de veículos (carros e motos), cálculo de valores, e controle de caixa.

##

### :hammer: **Funcionalidades:**

- **Controle de vagas:** Informa quando o estacionamento está lotado para carros ou motos.
- **Cadastro de veículos:** Permite registrar carros e motos, controlando a capacidade máxima de cada tipo.
- **Liberação de veículos:** Calcula o valor devido e remove o veículo do estacionamento.
- **Listagem de veículos:** Exibe todos os veículos estacionados, com placa, cor, tempo de permanência e valor parcial.
- **Controle financeiro:** Permite registrar automaticamente receitas ao liberar veículos além de registrar receitas e despesas manuais.
- **Exibição do caixa:** Mostra todos os registros financeiros do estacionamento.
- **Interface interativa:** Menu simples e intuitivo para operação via terminal.

##

### 📚 **Principais Classes:**

- **Estacionamento:**  
  Gerencia vagas, registro, liberação e cálculo de valores dos veículos.

- **Veiculo:**  
  Representa um veículo com placa, cor e controle de tempo de permanência.

- **LivroCaixa:**  
  Registra receitas e despesas, exibindo o histórico financeiro.

##

### ℹ️ **Observações:**

- Comparações de placas são feitas de forma case-insensitive para evitar duplicidade.
- O código utiliza boas práticas de C#, como tratamento de exceções e validação de entradas.
- O sistema não salva dados em disco; ao encerrar, todas as informações são perdidas.

##

### **Como usar:**

 <details><summary><strong> 1. Requisitos </strong></summary>

- [.NET 6.0 SDK ou superior](https://dotnet.microsoft.com/download)
- Windows, Linux ou MacOS

</details>


<details><summary><strong> 2. Clonando o repositório </strong></summary>

```sh
git clone https://github.com/seu-usuario/seu-repositorio.git
cd estacionamento
```

</details>


<details><summary><strong> 3. Executando o sistema </strong></summary>

No terminal, navegue até a pasta do projeto e execute:

```sh
dotnet run --project Estacionamento.Console
```

</details>


<details><summary><strong> 4. Fluxo do sistema </strong></summary>

1. **Configuração inicial:**  
   Informe a capacidade de carros e motos, valores iniciais e adicionais por hora.

2. **Menu principal:**  
   - Visualize o status do estacionamento.
   - Liste veículos estacionados.
   - Estacione ou libere carros e motos.
   - Registre receitas e despesas.
   - Exiba o histórico do caixa.
   - Encerre o sistema.

3. **Operações:**  
   Siga as instruções do menu digitando o número da opção desejada.

</details>


##

### Estrutura do Projeto

```
estacionamento/
│
├── Estacionamento.Console/
│   ├── Program.cs         // Interface principal do sistema
│   └── Models/
│       ├── Estacionamento.cs  // Lógica de controle do estacionamento
│       ├── Veiculo.cs         // Classe de veículos
│       └── LivroCaixa.cs      // Controle financeiro
│
└── README.md
```

##

##### [@RafaelaSoliva](https://github.com/RafaelaSoliva)
