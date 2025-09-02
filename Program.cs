using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("===== BEM-VINDO AO ASSISTENTE =====");
            Console.WriteLine("1 - Descobrir informações sobre uma data");
            Console.WriteLine("2 - Calcular desconto do INSS no salário");
            Console.WriteLine("0 - Sair do programa");
            Console.Write("Digite o número da opção desejada: ");
            
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    DetalharData();
                    break;
                case 2:
                    CalcularDescontoINSS();
                    break;
                case 0:
                    Console.WriteLine("Obrigado por usar o programa! Até logo!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine();
        } while (opcao != 0);
    }

    static void DetalharData()
    {
        Console.Write("Digite uma data (dd/mm/aaaa): ");
        DateTime data = DateTime.Parse(Console.ReadLine());

        string diaSemana = data.ToString("dddd", new CultureInfo("pt-BR"));
  
        string mesExtenso = data.ToString("MMMM", new CultureInfo("pt-BR"));

        Console.WriteLine($"Dia da semana: {diaSemana}");
        Console.WriteLine($"Mês: {mesExtenso}");

        if (data.DayOfWeek == DayOfWeek.Sunday)
        {
            string horaAtual = DateTime.Now.ToString("HH:mm");
            Console.WriteLine($"Você escolheu um domingo! Hora atual: {horaAtual}");
        }
    }
    static void CalcularDescontoINSS()
    {
        Console.Write("Digite o valor do salário (em R$): ");
        decimal salario = decimal.Parse(Console.ReadLine());

        decimal desconto = 0;

        if (salario <= 1212.00m)
        {
            desconto = salario * 0.075m;
        }
        else if (salario <= 2427.35m)
        {
            desconto = (1212.00m * 0.075m) +
                       ((salario - 1212.00m) * 0.09m);
        }
        else if (salario <= 3641.03m)
        {
            desconto = (1212.00m * 0.075m) +
                       ((2427.35m - 1212.00m) * 0.09m) +
                       ((salario - 2427.35m) * 0.12m);
        }
        else if (salario <= 7087.22m)
        {
            desconto = (1212.00m * 0.075m) +
                       ((2427.35m - 1212.00m) * 0.09m) +
                       ((3641.03m - 2427.35m) * 0.12m) +
                       ((salario - 3641.03m) * 0.14m);
        }
        else
        {
            desconto = (1212.00m * 0.075m) +
                       ((2427.35m - 1212.00m) * 0.09m) +
                       ((3641.03m - 2427.35m) * 0.12m) +
                       ((7087.22m - 3641.03m) * 0.14m);
        }

        decimal salarioLiquido = salario - desconto;

        Console.WriteLine($"Valor do desconto do INSS: R$ {desconto:F2}");
        Console.WriteLine($"Salário após desconto: R$ {salarioLiquido:F2}");
    }
}
