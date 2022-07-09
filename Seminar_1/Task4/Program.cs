//Домашнее задание:
//№4 Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел.

Console.Clear();
Console.Write("Введите первое число: ");
string? inputFirst = Console.ReadLine();
Console.Write("Введите второе число: ");
string? inputSecond = Console.ReadLine();
Console.Write("Введите третье число: ");
string? inputThird = Console.ReadLine();

//можно сразу преобразовывать строку в int, только без проверки на null
//int numberFourth = int.Parse(Console.ReadLine());

if (inputFirst != null && inputSecond != null && inputThird != null)
{
    int inputNumberOne = int.Parse(inputFirst);
    int inputNumberTwo = int.Parse(inputSecond);
    int inputNumberThree = int.Parse(inputThird);
    int max = inputNumberOne;
    if (inputNumberTwo > max) max = inputNumberTwo;
    if (inputNumberThree > max) max = inputNumberThree;
    Console.Write(max);
}