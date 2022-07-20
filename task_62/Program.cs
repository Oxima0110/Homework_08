// Задача 62. Заполните спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07


Console.Clear();
Console.WriteLine("Введите размер двухмерного массива через пробел ");
int[] size = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

int[,] FillArray(int[] arr)
{
    int[,] array = new int[arr[0], arr[1]];
    int iStep = 0;
    int num = 1;
    int i = 0;
    int j = 0;
    while (num <= array.GetLength(0) * array.GetLength(1))
    {
        array[i, j] = num;
        if (i == iStep && j < array.GetLength(1) - iStep - 1) j++;
        else if (j == array.GetLength(1) - iStep - 1 && i < array.GetLength(0) - iStep - 1) i++;
        else if (i == array.GetLength(0) - iStep - 1 && j > iStep) j--;
        else i--;

        if (i == iStep + 1 && j == iStep && iStep != array.GetLength(1) - iStep - 1)
        {
            iStep++;

        }
        num++;
    }
    return array;
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

int[,] arrayResult = FillArray(size);
PrintMatrix(arrayResult);