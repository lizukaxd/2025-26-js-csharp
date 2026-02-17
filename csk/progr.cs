//1
Console.Write("Mennyi Fibonacci számot szeretnél?: ");
int fibszam = int.Parse(Console.ReadLine());

int fib1 = 0, fib2 = 1;

for (int i = 0; i < fibszam; i++)
{
    Console.Write(fib1 + " ");
    int kovfib = fib1 + fib2;
    fib1 = fib2;
    fib2 = kovfib;
}

//2

Console.Write(" * "); 
for (int oszlop = 1; oszlop <= 10; oszlop++)
{
    Console.Write($"{oszlop,3}");
}
Console.WriteLine();
Console.WriteLine(new string('-', 34));
for (int sor = 1; sor <= 10; sor++)
{
    Console.Write($"{sor,2} |");
    for (int oszlop = 1; oszlop <= 10; oszlop++)
    {
        Console.Write($"{sor * oszlop,3}");
    }
    Console.WriteLine();
}





