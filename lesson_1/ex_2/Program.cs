// 11. Напишите программу, которая выводит случайное 
// трёхзначное число и удаляет вторую цифру этого числа.
// 456 -> 46
// 782 -> 72
// 918 -> 98

void ExOne (int numToDel)
{
  //  int x =  new Random().Next(100, 1000);
   // Console.WriteLine($"random 3-digit is {x}");

    // String a = x.ToString();
    // Console.WriteLine(a[0]+""+a[2]);
    // Ну круто же придумали, не?))))

    // Console.WriteLine($"with no second from end digit {x/100}{x%10}");

    // надо резать на кусочки , пока режется.. но массив нельзя..

  //  Console.WriteLine($"with no second from start digit {x/100}{x%10}");

    int n = Convert.ToInt32(Console.ReadLine());
    int a = 0;
    int count = 0;
    double temp = 0;

    for (int i = 1; i < n; i*=10) a++;
    Console.WriteLine($"\ntotal number of digits is {a}");
    if (a < 2) {Console.WriteLine("dis number is too small"); return;}

    Console.Write("with no second from start digit: ");
    for (int i = a-1; i > 0; i--) 
    {
        temp = n/(Math.Pow(10,i));
        count++;
        if (count != numToDel) Console.Write(Convert.ToInt32(temp));
    }
    Console.WriteLine("\nFinita");
    Console.WriteLine(temp);
}
// уйня в итоге не работает. вижу , можно рншить, с ещё большими костылями
// однако без массива хотя бы чисел прям жёстко .. вывернуть на изнанку, сравнить счётчки с нужным.. бррр


void DelSecNum()
{
Console.WriteLine("Enter number: ");
string number = Console.ReadLine();

for (int i = 0; i < number.Length; i++)
{
if (i != 1)
{
Console.Write(number[i]);
}
}
Console.WriteLine();
}

void ExOneAgain (int numToDel)
{
    Console.Write("please, enter your number: ");
    int n = Convert.ToInt32(Console.ReadLine());
 
    int a = 0;
    int count = 0;
    int temp = 0;

    for (int i = 1; i < n; i*=10) a++;
    Console.WriteLine($"total number of digits is {a}");
    if (a < 2) {Console.WriteLine("dis number is too small"); return;}

     count = n;
     for (int i = 1; i < count; i*=10) 
     {
        temp *=10;
        temp += n%10;
        n/=10;
        // Console.WriteLine(temp);
        // строка для отладки
     }

    Console.WriteLine($"Your number from opposite side is {temp}");

    Console.Write($"when we remove {numToDel}nd digit from your number it'll be: ");
    n = 0;
    for (int i = 0; i < a; i++) 
    {
        if (i != numToDel-1) 
        {
            n *=10;
            n += temp%10;
            //Console.Write(Convert.ToInt32(temp));
        }
        temp/=10;
    }

    Console.WriteLine(n); 
}

void ExOneShorter (int numToDel)
{
    Console.Write("please, enter your number: ");
    int n = Convert.ToInt32(Console.ReadLine());
 
    // здесь посчитаем общее количество знаков, плюс проверка на то, что бы больше чем позиция для удаления
    int count = 0;
    for (int i = 1; i < n; i*=10) count++;
    Console.WriteLine($"total number of digits is {count}");
    if (count < numToDel) {Console.WriteLine("dis number is too small"); return;}

    Console.Write($"when we remove {numToDel}nd digit from your number it'll be: ");
   
    for (int i = count-1; i > 0; i--) 
    {
        if (i != count - numToDel) //поскольку работаем "наизнанку" - то это проверка на число для удаления считая головы введенного числа
        {
            Console.Write(Convert.ToInt32(n/Math.Pow(10,i)));
       //    Console.WriteLine($"(({n}))");
      //      n %= Convert.ToInt32(Math.Pow(10,i)); // остатком от деления "отрезаем" от "головы" числа по одному знаку
      //  Console.Write($"(({n}[outif]))");
        }
        else {n %= Convert.ToInt32(Math.Pow(10,i)); }
        n %= Convert.ToInt32(Math.Pow(10,i)); // остатком от деления "отрезаем" от "головы" числа по одному знаку
      //  Console.Write($"(({n}[outif]))");
    }
    Console.WriteLine(n); 

}


//ExOne(2);
//DelSecNum();
//ExOneAgain(2);
// ExOneShorter(2);

Console.WriteLine("Введите первое целое число: ");
int number1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите второе целое число: ");
int number2 = Convert.ToInt32(Console.ReadLine());

string Multiplicity(int num1, int num2)
{
string multiplicity = String.Empty;
int max = num1;
int min = num2;

if (num2 > num1)
{
max = num2;
min = num1;
}

if (max % min == 0)
{
multiplicity = $"Число {max} кратно {min}";
}
else
{
multiplicity = $"Число {max} не кратно {min}, остаток {max % min}";
}

return multiplicity;
}
Console.WriteLine(Multiplicity(number1, number2));