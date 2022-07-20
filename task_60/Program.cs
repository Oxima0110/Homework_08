// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

Console.Clear();

Console.WriteLine("Введите размер трехмерного массива через пробел ");
int[] size = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

int[] Number(int[] arr)
{
    int[] array = new int[arr[0] * arr[1] * arr[2]];
    Random rnd = new Random();
    array[0] = rnd.Next(10, 100);
    for (int i = 1; i < array.Length; i++)
    {
        int num = rnd.Next(10, 100);
        int j;
        for (j = 0; j < i; j++)
        {
            if (num == array[j])
            {
                num = rnd.Next(10, 100);
                j = 0;
            }
        }
        if (j == i)
        {
            array[i] = num;
        }
    }
    return array;
}

int[,,] FillMatrix(int[] arr, int[] array)
{
    int[,,] matrix = new int[arr[0], arr[1], arr[2]];
    int index = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                matrix[i, j, k] = array[index];
                index++;
            }
        }
    }
    return matrix;
}

void PrintMatrix(int[,,] arr)
{
    for (int k = 0; k < arr.GetLength(2); k++)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j, k]}({i},{j},{k})  ");
            }
            Console.WriteLine();
        }
    }
}


int[] num = Number(size);
int[,,] matrixResult = FillMatrix(size, num);
PrintMatrix(matrixResult);