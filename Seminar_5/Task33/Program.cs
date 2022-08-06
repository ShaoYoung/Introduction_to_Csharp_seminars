// Задача №33
// Задайте массив. Напишите программу, которая определяет, присутствует ли заданное число в массиве.
// Например:
// 4; массив [6, 7, 19, 345, 3] -> нет
// -3; массив [6, 7, 19, 345, 3] -> да


//заполнение массива заданного размера
int[] FillArray(int lengthArray)
{
    System.Random numberSintezator = new Random();
    int[] array = new int[lengthArray];
    for (byte i = 0; i < lengthArray; i++)
        array[i] = numberSintezator.Next(0, 100);
    return array;
}


//поиск элемента в массиве
bool FindInArray(int[] array, int number)
{
    foreach (int element in array)
    {
        if (element == number)
            return true;
    }
    return false;
}

void PrintArray(int[] array)
{
    Console.WriteLine($"[{string.Join(",", array)}]");
}


Console.Clear();

int[] array = FillArray(10);
PrintArray(array);

Console.Write("Введите число, которое будем искать в массиве: ");
int number = int.Parse(Console.ReadLine());

if (FindInArray(array, Math.Abs(number)))
    Console.WriteLine("Да, оно присутствует в массиве.");
else
    Console.WriteLine("Нет, его нет в массиве.");