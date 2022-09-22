/* 
// Найти сумму всех натуральных чисел от 1 до N. N - задается пользователем.
        int SummaLoop(int N)
            {
                int sum=0;
                while (N>0)
                {
                    sum+=N;
                    N--;
                }
                return sum;
            }
        
        int SummaRec(int N)
            {
                if (N==0) return 0;
                return N+SummaRec(N-1);
            }


        Console.WriteLine(SummaLoop(5));
        Console.WriteLine(SummaRec(5));
 */

/* 
Задача 63: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от 1 до N.
N = 5 -> "1, 2, 3, 4, 5"
N = 6 -> "1, 2, 3, 4, 5, 6"

Задача 65: Задайте значения M и N. Напишите программу, которая выведет все натуральные числа в промежутке от M до N.
M = 1; N = 5 -> "1, 2, 3, 4, 5"
M = 4; N = 8 -> "4, 6, 7, 8"
 */


//string list = string.Join(", ", a);
//Console.WriteLine($"Созданный массив:\n[{list}]"); 

/* int InputChecker()
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
} */

 string RetunAllNatural(int N)
            {
                if (N==0) return string.Empty;
                return RetunAllNatural(N-1) + $"{N}, "; // вот это вау
            }

// Console.Write(RetunAllNatural(5));


 string RetunMNNatural(int M, int N)
            {
                if (N==M) return $"{M}";
                return RetunMNNatural(M, N-1) + $", {N}"; // вот это вау
            }


// Console.Write(RetunMNNatural(3, 10));

/*
Задача 67: Напишите программу, которая будет принимать на вход число и возвращать сумму его цифр.
453 -> 12
45 -> 9
Задача 69: Напишите программу, которая на вход принимает два числа A и B, и возводит число А в целую степень B с помощью рекурсии.
A = 3; B = 5 -> 243 (3⁵)
A = 2; B = 3 -> 8 
*/

int Power (int A, int B)
    {
        if (B==0) return 1;
        return A*Power(A, B-1);
    }

// Console.Write(Power(3,3));

//int n = Convert.ToInt32(Console.ReadLine());

int DigitsSum (int n)
{
    if (n==0) return 0;
    return n%10 + DigitsSum(n/10);
}

Console.Write(DigitsSum(32221));

/* Console.WriteLine ("Напишите число N");
    Console.WriteLine ("N= ");
    int N = Convert.ToInt32(Console.ReadLine());

int SumRec(int N)
            {
                if (N==0) return 0;
                return N%10 + SumRec(N / 10);
            }
Console.WriteLine(SumRec(N)); */

/* 
Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.

m = 3, n = 2 -> A(m,n) = 29
 */
