// Задача №9
// Напишите программу, которая выводит случайное число из отрезка [10, 99] и показывает наибольшую цифру числа.

//Метод решения задачи. Вариант 1. Переменная - объект класса Random.
void variant1(System.Random numberSintezator)
{
    //используем метод объекта numberSintezator
    int number = numberSintezator.Next(10, 100);
    Console.WriteLine("Первый вариант: " + number);
    numberSintezator.Next(10, 100);
    Console.Write("Наибольшая цифра: ");
    int firstNumber = number / 10;
    int secondNumber = number % 10;
    if (firstNumber > secondNumber)
    {
        // WriteLine тоже метод
        Console.WriteLine(firstNumber);
    }
    else
    {
        Console.WriteLine(secondNumber);
    }
}

//Вариант 2. numberKirilla
void variant2()
{
    int number = new Random().Next(10, 100);
    Console.WriteLine("Второй вариант: " + number);
    //преобразование int в string
    string stringNum = number.ToString();
    Console.Write("Наибольшая цифра: ");
    //обращаемся к строке как к последовательности символов
    if (stringNum[0] > stringNum[1])
        Console.WriteLine(stringNum[0]);
    else
        Console.WriteLine(stringNum[1]);
}

//Вариант 3. метод.метод.метод
void variant3(System.Random numberSintezator)
{
    //генерация случайного числа -> преобразование в строку -> преобразование в массив символов digits
    char[] digits = numberSintezator.Next(10, 100).ToString().ToCharArray();
    Console.Write("Третий вариант: ");
    Console.WriteLine(digits);
    Console.Write("Наибольшая цифра: ");
    //вариант преобразования char в int через ASCII
    int firstNumber = digits[0] - '0';
    int secondNumber = digits[1] - '0';
    if (firstNumber > secondNumber)
    {
        Console.WriteLine(firstNumber);
    }
    else
    {
        Console.WriteLine(secondNumber);
    }
}

Console.Clear();

//создание объекта класса Random
System.Random numberSintezator = new Random();

variant1(numberSintezator);
Console.WriteLine();

variant2();
Console.WriteLine();

variant3(numberSintezator);
Console.WriteLine();

