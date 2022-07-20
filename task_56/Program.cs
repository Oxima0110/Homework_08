// Задайте прямоугольный двумерный массив. Напишите программу, которая будет
// находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки 
// с наименьшей суммой элементов: 1 строка

Console.Clear();

Console.WriteLine("Введите размер двухмерного массива через пробел ");
int[] size = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

int[,] CreateMatrixRndInt(int m, int n, int min, int max)
{
    int[,] arr = new int[m, n];
    Random rnd = new Random();

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = rnd.Next(min, max + 1);
        }
    }
    return arr;
}

void PrintMatrix(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (j == 0) Console.Write("|");
            if (j < arr.GetLength(1) - 1) Console.Write($"{arr[i, j],3}| ");
            else Console.Write($"{arr[i, j],3} |");
        }
        Console.WriteLine();
    }
}

int[] SumArray(int[,] arr)
{
    int[] array = new int[arr.GetLength(0)];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        array[i] = 0;
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            array[i] = array[i] + arr[i, j];
        }
    }
    return array;
}

void PrintArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine($"{arr[i]}  ");
    }
}

int SumMin(int[] arr)
{
    int min = arr[0];
    int index = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] < min)
        {
            min = arr[i];
            index = i;
        }
    }
    return index;
}

int[,] matrix = CreateMatrixRndInt(size[0], size[1], 1, 10);
PrintMatrix(matrix);
Console.WriteLine();
int[] sumArr = SumArray(matrix);
PrintArray(sumArr);
int result = SumMin(sumArr);
Console.WriteLine();
Console.WriteLine($"{result + 1} строка");