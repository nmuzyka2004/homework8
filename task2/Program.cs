/* Задайте прямоугольный двумерный массив. Напишите программу, которая будет 
находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 
1 строка
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

//Метод вычисления суммы элементов в строках массива
int[] GetSumRowMatrix(int[,] matrix)
{
    int[] arraySumRow = new int[matrix.GetLength(0)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {      
        int summ = 0; 
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            summ = summ + matrix[i,j];                                                              
        }  
        arraySumRow[i] = summ;            
    }
    return arraySumRow;  
}

//Метод нахождения строки с наименьшим элементом одномерного массива
int GetMinRowArray(int[] array)
{
    int minElement = array[0];
    int rowNumber = 0;

    for (int i = 1; i < array.Length; i++)
    {      
        if (minElement > array[i])
        {
            minElement = array[i];
            rowNumber = i;
        }        
    }
    return rowNumber;  
} 
//Метод выводящий одномерный массив в столбик
void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"{array[i]}");
    }   
}
int m = GetNumber("Введите количество строк в массиве");
int n = GetNumber("Введите количество столбцов в массиве");
int[,] matr = InitMatrix(m,n);
PrintMatrix(matr);
int[] arr = GetSumRowMatrix(matr);
Console.WriteLine("Суммы элементов строк массива:");
PrintArray(arr);
Console.WriteLine($"Номер строки с наименьшей суммой элементов: {GetMinRowArray(arr)+1}");

