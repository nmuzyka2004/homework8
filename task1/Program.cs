/*Задача 54: Задайте двумерный массив. Напишите программу, 
которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/
int GetNumber (string message)
{
    int result;
    while (true)
    {
        Console.WriteLine(message);
        if (int.TryParse(Console.ReadLine(), out result))
        {
            break;
        }
        else 
        {
            Console.WriteLine("Ввели не число или некорректное число");
        }
    }
    return result;
}


int[,] InitMatrix (int m, int n)
{
    int[,] matrix = new int[m,n];
    Random rnd = new Random();
    
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i,j] = rnd.Next(0,10);  
        }
        
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
     for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }
}

//Метод сортировки элементов строк по убыванию 
int[,] GetSortMatrix(int[,] matrix)
{
   
    for (int i = 0; i < matrix.GetLength(0); i++)
    {       
        for (int index = 0; index < matrix.GetLength(1); index++)
        {
            int tmp = 0;
            for (int j = 0; j < (matrix.GetLength(1) - 1); j++)
            {
                if (matrix[i,j] < matrix[i,j+1])
                {
                    tmp = matrix[i,j];
                    matrix[i,j] = matrix[i,j+1];
                    matrix[i,j+1] = tmp;
                }
            }                                       
        }              
    }
    return matrix;  
}

   
int m = GetNumber("Введите количество строк в массиве");
int n = GetNumber("Введите количество столбцов в массиве");
int[,] matr = InitMatrix(m,n);
PrintMatrix(matr);
int[,] sortMatrix = GetSortMatrix(matr);
Console.WriteLine("Отсортированный массив:");
PrintMatrix(sortMatrix);



