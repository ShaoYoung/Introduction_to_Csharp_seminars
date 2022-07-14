//Задача №11
//Напишите программу, которая выводит случайное трёхзначное число и удаляет вторую цифру этого числа.

//вариант 1 (через массив символов)
void variant1(System.Random numberSintezator)
{
    char[] digits = numberSintezator.Next(100, 1000).ToString().ToCharArray();
    Console.Write("Первый вариант (через массив символов): ");
    Console.WriteLine(digits);
    //для "склеивания" символов сначала преобразуем их в строки
    string twoDigits = digits[0].ToString() + digits[2].ToString();
    Console.WriteLine(twoDigits);
}

// вариант 2 (через поразрядное деление)
void variant2(System.Random numberSintezator)
{
    int digit = numberSintezator.Next(100, 1000);
    Console.Write("Второй вариант (через поразрядное деление): ");
    Console.WriteLine(digit);
    int numOne = digit / 100;
    int numTwo = digit % 10;
    string twoDigits = numOne.ToString() + numTwo.ToString();
    Console.WriteLine(twoDigits);
}

Console.Clear();
//создание объекта
System.Random numberSintezator = new Random();

variant1(numberSintezator);
Console.WriteLine();

variant2(numberSintezator);
Console.WriteLine();
