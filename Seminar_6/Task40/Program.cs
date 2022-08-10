//Задача №40
//Напишите программу, которая принимает на вход три числа и проверяет, может ли существовать треугольник с сторонами такой длины.

//Треугольник существует только тогда, когда сумма двух его сторон больше третьей.
//Требуется сравнить каждую сторону с суммой двух других.
//Если хотя бы в одном случае сторона окажется больше либо равна сумме двух других, то треугольника с такими сторонами не существует.

//проверка существования треугольника
bool CheckTriangle(int[] numbers)
{
    if ((numbers[0] + numbers[1] > numbers[2]) & (numbers[2] + numbers[0] > numbers[1]) & (numbers[1] + numbers[2] > numbers[0]))
        return true;
    else
        return false;
    //можно через тернарный оператор
    //bool answer = ((num1 + num2 > num3) && (num2 + num3 > num1) && (num1 + num3 > num2)) ? true : false;
}

Console.Clear();

Console.WriteLine("Введите три числа в формате Ч1 Ч2 Ч3");
try
{
    string[] stringNumbers = Console.ReadLine().Split(" ");
    int[] numbers = new int[3];
    for (int i = 0; i < stringNumbers.Length; i++)
        numbers[i] = int.Parse(stringNumbers[i]);

    if (CheckTriangle(numbers))
        Console.WriteLine("Треугольник существует!");
    else
        Console.WriteLine("Треугольника не существует!");
}
catch
{
    Console.WriteLine("Некорректный формат ввода");
}

//В будущем все вычисления оборачивать в методы


