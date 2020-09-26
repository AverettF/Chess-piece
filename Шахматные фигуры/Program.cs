using System;

namespace Шахматные_фигуры
{
    class Program
    {
        //Перевод строки в char,и проверка на существование клетки
        static void CheckoutAndParce(string place, out char x, out char y, out bool error)
        {
            x = Convert.ToChar(place[0]);
            y = Convert.ToChar(place[1]);

            if (!((x >= 'A' && x <= 'H') && (y >= '1' && y <= '8')))    //Существует ли данная клетка?  
            {
                Console.WriteLine("НЕВЕРНЫЙ ВВОД");
                error = true;
            }
            else
            {
                error = false;
            }
        }

        //пешка
        static bool Pawn(char fromX, char fromY, char toX, char toY)
        {
            Console.WriteLine("Какая пешка? 1.Белая 2.Черная");
            string pawnWho = Console.ReadLine().ToUpper();

            int movePawnX = Math.Abs(Convert.ToInt32(fromX - toX));
            int movePawnY = Convert.ToInt32(fromY - toY);

            if (pawnWho == "1" || pawnWho == "БЕЛАЯ")
            {
                if (fromY == '2' && (toY == '3' || toY == '4') && fromX == toX)
                    return true;
                else if (movePawnY == 1 && fromX == toX)
                    return true;
                else if (movePawnY == 1 && movePawnX == 1)
                    return true;
                else
                    return false;
            }
            else if (pawnWho == "2" || pawnWho == "ЧЕРНАЯ")
            {
                if (fromY == '7' && (toY == '6' || toY == '5') && fromX == toX)
                    return true;
                else if (movePawnY == -1 && fromX == toX)
                    return true;
                else if (movePawnY == -1 && movePawnX == 1)
                    return true;
                else
                    return false;
            }
            else
            {
                Console.WriteLine("Неверно введены данные!");
                return false;
            }
        }

        //ладья
        static bool Rook(char fromX, char fromY, char toX, char toY)
        {
            if (((toX >= 'A' || toX <= 'H') && fromY == toY)
                || ((toY >= '1' || toY <= '8') && fromX == toX))
                return true;
            else
                return false;
        }

        //конь
        static bool Knight(char fromX, char fromY, char toX, char toY)
        {
            int moveKnightX = Math.Abs(Convert.ToInt32(fromX - toX));
            int moveKnightY = Math.Abs(Convert.ToInt32(fromY - toY));

            if ((moveKnightX == 1 && moveKnightY == 2)
                || (moveKnightX == 2 && moveKnightY == 1))
                return true;
            else
                return false;
        }

        //слон
        static bool Bishop(char fromX, char fromY, char toX, char toY)
        {
            int moveBishopX = Math.Abs(Convert.ToInt32(fromX - toX));
            int moveBishopY = Math.Abs(Convert.ToInt32(fromY - toY));

            if (moveBishopX == moveBishopY)
                return true;
            else
                return false;
        }

        //Ферзь
        static bool Queen(char fromX, char fromY, char toX, char toY)
        {

            if (Rook(fromX, fromY, toX, toY) || Bishop(fromX, fromY, toX, toY))
                return true;
            else
                return false;
        }

        //король
        static bool King(char fromX, char fromY, char toX, char toY)
        {
            int moveKingX = Math.Abs(Convert.ToInt32(fromX - toX));
            int moveKingY = Math.Abs(Convert.ToInt32(fromY - toY));

            if (moveKingY == 1 || moveKingX == 1)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            //IsCorrectHors     /
            // 0-48    9-57
            //A-65     H-72
            bool error;

            Console.Write("Введите фигуру:");
            string piece = Console.ReadLine().ToUpper();

            Console.Write("Введите начальное положение фигуры:");
            string beforPlace = Console.ReadLine().ToUpper();
            char fromX, fromY;
            CheckoutAndParce(beforPlace, out fromX, out fromY, out error);

            Console.Write("Введите конечное положение фигуры:");
            string afterPlace = Console.ReadLine().ToUpper();
            char toX, toY;
            CheckoutAndParce(afterPlace, out toX, out toY, out error);


            bool boolP = false;
            if (!error)
            {
                switch (piece)
                {
                    case "ПЕШКА":
                        boolP = Pawn(fromX, fromY, toX, toY);
                        break;
                    case "ЛАДЬЯ":
                        boolP = Rook(fromX, fromY, toX, toY);
                        break;
                    case "КОНЬ":
                        boolP = Knight(fromX, fromY, toX, toY);
                        break;
                    case "СЛОН":
                        boolP = Bishop(fromX, fromY, toX, toY);
                        break;
                    case "ФЕРЗЬ":
                        boolP = Queen(fromX, fromY, toX, toY);
                        break;
                    case "КОРОЛЬ":
                        boolP = King(fromX, fromY, toX, toY);
                        break;
                    default:
                        Console.WriteLine("Непрaвильный ввод фигуры!");
                        break;
                }
            }
            else
                Console.WriteLine("Извините,произошла опянка :Р");

            //Вывод
            Console.WriteLine("This is " + boolP); 
        }
    }
}