// Задача №35
// Задайте одномерный массив из 123 случайных чисел. Найдите количество элементов массива, значения которых лежат в отрезке [10,99].
// Например:
// Пример для массива из 5, а не 123 элементов. В своем решении сделайте для 123
// [5, 18, 123, 6, 2] -> 1
// [1, 2, 3, 6, 2] -> 0
// [10, 11, 12, 13, 14] -> 5


int[] FillArray(int lengthArray)
{
    System.Random numberSintezator = new Random();
    int[] array = new int[lengthArray];
    for (int i = 0; i < lengthArray; i++)
        //любое число
        array[i] = numberSintezator.Next();

    PrintArray(array);
    return array;
}

void PrintArray(int[] array)
{
    Console.WriteLine($"[{string.Join(",", array)}]");
}

//подсчёт числа элементов массива в диапазоне
int FindCountElements(int[] array, int downBorder, int topBorder)
{
    int count = 0;
    foreach (int element in array)
    {
        if ((element >= downBorder) & (element <= topBorder))
            count++;
    }
    return count;
}

Console.Clear();
int[] array = FillArray(123);
int downBorder = 10;
int topBorder = 99;
Console.WriteLine($"Количество элементов массива в диапазоне от {downBorder} до {topBorder}: {FindCountElements(array, downBorder, topBorder)}");



