// ЭТО СЕРВИСНЫЕ ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
// цель - сделат ь так, что бы вообще не трогать их
// но пока не вижу, как грамотно осуществить селектор задач
// их может быть и одна и сто одна..

int InputChecker(string exeptionMessage) //немного изменённая стандартная функция для защиты от ввода не чисел
                                         // я понял , что текст ошибки может быть разным и удобно его посылать в функцию
                                         // поэтому она принимаеит string аргумент
{
    try
    {
        return Convert.ToInt32(Console.ReadLine());  // почему то не работает без переноса строки -  return Convert.ToInt32(Console.Read());  
    }
    catch
    {
        Console.WriteLine(exeptionMessage);
    }
    return InputChecker(exeptionMessage);  
}

double InputDoubleChecker() // функция для защиты от ввода не-чисел
                            // нам нужны однотипные проверки во всех задачах
{
    try
    {
        return Convert.ToDouble(Console.ReadLine()); 
    }
    catch
    {
        Console.Write("Работаем только числами, попробуй снова (ctrl+c для экстренного прерывания): ");
    }
    return InputDoubleChecker(); 
}
// посмотреть, можно ли в C# как-то организовать перегрузку метода по типу возвращаемого значения

string EndingChanger(int num, string one, string two, string many) // Функция для замены окончания, на входе числительное и окончания
                                                                   // для один -ист, два -иста, много -истов, окончания для разных
                                                                   // слов могут быть разные, поэтому посылаем их в функцию
                                                                   // и весь этот код только для изменения окончания в одном месте,
                                                                   // который почти никогда не будет меняться, всегда по 4 задачи...
{
    int n = num % 100;
    string ending = string.Empty; // это будем посылать в функцию для установки окончания

    if (n / 10 == 1) ending = many;                        // предпоследний разряд - 1
    else  // в этом ветвлении проверяем последний разряд
    {
        if (n % 10 == 1) ending = one;                     // последний разряд - 1
        else if (n % 10 >= 2 && n % 10 <= 4) ending = two; // последний разряд - 2..4
        else ending = many;                                // последний разряд - 5..9 или 0
    }
    return ending;
}

bool ExInit(int exerciseNumber, int totalCount, string[] exerciseText) // выбор и инициализация конкретной задачи, 
                                                                       // после выполнения - возвращаем значение флага,
                                                                       // который показывает будем дальше работать
                                                                       // или же прерываем работу
                                                                       // exerciseNumber - номер задачи
                                                                       // totalCount - количество задач
{
    if (exerciseNumber > 0 && exerciseNumber <= totalCount)
    {
        Console.WriteLine($"\n---Exercise {exerciseNumber}---");
        Console.WriteLine(exerciseText[exerciseNumber - 1]);
        switch (exerciseNumber)
        {
            case 1: { ExOne(); break; }
            case 2: { ExTwo(); break; }
            case 3: { ExThree(); break; }
            case 4: { ExFour(); break; }
        }
        Console.WriteLine("---End of Exercise---");
        return true;
    }
    else
    {
        switch (exerciseNumber)
        {
            case 0: return false;
            default: { Console.WriteLine($"Здесь только {totalCount} задач{EndingChanger(totalCount, "а", "и", "")}..."); return true; }
        }
    }
}


// ЗАДАЧИ

