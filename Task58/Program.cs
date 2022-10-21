/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

Console.Clear();
Console.WriteLine("Количество строк: ");
int rows = int.Parse(Console.ReadLine()!);

Console.WriteLine("Количество столбцов: ");
int columns = int.Parse(Console.ReadLine()!);
Console.WriteLine();

int[,] array1 = GetArray(rows, columns, 0, 5);
PrintArray(array1);
Console.WriteLine();
int[,] array2 = GetArray(rows, columns, 0, 5);
PrintArray(array2);

Console.WriteLine();

if (array1.GetLength(1) != array2.GetLength(0))
{
    Console.WriteLine("Невозможно перемножить матрицы");
}
else
{
    int[,] array3 = Multiplication(array1, array2);
    PrintArray(array3);
}


int[,] GetArray(int m, int n, int minValue, int maxValue) 
{
    int[,] result = new int[m, n];
    for(int i = 0; i < m; i++)
    {
        for(int j = 0; j < n; j++)
        {
            result[i,j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] array) 
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }
}

int[,] Multiplication(int[,] array1, int[,] array2)
{
    
    int[,] resultArray = new int[array1.GetLength(0), array2.GetLength(1)];
    Parallel.For(0, array1.GetLength(0), (i) =>
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            for (int k = 0; k < array2.GetLength(0); k++)
            {
                resultArray[i,j] += array1[i,k] * array2[k,j];
            }
        }
    });
    return resultArray;    
}