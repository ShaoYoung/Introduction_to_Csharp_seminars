// Задача №37
// Найдите произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент, второй и предпоследний и т.д. Результат
// запишите в новом массиве.
// Например:
// [1 2 3 4 5] -> 5 8 3
// [6 7 3 6] -> 36 21
//размерность 123

//заполнение массива
int[] FillArray(int lengthArray)
{
    System.Random numberSintezator = new Random();
    int[] array = new int[lengthArray];
    for (int i = 0; i < lengthArray; i++)
        //любое число
        array[i] = numberSintezator.Next(1,10);

    PrintArray(array);
    return array;
}

//печать массива
void PrintArray(int[] array)
{
    Console.WriteLine($"[{string.Join(",", array)}]");
}


int[] CalculateTask(int[] inputArray)
{
    int[] resultArray = new int[inputArray.Length/2+1];
    int i=0;
    while(i<resultArray.Length)
    {
        resultArray[i] = inputArray[i] * inputArray[inputArray.Length-1-i];
        i++;
    }
    return resultArray;
}

Console.Clear();
int[] array = FillArray(5);
int[] resultArray = CalculateTask(array);
PrintArray(resultArray);
