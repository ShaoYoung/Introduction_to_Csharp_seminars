// №34. Домашнее задание
// Задайте массив заполненный случайными положительными трёхзначными числами.
// Напишите программу, которая покажет количество чётных чисел в массиве.
// [345, 897, 568, 234] -> 2
// [845, 222, 367, 123 -> 1
// * Отсортировать массив методом пузырька
//отдельным методом и вывести его на печать

//заполнение массива размерностью lengthArray случайными положительными трёхзначными числами
int[] FillArray(int lengthArray)
{
    System.Random numberSintezator = new Random();
    int[] array = new int[lengthArray];
    for (int i = 0; i < lengthArray; i++)
        array[i] = numberSintezator.Next(100, 1000);
    return array;
}

//подсчёт количества чётных чисел в массиве
int FindHonestElements(int[] array)
{
    int count = 0;
    foreach (int element in array)
    {
        if (element % 2 == 0)
            count++;
    }
    return count;
}

//печать int массива
void PrintArray(int[] array)
{
    Console.WriteLine($"[{string.Join(",", array)}]");
}

//сортировка массива методом пузырька
int[] BubbleSort(int[] array)
{
    int temp;
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[i] > array[j])
            {
                temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
        }
    }
    return array;
}

Console.Clear();
int lengthArray = 10;
int[] array = FillArray(lengthArray);
PrintArray(array);
Console.WriteLine($"В этом массиве {FindHonestElements(array)} чётное(ых) число(ел).");

//задача со звёздочкой
Console.WriteLine("Массив, сортированный методом пузырька:");
PrintArray(BubbleSort(array));

