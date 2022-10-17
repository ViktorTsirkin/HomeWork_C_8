/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой 
строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

Console.Clear();
Console.WriteLine("Количество строк: ");
int rows = int.Parse(Console.ReadLine()!);

Console.WriteLine("Количество столбцов: ");
int columns = int.Parse(Console.ReadLine()!);

int[,] array = GetArray(rows, columns, 0, 9);
PrintArray(array);

Console.WriteLine();

SortRows(array);
PrintArray(array);

int[,] GetArray(int m, int n, int minValue, int maxValue) //двумерный массив по методу
{
    int[,] result = new int[m, n];
    for(int i = 0; i < m; i++) // строки
    {
        for(int j = 0; j < n; j++) // столбцы
        {
            result[i,j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] array) //вывод двумерного массива
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

void SortRows(int[,] array)
{
    for (int row = 0; row < array.GetLength(0); row++)
    {
        int [] newArray = new int[array.GetLength(1)];
        for (int column = 0; column < array.GetLength(1); column++)
        {
            newArray[column] = array[row, column];
        }
        Array.Sort(newArray);
        Array.Reverse(newArray);
        for (int column = 0; column < array.GetLength(1); column++)
        {
            array[row, column] = newArray[column];
        }        
    }
}
