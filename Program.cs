using System;


namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Подстрока в строках\n2 - Последовательности чисел\n3 - Корни уравнения\n4 - Факториал");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    substr();
                    break;
                case 2:
                    sequence();
                    break;
                case 3:
                    quadratic();
                    break;
                case 4: 
                    factorial();
                    break;
                default:
                    Console.WriteLine("Wrong menu index");
                    break;
            }

            void substr() 
            {
                string[] strArray = new string[5];
                Console.WriteLine("---- Пожалуйста введите 5 строк ----\n");
                
                for(int i = 0; i < strArray.Length; i++) 
                {
                    Console.WriteLine($"Строка №{i+1}: ");
                    strArray[i] = Console.ReadLine();
                } 

                Console.WriteLine("Введите подстроку которую желаете найти: ");
                string toFind = Console.ReadLine();

                Console.WriteLine("\nСтроки:\n");
                for (int i = 0; i < strArray.Length; i++) 
                    Console.WriteLine(strArray[i]);
                Console.Write("\n");
                for (int i = 0; i < strArray.Length; i++) 
                {
                    int index = strArray[i].ToLower().IndexOf(toFind.ToLower());
                    if (index != -1) 
                        Console.WriteLine("Found '{0}' in {1} at position {2}", toFind, strArray[i], index+1);
                }

            }

            /* SECOND PART */

            void sequence()
            {
                int[] arr = new int[130];

                Random rand = new Random();
                for (int i = 0; i < arr.Length; i++) 
                {
                    arr[i] = rand.Next(101);
                }

                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\nНепрерывные последовательности чисел:\n");
                
                int start = 0, count = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    start = i; // Начальная позиция последовательности
                    for (int j = i+1; j < arr.Length; j++) 
                    {
                        if (arr[j] >= arr[i]) 
                        {
                            i = j; // Переходим на следующую последовательность или продолжаем старую

                        } else 
                            break;
                        
                    }
                    if (i - start > 0) // Минимум два элемента в последовательности
                    {
                        count++;
                        for (int v = start; v <= i; v++) {
                            if (v == i)
                                Console.Write(arr[v]);
                            else
                                Console.Write(arr[v] + "->");
                        }
                        Console.Write("\n");
                    }
                }

                Console.WriteLine("\nОбщее количество последовательностей: {0}", count);
            }

            /* THIRD PART */

            void quadratic() 
            {
                Console.WriteLine("---- Вычисление корней квадратного уравнения ----");
                double a = 0, b = 0, c = 0;
                double? value;

                double? convert(string val) 
                {
                    double newVal;
                    try
                    {
                        newVal = Convert.ToDouble(val);
                        return newVal;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert '{0}' to a Double.", val);
                    }
                    catch (OverflowException) 
                    {
                        Console.WriteLine("'{0}' is outside the range of a Double.", val);
                    }
                    return null;
                }

                Console.WriteLine("Введите коэфициент 'a': ");
                string inp = Console.ReadLine();
                value = convert(inp);
                if (!value.HasValue)
                    return;
                a = value.Value;

                Console.WriteLine("Введите коэфициент 'b': ");
                inp = Console.ReadLine();
                value = convert(inp);
                if (!value.HasValue)
                    return;
                b = value.Value;

                Console.WriteLine("Введите коэфициент 'c': ");
                inp = Console.ReadLine();
                value = convert(inp);
                if (!value.HasValue)
                    return;
                c = value.Value;

                double disc = Math.Pow(b, 2) - (4 * a * c); 
                if (disc < 0) {
                    Console.WriteLine("Нет решений, дискриминант < 0");
                    return;
                }
                double x1 = (-b + Math.Sqrt(disc)) / (2 * a);
                double x2 = (-b - Math.Sqrt(disc)) / (2 * a);

                Console.WriteLine("Решение найдено для x1 = {0}, x2 = {1}", x1, x2);
            
            }

            /* FOURTH PART */

            void factorial() 
            {
                int num = -1;
                int fact = 1;
                string val = "";

                try {
                    while(num < 0) 
                    {
                        Console.WriteLine("Введите число чтобы узнать его фактриал: ");
                        val = Console.ReadLine();
                        num = Convert.ToInt32(val);
                    }
                }
                catch (OverflowException) {
                    Console.WriteLine("{0} is outside the range of the Int32 type.", val);
                    return;
                }
                catch (FormatException) {
                    Console.WriteLine("The {0} value '{1}' is not in a recognizable format.",
                            val.GetType().Name, val);
                    return;
                }

                for (int x = 1; x <= num; x++)
                {
                    fact *= x;
                }
                Console.WriteLine("Факториал числа {0} равен {1}", num, fact);
            }
        }
    }
}