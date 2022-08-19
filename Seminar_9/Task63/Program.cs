// Задача 63
// Задайте N
// Выведите натуральные числа от 1 до N

Console.Clear();

int ReadData()
{
    Console.WriteLine("Задайте число: ");
    return int.Parse(Console.ReadLine());
}

int NaturalNumberPrinter(int num)
{
    if (num == 2) return 1;
    else
    {
        // num--;
        Console.WriteLine(num);
        num--;
        Console.Write(NaturalNumberPrinter(num) + " ");
    }
    return num;
}

int inputNumber = ReadData();
NaturalNumberPrinter(inputNumber+2);
