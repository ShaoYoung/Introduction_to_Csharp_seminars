// №38 Домашнее задание
// Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
// [3 7 22 2 78] -> 76
// [2 0,4 9 7,2 78] -> 77,6
// * Отсортируйте массив методом вставки и методом подсчета, а затем найдите
// разницу между первым и последним элементом

//Вещественное число - число с плавающей запятой. double
// *
//метод пузырька. оценить производительность.
//метод вставки. оценить производительность.
//метод подсчёта. оценить производительность.
//сравнить производительность трёх методов.

//заполнение массива вещественных чисел (double) размерностью lengthArray случайными числами. Диапазон от 0 до 1000, 1 знак после запятой.
double[] FillArray(int lengthArray)
{
    System.Random numberSintezator = new Random();
    double[] array = new double[lengthArray];
    for (int i = 0; i < lengthArray; i++)
        array[i] = Math.Round(numberSintezator.NextDouble() * 1000, 1);
    return array;
}

//печать double массива
void PrintArray(double[] array)
{
    Console.WriteLine($"[{string.Join(" ", array)}]");
}

//поиск максимального элемента массива
double FindMax(double[] array)
{
    double max = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] > max)
            max = array[i];
    }
    return max;
}

//поиск минимального элемента массива
double FindMin(double[] array)
{
    double min = array[0];
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
double[] BubbleSort(double[] array)
{
    double temp;
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
double[] InsertionSort(double[] array)
{
    double key;
    int j;
    for (int i = 1; i < array.Length; i++)
    {
        j = i - 1;
        //очередной ключ массива
        key = array[i];
        //сдвигаем массив вправо, пока ключ больше текущего элемента и ещё не начало массива. освобождаем место под ключ
        while ((array[j] > key) & (j >= 0))
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
//перезаписывается в сортированном порядке согласно кратности вхождения каждого числа
//с вещественными числами данный метод практически не применим, т.к. кол-во одинаковых чисел типа double в массиве -> 0.
//для вещественных чисел метод заключается в подсчёте количества элементов массива (k), меньших чем итерируемый элемент, после чего элемент записывается во
//вспомогательный массив с номером (k+1)/ т.е. для каждого элемента ищется его номер в отсортированном массиве
//выдаст некорректный результат, если в массиве окажутся одинаковые элементы
double[] CountingSort(double[] array)
{
    //массив порядковых номеров сортированного массива
    int[] count = new int[array.Length];
    //обнуление массива
    Array.Clear(count);
    //вспомогательный массив
    double[] sortedArray = new double[array.Length];
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < array.Length; j++)
        {
            //если итерируемый элемент больше элемента массива, его счётчик номера инкрементируется
            if (array[i] > array[j])
                count[i]++;
        }
    }
    int k = 0;
    //заполнение сортированного массива в соответствии с порядковым номером
    foreach (int item in count)
    {
        sortedArray[item] = array[k];
        k++;
    }
    return sortedArray;
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
double[] array = FillArray(lengthArray);
PrintArray(array);
double max = FindMax(array);
Console.WriteLine("Максимальный элемент массива {0:0.#}", max);
double min = FindMin(array);
Console.WriteLine("Минимальный элемент массива {0:0.#}", min);
Console.WriteLine("Разница между максимальным и минимальным элементов массива {0:0.#}", max - min);

//задача со звёздочкой
Console.WriteLine("*");
DateTime timeOper = DateTime.Now;
//массив времён выполнения сортировок
TimeSpan[] workingTime = new TimeSpan[3];
timeOper = DateTime.Now;
//сортированный массив
double[] sortedArray = BubbleSort(array);
workingTime[0] = DateTime.Now - timeOper;
PrintArray(sortedArray);
Console.WriteLine($"Сортировка массива методом пузырька заняла {workingTime[0]}");
Console.WriteLine("Разница между первым и последним элементом {0:0.#}", sortedArray[sortedArray.Length - 1] - sortedArray[0]);

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



