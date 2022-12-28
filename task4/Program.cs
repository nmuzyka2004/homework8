/* Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
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

int[] InitArray(int num)
{
    int[] array = new int[num];
    Random rnd = new Random();
    for (int i = 0; i < num; i++)
    {
        int j = rnd.Next(0,99);
        while (array.Contains(j))
        {
            j = rnd.Next(0,99);
        }
        array[i] = j;       
    }
    return array;
}


int[,,] Init3DMatrix (int[] array, int m, int n, int l)
{
    int[,,] matrix = new int[m,n,l];
    int iArr = 0;
    while (iArr < array.Length)
    {
                
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int k = 0; k < matrix.GetLength(2); k++)
                {
                    matrix[i,j,k] = array[iArr];
                    iArr++;                 
                }
            }
        
        }
    }
    return matrix;
}

void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                Console.Write($"{matrix[i,j,k]}({i},{j},{k}); ");
            }
            Console.WriteLine();
        }
        
    }
}

   
int m = GetNumber("Введите размер Х массива:");
int n = GetNumber("Введите размер Y массива:");
int l = GetNumber("Введите размер Z массива:");
int numberElements = m * n* l;
int[] arr = InitArray(numberElements);
int[,,] matr = Init3DMatrix(arr,m,n,l);
PrintMatrix(matr);




