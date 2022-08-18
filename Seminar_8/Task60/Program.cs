// Задача 60. Домашнее задание
// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// массив размером 2 x 2 x 2
// 12(0,0,0) 22(0,0,1)
// 45(1,0,0) 53(1,0,1)
//
//проверка на неповторяемость
//List<int> number
//добавить новый элемент рандомом и проверить
//if(number.contain), тогда пропускаем в массив

//заполнение трёхмерного массива (куба) неповторяющихся натуральных чисел (через for)
int[,,] FillCube(int row, int col, int depth)
{
    System.Random numberSyntezator = new System.Random();
    int[,,] outCube = new int[row, col, depth];
    //список уникальных рандом-чисел
    List<int> uniqueNumbers = new List<int>();
    int temp = 0;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            for (int k = 0; k < depth; k++)
            {
                bool entry = true;
                //проверка на входимость очередного рандом-числа в список
                while (entry)
                {
                    temp = numberSyntezator.Next(0, 100);
                    if (!uniqueNumbers.Contains(temp))
                    {
                        uniqueNumbers.Add(temp);
                        entry = false;
                    }
                }
                outCube[i, j, k] = temp;
                //печать каждого элемента (проверка на уникальность)
                //Console.WriteLine(temp);
            }
        }
    }
    return outCube;
}

//построчная печать трёхмерного массива (куба) с выводом индексов каждого элемента
void PrintCube(int[,,] cube)
{
    //GetLength(0) - кол-во строк, GetLength(1) - кол-во столбцов. Для двумерного массива. Далее GetLength(2) и т.д.
    for (int i = 0; i < cube.GetLength(0); i++)
    {
        for (int j = 0; j < cube.GetLength(1); j++)
        {
            for (int k = 0; k < cube.GetLength(2); k++)
            {
                Console.Write($"{cube[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
}

Console.Clear();
int[,,] cube = FillCube(2, 2, 2);
PrintCube(cube);

