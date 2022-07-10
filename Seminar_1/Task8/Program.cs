// Домашнее задание:
// №8 Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N.
Console.Clear();

Console.Write("Введите число: ");
string? inputLine = Console.ReadLine();
if (inputLine != null)
{
    try
    {
        int inputNumber = int.Parse(inputLine);

        // вариант через простой вывод чисел, кратных 2
        string lineOutput = "";
        int honest = 2;
        Console.WriteLine("Вариант через простой вывод чисел, кратных 2:");
        while (honest <= inputNumber)
        {
            lineOutput = lineOutput + honest + ", ";
            honest += 2;
        }
        // убираем лишнюю запятую и пробел в конце итоговой строки
        string lineOutputClear = lineOutput.Remove(lineOutput.Length - 2, 2);

        Console.WriteLine(lineOutputClear);

        // вариант через накопление в массиве и последующий сбор строки
        lineOutput = "";
        honest = 2;
        Console.WriteLine("Вариант через накопление в массиве и последующий сбор строки:");
        // массив неизвестной длины -->>> коллекция
        List<int> evenNumbersArray = new List<int>();

        // копим все значения в коллекции evenNumbersArray
        while (honest <= inputNumber)
        {
            evenNumbersArray.Add(honest);
            honest += 2;
        }

        // String.Join сцепляет элементы указанного массива или элементы коллекции,
        // помещая между ними заданный разделитель.
        lineOutput = String.Join(", ", evenNumbersArray);
        Console.WriteLine(lineOutput);

    }
    catch
    {
        // вывод сообщения об ошибке
        Console.WriteLine("Не корректный ввод!!!");
    }
}
