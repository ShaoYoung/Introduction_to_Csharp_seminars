// №36 Домашнее задание
// Задайте одномерный массив, заполненный случайными числами. Найдите сумму
// элементов, стоящих на нечётных позициях (1,3,5 и т.д.)
// [3, 7, 23, 12] -> 19
// [3, 7, -2, 1] -> 8
// [-4, -6, 89, 6] -> 0
// * Найдите все пары в массиве и выведите пользователю

//итератор начинать с 1 +=2

//найти все пары (тройки и т.д.) одинаковых элементов в массиве и вывести их пользователю. можно отдельным массивом.

//заполнение массива размерностью lengthArray случайными числами. Для проверки диапазон рандомайзера задан от 0 до 99
int[] FillArray(int lengthArray)
{
    System.Random numberSintezator = new Random();
    int[] array = new int[lengthArray];
    for (int i = 0; i < lengthArray; i++)
        array[i] = numberSintezator.Next(0, 100);
    return array;
}

//печать int массива
void PrintArray(int[] array)
{
    Console.WriteLine($"[{string.Join(",", array)}]");
}

//подсчёт суммы элементов массива, стоящих на нечётных позициях
int SummOddPosition(int[] array)
{
    int summ = 0;
    for (int i = 1; i < array.Length; i += 2)
        summ += array[i];
    return summ;
}

//поиск пар (троек, четвёрок и т.д.) в массиве и печать результата. за один проход. 
void FindPairInArray(int[] array)
{
    //список чисел массива
    List<int> elementOfArray = new List<int>();
    //список количества вхождений в массив
    List<int> numberEntry = new List<int>();
    //подсчёт числа вхождений в массив. числа в список elementOfArray, кол-во вхождений каждого числа в список numberEntry
    for (int i = 0; i < array.Length; i++)
    {
        if (elementOfArray.Contains(array[i]))
        {
            int number = elementOfArray.IndexOf(array[i]);
            numberEntry[number]++;
        }
        else
        {
            elementOfArray.Add(array[i]);
            numberEntry.Add(1);
        }
    }
    //вывод результатов. Количеств вхождений каждой пары (тройки, четвёрки и т.д.) и массива повторяющихся чисел.
    string pairArray = "[";
    bool repeat = false;
    for (int i = 0; i < elementOfArray.Count; i++)
    {
        if (numberEntry[i] > 1)
        {
            Console.WriteLine($"Число {elementOfArray[i]} повторяется в массиве {numberEntry[i]} раз(а)");
            for (int j = 0; j < numberEntry[i]; j++)
                pairArray = pairArray + Convert.ToString(elementOfArray[i]) + ",";
            repeat = true;
        }
    }
    if (!repeat)
        Console.WriteLine("Повторяющихся чисел в этом массиве нет.");
    else
    {
        Console.WriteLine($"Массив повторяющихся чисел: {pairArray.Remove(pairArray.Length - 1, 1)}]");
    }
}


Console.Clear();
//размерность массива
int lengthArray = 30;
int[] array = FillArray(lengthArray);
PrintArray(array);
Console.WriteLine($"Сумма элементов массива, стоящих на нечётных позициях {SummOddPosition(array)}.");

//задача со звёздочкой
FindPairInArray(array);

