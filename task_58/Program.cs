// Задача 58: Задайте две матрицы. Напишите программу, которая будет
// находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

Console.Clear();

Console.WriteLine("Введите размер первого двухмерного массива через пробел ");
int[] sizeOne = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
Console.WriteLine("Введите размер второго двухмерного массива через пробел ");
int[] sizeTwo = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

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

int[,] Multiplication(int[,] arrOne, int[,] arrTwo)
{
    int[,] array = new int[arrOne.GetLength(0), arrTwo.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < arrOne.GetLength(1); k++)
            {
                array[i, j] = array[i, j] + arrOne[i, k] * arrTwo[k, j];
            }
        }
    }
    return array;
}

int[,] matrixOne = CreateMatrixRndInt(sizeOne[0], sizeOne[1], 1, 10);
PrintMatrix(matrixOne);
Console.WriteLine();
int[,] matrixTwo = CreateMatrixRndInt(sizeTwo[0], sizeTwo[1], 1, 10);
PrintMatrix(matrixTwo);
Console.WriteLine();
int[,] resultMatrix = Multiplication(matrixOne, matrixTwo);
PrintMatrix(resultMatrix);