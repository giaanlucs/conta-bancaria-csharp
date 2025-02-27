using System;

class ContaBancaria
{
    private string Titular;
    private decimal Saldo;

    public ContaBancaria(string titular, decimal saldoInicial)
    {
        Titular = titular;
        Saldo = saldoInicial;
    }

    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine("Depósito de R$" + valor.ToString("F2") + " realizado com sucesso.");
        }
        else
        {
            Console.WriteLine("O valor do depósito deve ser positivo e maior que zero.");
        }
    }

    public bool Sacar(decimal valor)
    {
        if (valor > 0 && valor <= Saldo)
        {
            Saldo -= valor;
            Console.WriteLine("Saque de R$" + valor.ToString("F2") + " realizado com sucesso.");
            return true;
        }
        else
        {
            Console.WriteLine("Saque inválido! Saldo insuficiente ou valor negativo.");
            return false;
        }
    }

    public void ExibirSaldo()
    {
        Console.WriteLine("Titular: " + Titular);
        Console.WriteLine("Saldo atual: R$" + Saldo.ToString("F2"));
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Informe o nome do titular da conta: ");
        string nome = Console.ReadLine();

        decimal saldoInicial;

        while (true)
        {
            Console.WriteLine("Informe o saldo inicial da conta: ");
            if (decimal.TryParse(Console.ReadLine(), out saldoInicial) && saldoInicial >= 0)
                break;
            Console.WriteLine("Saldo inválido. Insira um valor positivo.");
        }

        ContaBancaria conta = new ContaBancaria(nome, saldoInicial);

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção: ");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Consultar Saldo");
            Console.WriteLine("4 - Sair");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o valor para depósito: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal deposito))
                    {
                        conta.Depositar(deposito);
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case "2":
                    Console.Write("Digite o valor para saque: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal saque))
                    {
                        conta.Sacar(saque);
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case "3":
                    conta.ExibirSaldo();
                    break;

                case "4":
                    Console.WriteLine("Obrigado por usar nosso sistema!");
                    return;

                default:
                    Console.WriteLine("Opção Inválida. Tente novamente.");
                    break;
            }
        }
    }
}
