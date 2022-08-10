// Задача №45
// Напишите программу, которая будет создавать копию заданного одномерного массива с помощью поэлементного копирования.

//заполнение массива натуральных чисел
int[] FillArray(int lengthArray)
{
    System.Random numberSintezator = new Random();
    int[] array = new int[lengthArray];
    for (int i = 0; i < lengthArray; i++)
        array[i] = (int)numberSintezator.Next(-1000, 1001);
    return array;
}

//печать int массива
void PrintArray(int[] array)
{
    Console.WriteLine($"[{string.Join(" ", array)}]");
}

//
object[] CopyArrayStandartTool(params object[] inputArray)
{
    object[] buferArray = new object[inputArray.Length];
    // копирование массива
    inputArray.CopyTo(buferArray,0);
    return buferArray;
}

int[] testArray = FillArray(20);
PrintArray(testArray);

int[] outArray = CopyArrayStandartTool(testArray);
PrintArray(outArray);

// Андрей обещал УТОЧНИТЬ


