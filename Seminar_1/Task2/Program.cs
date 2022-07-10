//Домашнее задание:
//№2 Напишите программу, которая на вход принимает два числа и выдаёт, какое число большее, а какое меньшее.

Console.Clear();
Console.Write("Введите первое число: ");
string? inputFirst = Console.ReadLine();
Console.Write("Введите второе число: ");
string? inputSecond = Console.ReadLine();

if ((inputFirst != null) && (inputSecond != null))
{
    // блок try содержит защищенный код, который может вызвать исключение
    try
    {
        // генерация нового исключения при помощи throw
        // if (inputFirst == "1")
        // {
        //     throw new Exception("Ты ввёл цифру 1");
        // }
        // парсим первое число
        int inputNumberOne = int.Parse(inputFirst);
        // парсим второе число
        int inputNumberTwo = int.Parse(inputSecond);
        // сравниваем два числа
        if (inputNumberOne > inputNumberTwo)
        {
            Console.Write("Первое число большее. max = " + inputNumberOne);
        }
        else if (inputNumberOne < inputNumberTwo)
        {
            Console.Write("Второе число большее. max = " + inputNumberTwo);
        }
        else
        {
            Console.Write("Числа равны");
        }
    }
    // catch - обратотка исключений. может использоваться без
    // аргументов для перехвата любого типа исключения. лучше использовать с аргументами для перехвата
    // конкретных исключений.

    // catch (Exception e)
    // {
    //     Console.WriteLine($"Ошибка: {e.Message}");
    // }

    catch
    {
        // вывод сообщения об ошибке
        Console.WriteLine("Не корректный ввод!!!");
    }
}