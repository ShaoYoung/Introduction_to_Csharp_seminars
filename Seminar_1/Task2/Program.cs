//Домашнее задание:
//№2 Напишите программу, которая на вход принимает два числа и выдаёт, какое число большее, а какое меньшее.

Console.Clear();
Console.Write("Введите первое число: ");
string? inputFirst = Console.ReadLine();
Console.Write("Введите второе число: ");
string? inputSecond = Console.ReadLine();

if (inputFirst != null && inputSecond != null)
{
    int inputNumberOne = int.Parse(inputFirst);
    int inputNumberTwo = int.Parse(inputSecond);
    if (inputNumberOne > inputNumberTwo)
    {
        Console.Write("Первое число большее. max = " + inputNumberOne);
    }
    else if(inputNumberOne < inputNumberTwo)
    {
        Console.Write("Второе число большее. max = " + inputNumberTwo);
    }
    else
    {
        Console.Write("Числа равны");
    }
}