void ExOne()
{

    int currentPositionIndex = 0,// номер позиции (или иначе, количество уже введёных элементов) надо отслеживать 
        currentArrayNumber = 0,  // это номер массива в нашем блоке массивов
        currentMaxIndex = 4,     // это максимальный размер текущего массива, начнём с 4 элементов, степень двойки
        arraySizeMultiplier = 2; // каждый следующий массив будем удваивать

    int [][] megaArray = new int [30][]; //примерно 2 млрд чисел, думаю, хватит. Однако не знаю, как сделать потенциально бесконечный ввод,
    megaArray [0] = new int [currentMaxIndex]; 

    string nextInput = string.Empty,
           exeptionMessage = "!Работаем только с целыми числами, введите или число или пустую строку для завершения ввода (ctrl+c для экстренного прерывания)!";
    
    Console.Write("Введите первое число число: ");
    while (true) 
    {        
        nextInput = Console.ReadLine(); // сначала считываем строковое значение, проверям,
                                        // является ли пустой строкой и либо заканчиваем, 
                                        // либо уже остальные проверки мутим

        if (nextInput == "") break; // выходим из цикла While
        else
        {          
            try 
            {                
                if (currentMaxIndex == currentPositionIndex+1) // как только текущий массив заполняется
                                                               // мы перекидываем все числа из него в следующий
                                                               // в два раза больший массив и продолжаем работу
                {
                    megaArray [currentArrayNumber+1] = new int [currentMaxIndex*arraySizeMultiplier];

                    for (int i = 0; i < megaArray[currentArrayNumber].Length; i++)
                        megaArray[currentArrayNumber+1][i] = megaArray[currentArrayNumber][i];

                    currentMaxIndex *= arraySizeMultiplier; //следующий массив в два раз больше
                    currentArrayNumber++;
                }
                megaArray [currentArrayNumber] [currentPositionIndex] = Convert.ToInt32(nextInput);
                currentPositionIndex++;
            }
            catch
            {
                Console.WriteLine(exeptionMessage);
            }
        }     
        Console.Write("Введите следующее число: ");           
    } 

    Console.Write($"\nВы завершили ввод {currentPositionIndex} чис{EndingChanger(currentPositionIndex,"ла","ел","ел")}. ");

    int [] numbersList = new int [currentPositionIndex]; // наконец, мы создаём массив 
    for (int i = 0; i < currentPositionIndex; i++)
                        numbersList[i] = megaArray[currentArrayNumber][i];

    string list = string.Join(", ", numbersList);
    Console.WriteLine($"Все введённые числа:\n[{list}]"); 

    // собственно сама задача... ))

    int counter = 0; // счётчик наших чисел
    for (int i = 0; i < numbersList.Length; i++)
        if (numbersList[i]>0) counter++;   
     Console.WriteLine($"Количество чисел больше нуля: {counter}"); 
}

void DynamicArray () 
{    
    // не успеваю всё в отдельную функцию убрать..
}

void ExTwo()
{
    Console.WriteLine("/nВведите коэффициенты первой прямой y = k1 * x + b1");
    Console.Write("k1 = ");
    double k1 = InputDoubleChecker();
    Console.Write("b1 = ");
    double b1 = InputDoubleChecker();

    Console.WriteLine("/nВведите коэффициенты второй прямой y = k2 * x + b2");
    Console.Write("k2 = ");
    double k2 = InputDoubleChecker();
    Console.Write("b2 = ");
    double b2 = InputDoubleChecker();

    // немножко математики) точко пересечения гарантировано лежит на обеих прямых
    // стало быть мы приравниваем правые части обоих уравнений и вычисляем 
    // координату по оси абсцисс (х), затем подставив его в любое из изначальных
    // уровнений получаем координату по оси ординат (у)
    
    double x = (b2-b1)/(k1-k2);
    double y = k1*x+b1;

    Console.WriteLine($"/nТочка пересечения двух прямых: ({x}, {y})");    
}

int TriangleInput (string sideName) // защищаемся от ввода всякой фигни
{
    Console.Write($"{sideName} = ");
    int sideValue = InputChecker("в этой задаче я решил обойтись только целыми числами для размера сторон треугольника, попробуй снова:");
    if (sideValue < 0)
    {
        Console.WriteLine("Тут, конечно, можно было бы просто убрать минус, но из вредности заставлю заново вводить размер стороны");
        return TriangleInput (sideName);     // потихоньку догоняю что такое рекурсия, крутая штука!   
    }
    return sideValue;
}

