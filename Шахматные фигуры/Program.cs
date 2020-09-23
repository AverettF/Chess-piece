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
            Figura=Figura.ToUpper();

            Console.Write("Введите начальное положение фигуры:");
            string beforPlace = Console.ReadLine();
            char beforX, beforY;
            CheckoutAndParce(beforPlace, out beforX, out beforY);

            Console.Write("Введите конечное положение фигуры:");
            string afterPlace = Console.ReadLine();
            char afterX, afterY;
            CheckoutAndParce(afterPlace, out afterX, out afterY);


            bool finel = false;
            switch (Figura)
            {
                case "ПЕШКА":
                    finel=Pawn(beforX, beforY, afterX, afterY);
                    break;
                case "ЛАДЬЯ":
                    finel = Rook(beforX, beforY, afterX, afterY);
                    break;
                case "КОНЬ":
                    finel = Knight(beforX, beforY, afterX, afterY);
                    break;
                case "СЛОН":
                    finel = Bishop(beforX, beforY, afterX, afterY);
                    break;
                case "ФЕРЗЬ":
                    finel = Queen(beforX, beforY, afterX, afterY);
                    break;
                case "КОРОЛЬ":
                    finel = King(beforX, beforY, afterX, afterY);
                    break;
            }
            
            Console.WriteLine(finel);






            //Перевод строки в char,и проверка на существование клетки
            static void CheckoutAndParce(string place, out char x, out char y)
            {
                place=place.ToUpper();
                x = Convert.ToChar(place[0]);
                y = Convert.ToChar(place[1]);

                if (!((x >= 'A' && x <= 'H') && (y >= '1' && y <= '8')))    //Существует ли данная клетка?  
                {
                    Console.WriteLine("НЕВЕРНЫЙ ВВОД");
                }
            }
            


            //пешка
            static bool Pawn(char beforX, char beforY, char afterX, char afterY)
            {
                return true;
            }

            //ладья
            static bool Rook(char beforX, char beforY, char afterX, char afterY)
            {
                if (((afterX >= 'A' || afterX <= 'H') && beforY == afterY)                                 
                    || ((afterY >= '1' || afterY <= '8') && beforX == afterX))
                    return true;
                else
                    return false;
            }

            //слон
            static bool Bishop(char beforX, char beforY, char afterX, char afterY)
            {
                int moveBishopX = Math.Abs(Convert.ToInt32(beforX - afterX));
                int moveBishopY = Math.Abs(Convert.ToInt32(beforY - afterY));

                if (moveBishopX == moveBishopY)
                     return true;
                else 
                    return false;
            }

            //Ферзь
            static bool Queen(char beforX, char beforY, char afterX, char afterY)
            {
                if (Queen(beforX, beforY, afterX, afterY)
                    && Bishop(beforX, beforY, afterX, afterY))
                    return true;
                else
                    return false;
            }

            //король
            static bool King(char beforX, char beforY, char afterX, char afterY)
            {
                int moveKingX = Math.Abs(Convert.ToInt32(beforX - afterX));
                int moveKingY = Math.Abs(Convert.ToInt32(beforY - afterY));

                if (moveKingY == 1 || moveKingX == 1)
                    return true;
                else 
                    return false;
            }

            //конь
            static bool Knight(char beforX, char beforY, char afterX, char afterY)
            {
                int moveKnightX = Math.Abs(Convert.ToInt32(beforX - afterX));
                int moveKnightY = Math.Abs(Convert.ToInt32(beforY - afterY));

                if ((moveKnightX == 1 && moveKnightY == 2)
                    || moveKnightX == 2 && moveKnightY == 1)
                    return true;
                else
                    return false;
            }
        }
    }
}

