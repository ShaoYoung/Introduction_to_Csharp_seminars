// Задача №31
// Задайте массив из 12 элементов, заполненный случайными числами из промежутка [-9, 9].
// Найдите сумму отрицательных и положительных элементов массива.
// Например:
// Например, в массиве [3,9,-8,1,0,-7,2,-1,8,-3,-1,6] сумма положительных чисел равна 29, сумма отрицательных равна -20.

//заполнение массива
int[] FillArray()
{
    System.Random numberSintezator = new Random();
    byte numElem = 12;
    int[] array = new int[numElem];
    for (byte i = 0; i < numElem; i++)
        array[i] = numberSintezator.Next(-9, 9 + 1);
    return array;
}

//вычисление сумм положительных и отрицательных чисел в массиве и вывод их на печать
void Calculate(int[] array)
{
    int sumPol = 0;
    int sumOtr = 0;
    foreach (int element in array)
    {
        if (element > 0)
            sumPol += element;
        else
            sumOtr += element;
    }

    Console.WriteLine($"[{string.Join(",", array)}]");
    Console.WriteLine("Сумма положительных чисел " + sumPol);
    Console.WriteLine("Сумма отрицательных чисел " + sumOtr);
}



Console.Clear();

Calculate(FillArray());