double GetTriangleAngle (double k1, double k2, double k3, int precision)
{
    return Math.Round((180 / Math.PI)* Math.Acos((k1 * k1 + k3 * k3 - k2 * k2) / (2 * k1 * k3)), precision); 
    // теорема косинусов
    // заметка для себя: интерестно, что коэффициенты поступать должны именно double типа, иначе не адекватно работает
} 

void PrintTriangleInfo (int a, int b, int c)
{
    Console.Write("Укажите необходимую точность (кол-во знаков после запятой): ");
    int precision = InputChecker("Только целое положительное число!");
    
    double abc = GetTriangleAngle(a,b,c,precision),
           bca = GetTriangleAngle(b,c,a,precision),
           cab = GetTriangleAngle(c,a,b,precision),
           p = (a+b+c)/2, // полупериметр для следующей формулы
           area = Math.Round(Math.Sqrt(p*(p-a)*(p-b)*(p-c)),precision); // формула Герона
     
    Console.WriteLine();    
    Console.WriteLine($"Периметр = {a + b + c}");
    Console.WriteLine($"Площадь = {area}");
    Console.WriteLine($"Угол ABC = {abc}");
    Console.WriteLine($"Угол BCA = {bca}");
    Console.WriteLine($"Угол CAB = {cab}");
    if (a == b && a == c) Console.WriteLine("Это равносторонний треугольник");
    if (a == b || b == c || c == a) Console.WriteLine("Это равнобедренный треугольник");    
    if (abc == 90 || bca == 90 || cab == 90) Console.WriteLine("Это прямоугольный треугольник");
}

void ExThree()
{
    Console.WriteLine("Введите размеры сторон треугольника (a,b,c) для получения информации по нему: ");
    int a = TriangleInput("Сторона a");  
    int b = TriangleInput("Сторона b");
    int c = TriangleInput("Сторона c"); // защищаемся от ввода всякой фигни

    if (a<b+c && b<c+a && c<a+b) PrintTriangleInfo(a,b,c);
    else Console.WriteLine("Треугольник в такой конфигурации невозможен в евклидовом пространстве");
}

void ExFour()
{
    // не успел
} 

// ГЛАВНЫЙ КОД НАЧИНАЕТСЯ ЗДЕСЬ

Console.WriteLine("\n    --- Домашка шестая ---");
bool flag = true;
int num = 4; // придётся руками менять значение num и ветвление в функции ExInit()
string exeptionMessage = "Нужно ввести номер задачи цифрами или '0' для выхода (ctrl+c для экстренного прерывания): ";

string[] exerciseList = {
                            "1 задача: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь. При этом пользователь не задает сколько чисел он введет (то есть число M), а подсчет количества чисел производится после того, как пользователь не ввел информацию и нажал Enter.",
                            "2 задача: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.",
                            "3 задача HARD: На вход программы подаются три целых положительных числа. Определить , является ли это сторонами треугольника. Если да, то вывести всю информацию по нему - площадь, периметр, значения углов треугольника в градусах, является ли он прямоугольным, равнобедренным, равносторонним.",
                            "4 задача HARD: Сгенерировать массив случайных целых чисел размерностью m*n (размерность вводим с клавиатуры). Вывести на экран красивенько таблицей. Перемешать случайным образом элементы массива, причем чтобы каждый гарантированно переместился на другое место (возможно для этого удобно будет использование множества) и выполнить это за m*n / 2 итераций. То есть если массив три на четыре, то надо выполнить не более 6 итераций. И далее в конце опять вывести на экран как таблицу."
                        };

foreach (string text in exerciseList) Console.WriteLine(text);

while (flag) // бесконечный цикл, пока флаг = true. 
{
    Console.Write($"\nВведите или номер задачи (1..{num}) или 0 "
                    + "для выхода (для экстренного прерывания - ctrl+C): ");

    flag = ExInit(InputChecker(exeptionMessage), num, exerciseList);

    if (!flag)
    {
        Console.WriteLine("---Good buy!---\n");
        break;
    }
}