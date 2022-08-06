// Задача №32
// Напишите программу замену элементов массива: положительные элементы замените на
// соответствующие отрицательные, и наоборот.
// Пример:
// [-4, -8, 8, 2] -> [4, 8, -8, -2]

//заполнение массива заданного размера
int[] FillArray(int lengthArray)
{
    System.Random numberSintezator = new Random();
    int[] array = new int[lengthArray];
    for (byte i = 0; i < lengthArray; i++)
        array[i] = numberSintezator.Next(-9, 9 + 1);
    return array;
}

//замена элементов массива
int[] RotateArray(int[] array)
{
    int i = 0;
    foreach (int element in array)
    {
        array[i] = (-1) * element;
        //аналогичная запись через тильду ~
        //array[i] = ~element + 1;
        i++;
    }

    return array;
}


void PrintArray(int[] array)
{
    Console.WriteLine($"[{string.Join(",", array)}]");
}

Console.Clear();

Console.WriteLine("Введите размерность массива ");
int lengthArray = int.Parse(Console.ReadLine());
int[] array = FillArray(lengthArray);
PrintArray(array);

PrintArray(RotateArray(array));
