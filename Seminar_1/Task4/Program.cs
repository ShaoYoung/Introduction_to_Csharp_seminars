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
    try
    {
        // лобовое решение
        int inputNumberOne = int.Parse(inputFirst);
        int inputNumberTwo = int.Parse(inputSecond);
        int inputNumberThree = int.Parse(inputThird);
        int max = inputNumberOne;
        if (inputNumberTwo > max) max = inputNumberTwo;
        if (inputNumberThree > max) max = inputNumberThree;
        Console.WriteLine("По классике: " + max);

        // через Math.Max (в классе Max много методов, в т.ч. и Min)
        max = Math.Max(inputNumberOne, inputNumberTwo);
        max = Math.Max(max, inputNumberThree);
        Console.WriteLine("Через метод Math.Max: " + max);

        // через тернарный оператор. сначала проверяется условие (итог true/false), после знака ?
        // первым идёт значение при true, вторым при false 
        max = inputNumberOne > inputNumberTwo ? inputNumberOne : inputNumberTwo;
        max = max > inputNumberThree ? max : inputNumberThree;
        Console.WriteLine("Через тернарный оператор: " + max);
    }
    catch
    {
        // вывод сообщения об ошибке
        Console.WriteLine("Не корректный ввод!!!");

    }

}