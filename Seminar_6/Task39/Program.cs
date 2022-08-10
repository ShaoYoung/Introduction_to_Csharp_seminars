// Задача №39
// Напишите программу, которая перевернёт одномерный массив (последний элемент будет на первом месте, а первый - на последнем и т.д.)
// Например:
// [1 2 3 4 5] -> [5 4 3 2 1] [6 7 3 6] -> [6 3 7 6] 
//Комментарий: эту задачу можно решить 2 способами: 
//1) менять числа местами в исходном массиве; 2) создать новый массив и в него записать перевёрнутый исходный массив по элементам.

//заполнение массива натуральных чисел от -1000 до 1000
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

//решение через новый массив
int[] ReversNewArray(int[] array)
{
    int[] newArray = new int[array.Length];
    for (int i = 0; i < array.Length; i++)
    {
        newArray[array.Length - 1 - i] = array[i];
    }
    return newArray;
}

//решение через обмен элементов внутри существующего массива
int[] ReverseSwapArray(int[] array)
{
    int length = array.Length;
    int buf;
    for (int i = 0; i < length / 2; i++)
    {
        buf = array[i];
        array[i] = array[length - i - 1];
        array[length - i - 1] = buf;
    }
    return array;
}

Console.Clear();

int[] testArray = FillArray(13);
PrintArray(testArray);
int[] reversedArray = ReversNewArray(testArray);
PrintArray(reversedArray);
reversedArray = ReverseSwapArray(testArray);
PrintArray(reversedArray);



//LINQ - Language Integrated Query — проект Microsoft по добавлению синтаксиса языка запросов.
//LINQ предоставляет возможности выполнения запросов на уровне языка и API функции высшего порядка в C# и Visual Basic для написания выразительного декларативного кода.
