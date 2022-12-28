/* Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
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

//Метод умножения двух матриц
int[,] GetMultMatrix(int[,] matrixOne, int[,] matrixTwo)
{
    int [,] resultMatrix = new int[matrixOne.GetLength(0),matrixTwo.GetLength(1)];

    for (int i = 0; i < matrixOne.GetLength(0); i++)
    {       
        for (int j = 0; j < matrixTwo.GetLength(1); j++)
        {
            int summ = 0;
            for (int k = 0; k < matrixOne.GetLength(1); k++)
            {
                summ += matrixOne[i,k] * matrixTwo[k,j];
            }
            resultMatrix[i,j] = summ;                             
        }              
    }
    return resultMatrix;  
}

int rowFirstMatrix = GetNumber("Введите количество строк в первой матрице");
int colFirstMatrix = GetNumber("Введите количество столбцов в первой матрице");
int[,] matrFirst = InitMatrix(rowFirstMatrix,colFirstMatrix);
int rowSecondMatrix = GetNumber("Введите количество строк в первой матрице");
int colSecondMatrix = GetNumber("Введите количество столбцов в первой матрице");
int[,] matrSecond = InitMatrix(rowSecondMatrix,colSecondMatrix);
if (rowFirstMatrix == colSecondMatrix)
{
    Console.WriteLine("Первая матрица:");
    PrintMatrix(matrFirst);
    Console.WriteLine("Вторая матрица:");
    PrintMatrix(matrSecond);
    int[,] matrResult = GetMultMatrix(matrFirst,matrSecond);
    Console.WriteLine("Результат умножения матриц:");
    PrintMatrix(matrResult);
}
else
    Console.WriteLine("Матрицы не совместимы: число строк первой матрицы должно быть равно" +
        " числу столбцов второй");


