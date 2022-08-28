// Напишите программу, которая по заданному номеру четверти, 
// показывает диапазон возможных координат точек в этой четверти (x и y).


string CheckQuater (int a)
{
    string res = string.Empty;

    if (a <=0 || a>4) 
    {
        Console.WriteLine("should be in range 1..4");
      //  Console.Write ("select the quater: ");
      //  CheckQuater(int.Parse(Console.ReadLine())); Чтото ломается и ничего не возвращает
    }
    else if (a == 1) res = "0 < x < inf, 0 < y < inf";
    else if (a == 2) res = "-inf < x < 0, 0 < y < inf";
    else if (a == 3) res = "-inf < x < 0, -inf < y < 0";
    else if (a == 4) res = "0 < x < inf, -inf < y < 0";

    return res;

}

void ExOne ()
{
    try 
    {
        Console.Write ("select the quater: ");
        Console.WriteLine(CheckQuater(int.Parse(Console.ReadLine())));

    /*  if (a == 1) Console.WriteLine("0 < x < inf, 0 < y < inf");
        else if (a == 2) Console.WriteLine("-inf < x < 0, 0 < y < inf");
        else if (a == 3) Console.WriteLine("-inf < x < 0, -inf < y < 0");
        else if (a == 4) Console.WriteLine("0 < x < inf, -inf < y < 0"); */
    }
    catch
    {
        Console.WriteLine("only whole numbers is accepted");
    }
}


// Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 2D пространстве.
// A (3,6); B (2,1) -> 5,09
// A (7,-5); B (1,-1) -> 7,21

void ExTwo()
{
    try
    {
        Console.WriteLine($"length is {Length2D()}");
    }
    catch
    {
        Console.WriteLine("only whole numbers is accepted");
        ExTwo();
    }

}

double Length2D () 
{
    

    Console.Write ("Insert xa: "); 
    int xa = Convert.ToInt32(Console.ReadLine());
    Console.Write ("Insert ya: "); 
    int ya = Convert.ToInt32(Console.ReadLine());
    Console.Write ("Insert xb: "); 
    int xb = Convert.ToInt32(Console.ReadLine());
    Console.Write ("Insert yb: "); 
    int yb = Convert.ToInt32(Console.ReadLine());
        

    return Math.Sqrt((xa-xb)*(xa-xb) + (ya-yb)*(ya-yb)) ;
}

/* Напишите программу, которая принимает на вход число (N) и выдаёт таблицу квадратов чисел от 1 до N.
5 -> 1, 4, 9, 16, 25.
2 -> 1,4 */

void ExThree()
{
    try
    {
        Console.Write($"write whole number ");
        int n = Convert.ToInt32(Console.ReadLine());
        var str = string.Join(" ", SquaresList(n)); //можно и string вместо var
        Console.WriteLine(str);        


       /*  for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        } */
    }
    catch
    {
        Console.WriteLine("only whole numbers is accepted");
      //  ExThree();
    }
}

int[] SquaresList (int n)
{
    int[] arr = new int [n];


    for (int i = 1; i < n+1; i++)
    {
        arr[i-1] = i*i;
       // Console.Write(arr[i-1]+" ");        
    }

    return arr;
}



//ExOne();
//ExTwo();
ExThree();


