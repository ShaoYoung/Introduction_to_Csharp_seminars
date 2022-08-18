// №38. Домашнее задание, версия 2.
// Задайте массив целых чисел в диапазоне от 0 до 100. Найдите разницу между максимальным и минимальным элементов массива.
// [3 7 22 2 78] -> 76
// [2 0,4 9 7,2 78] -> 77,6
// * Отсортируйте массив методом вставки и методом подсчета, а затем найдите
// разницу между первым и последним элементом

// *
//метод пузырька. оценить производительность.
//метод вставки. оценить производительность.
//метод подсчёта. оценить производительность.
//сравнить производительность трёх методов.

//заполнение массива натуральных чисел. Диапазон от 0 до 100.
byte[] FillArray(int lengthArray)
{
    System.Random numberSintezator = new Random();
    byte[] array = new byte[lengthArray];
    for (int i = 0; i < lengthArray; i++)
        array[i] = (byte)numberSintezator.Next(0, 101);
    return array;
}

//печать byte массива
void PrintArray(byte[] array)
{
    Console.WriteLine($"[{string.Join(" ", array)}]");
}

//поиск максимального элемента массива
byte FindMax(byte[] array)
{
    byte max = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] > max)
            max = array[i];
    }
    return max;
}

//поиск минимального элемента массива
byte FindMin(byte[] array)
{
    byte min = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] < min)
            min = array[i];
    }
    return min;
}

//сортировка массива методом пузырька
//сортировка пузырьком - это метод сортировки массивов и списков путем последовательного сравнения и обмена соседних элементов,
//если предшествующий оказывается больше последующего.
byte[] BubbleSort(byte[] array)
{
    byte temp;
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

//сортировка массива методом вставки
//суть в том что, на каждом шаге алгоритма берется один из элементов массива, находится позицию (согласно его значению) для вставки и вставляется
//массив из 1-го элемента считается отсортированным.
byte[] InsertionSort(byte[] array)
{
    byte key;
    int j;
    for (int i = 1; i < array.Length; i++)
    {
        j = i - 1;
        //очередной ключ массива
        key = array[i];
        //сдвигаем массив вправо, пока ключ больше текущего элемента и ещё не начало массива. освобождаем место под ключ
        while ((j >= 0) && (array[j] > key))
        {
            array[j + 1] = array[j];
            j -= 1;
        }
        //записываем ключ на своё (свободное) место в массиве
        array[j + 1] = key;
    }
    return array;
}

//сортировка массива методом подсчёта
//классический метод подсчёта работает только с ЦЕЛЫМИ числами НЕБОЛЬШОГО диапазона. Определяется количество вхождений числа в массив, затем массив
//перезаписывается в сортированном порядке с учётом кратности вхождения каждого числа
byte[] CountingSort(byte[] array)
{
    //массив кратности вхождений. размерность 101, т.к. известно, что сортируемый массив будет заполнен числами от 0 до 100
    byte[] countArray = new byte[101];
    //обнуление массива
    Array.Clear(countArray);
    //определение кратности вхождений каждого элемента в массив
    foreach (byte element in array)
        countArray[element]++;
    //счётчик элементов для сортированного массива
    byte k = 0;
    //перезапись массива с учётом кратности вхождения каждого числа
    for (byte i = 0; i < countArray.Length; i++)
    {
        for (int j = 0; j < countArray[i]; j++)
        {
            array[k] = i;
            k++;
        }
    }
    return array;
}

//поиск минимального элемента массива DateTime, возвращает номер минимального времени
byte FindMinTime(TimeSpan[] array)
{
    byte numberMin = 0;
    for (byte i = 1; i < array.Length; i++)
    {
        if (array[i] < array[numberMin])
            numberMin = i;
    }
    return numberMin;
}

Console.Clear();
int lengthArray = 30;
byte[] array = FillArray(lengthArray);
PrintArray(array);
byte max = FindMax(array);
Console.WriteLine("Максимальный элемент массива {0}", max);
byte min = FindMin(array);
Console.WriteLine("Минимальный элемент массива {0}", min);
Console.WriteLine("Разница между максимальным и минимальным элементов массива {0}", max - min);

//задача со звёздочкой
Console.WriteLine("*");
DateTime timeOper = DateTime.Now;
//массив времён выполнения сортировок
TimeSpan[] workingTime = new TimeSpan[3];
timeOper = DateTime.Now;
//сортированный массив
byte[] sortedArray = BubbleSort(array);
workingTime[0] = DateTime.Now - timeOper;
PrintArray(sortedArray);
Console.WriteLine($"Сортировка массива методом пузырька заняла {workingTime[0]}");
Console.WriteLine("Разница между первым и последним элементом {0}", sortedArray[sortedArray.Length - 1] - sortedArray[0]);

timeOper = DateTime.Now;
sortedArray = InsertionSort(array);
workingTime[1] = DateTime.Now - timeOper;
PrintArray(sortedArray);
Console.WriteLine($"Сортировка массива методом вставки заняла {workingTime[1]}");

timeOper = DateTime.Now;
sortedArray = CountingSort(array);
workingTime[2] = DateTime.Now - timeOper;
PrintArray(sortedArray);
Console.WriteLine($"Сортировка массива методом подсчёта заняла {workingTime[2]}");

//определение метода максимального быстродействия
switch (FindMinTime(workingTime))
{
    case 0:
        Console.WriteLine("Метод пузырька самый быстрый");
        break;
    case 1:
        Console.WriteLine("Метод вставки самый быстрый");
        break;
    case 2:
        Console.WriteLine("Метод подсчёта самый быстрый");
        break;
}




