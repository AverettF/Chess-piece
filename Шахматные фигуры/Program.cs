using System;

namespace Шахматные_фигуры
{
    class Program
    {  
        static void Main(string[] args)
        {
            // 0-48    9-57
            //A-65     H-72


            Console.Write("Введите фигуру:");
            string Figura = Console.ReadLine();

            Console.Write("Введите начальное положение фигуры:");
            string firstPlace = Console.ReadLine();
            char x1, y1;
            CheckoutAndParce(firstPlace, out x1, out y1);

            Console.Write("Введите конечное положение фигуры:");
            string nextPlace = Console.ReadLine();
            char x2, y2;
            CheckoutAndParce(nextPlace, out x2, out y2);

            switch (Figura)
            {
                case "ПЕШКА":
                    Pawn();
                    break;
                
                    
            }


            static void CheckoutAndParce(string place, out char x,out char y)
            {
                place.ToUpper();
                x = Convert.ToChar(place[0]);
                y = Convert.ToChar(place[1]);
                 
                if(!((x>64 && x<73 ) && (y>48 && y < 58)))    //Существует ли данная клетка?  
                {
                    Console.WriteLine("НЕВЕРНЫЙ ВВОД");
                }
            }

            static bool Pawn(char x1,char y1, char x2, char y2)
            {
                if (x1 == '2' && (x2 == '3' || x2 == '4'))
                    return true;
                else if (x1 == '7' && (x2 == '6' || x2 == '5'))
                    return true;
            }

        }
    }
}
