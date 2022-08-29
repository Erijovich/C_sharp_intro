/* Console.Write("введите ваше имя ");
        string name = Console.ReadLine();
 
        switch (name)
            {
            case "Bob":
                Console.WriteLine("Здарова, Bob");
                break;
            case "Tom":
                Console.WriteLine("Привет, Tom");
                break;
            case "Sam":
                Console.WriteLine("Как дела, Sam");
                break;
            default:
                Console.WriteLine("Приятно познакомиться, "+name);
                break;
            }
           */

/* Напишите программу, которая принимает 
на вход число (А) и выдаёт сумму чисел от 1 до А.
7 -> 28
4 -> 10
8 -> 36
 */

/* int [] arr = {5,6,7,32,65,312,5,2,5};
foreach (int i in arr) Console.Write($"{i}, ");
Console.WriteLine(); */

 void ArrayMinMaxSort (int[] array)
 {
    for (int i = 0; i < array.Length - 1; i++)
    {
        int minPos = i;

        for (int j = i+1; j < array.Length; j++)
            if (array[j] < array[minPos]) minPos=j;
        
        int temp = array[i];
        array[i] = array [minPos];
        array[minPos] = temp;
    }
 }

int InputChecker() 
{
    try
    {
        return Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        Console.Write("Работаем только с целыми числами, попробуй снова (ctrl+c для экстренного прерывания): ");
    }
    return InputChecker(); 
}

int[] CreateArray(int n, int min, int max) // создание массива размера n и заполнение целыми числами из диапазона min..max
{
    if (max < min)  // проверка и защита
    {
        int temp = min;
        min = max;
        max = temp;
    }

    int[] arr = new int[n];
    for (int i = 0; i < n; i++) arr[i] = new Random().Next(min, max);
    return arr;
}

void ExerciseArray() // Exercise Two
{
    Console.WriteLine();

    int n = 0, min = 0, max = 0;

    while (true)
    {
        Console.Write("Введите размер массива: ");
        n = InputChecker();

        if (n < 1) Console.WriteLine();
        else break;
    }

    Console.Write("Введите диапазон значений для чисел массива\nМинимальное значение: ");
    min = InputChecker();
    Console.Write("Максимальное значение: ");
    max = InputChecker();

    int[] arr = CreateArray(n, min, max);    
    string list = string.Join(", ", arr);
    Console.WriteLine($"в массиве следующие числа:\n({list})");

    // ArrayMinMaxSort(arr);

    // list = string.Join(", ", arr);
    // Console.WriteLine($"в отсортированном массиве следующие числа:\n({list})");
    FindMinAndMaxIndex(arr);
}



void FindMinAndMaxIndex (int[] array)
{
    int max = array[0], min = array[0];
    int iMax = 0, iMin = 0;
    double mArr = 0;
    Console.WriteLine($"массив длинной {array.Length}");
    
    for (int i = 0 ; i <array.Length; i++) 
    {
        Console.WriteLine($"{i+1} итерация:");
        if (array[i] > max) 
        {
            max = array[i];
            iMax = i;
            Console.Write($"imax = {iMax}, max = {max}, ");
        }
        if (array[i] < min) 
        {
            min = array[i];
            iMin = i;
            Console.Write($"imin = {iMin}, min = {min}, ");
        }
        mArr += array[i];
        Console.WriteLine($"mArr = {mArr}\n");
    }
    
    
    
    Console.WriteLine($"Максимальный элемент на позиции {iMax} равен {max}, "
                    + $"минимальный элемент на позиции {iMin} равен {min}"
                    + $"\nСреднее арифметическое этих элементов: {mArr/array.Length}");
}


ExerciseArray();

