using System;

namespace Шахматные_фигуры
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0-48    9-57
            //A-65     H-72
            int x = 0;
            while (x != 10)
            {
                Console.Write("Введите фигуру:");
                string piece = Console.ReadLine();
                piece = piece.ToUpper();

                Console.Write("Введите начальное положение фигуры:");
                string beforPlace = Console.ReadLine();
                char beforX, beforY;
                CheckoutAndParce(beforPlace, out beforX, out beforY);

                Console.Write("Введите конечное положение фигуры:");
                string afterPlace = Console.ReadLine();
                char afterX, afterY;
                CheckoutAndParce(afterPlace, out afterX, out afterY);


                bool boolP = false;
                switch (piece)
                {
                    case "ПЕШКА":
                        boolP = Pawn(beforX, beforY, afterX, afterY);
                        break;
                    case "ЛАДЬЯ":
                        boolP = Rook(beforX, beforY, afterX, afterY);
                        break;
                    case "КОНЬ":
                        boolP = Knight(beforX, beforY, afterX, afterY);
                        break;
                    case "СЛОН":
                        boolP = Bishop(beforX, beforY, afterX, afterY);
                        break;
                    case "ФЕРЗЬ":
                        boolP = Queen(beforX, beforY, afterX, afterY);
                        break;
                    case "КОРОЛЬ":
                        boolP = King(beforX, beforY, afterX, afterY);
                        break;
                    default:
                        Console.WriteLine("Непрвильно введа фигура!");
                        break;
                }

                Console.WriteLine("Это "+boolP);






                //Перевод строки в char,и проверка на существование клетки
                static void CheckoutAndParce(string place, out char x, out char y)
                { 
                    place = place.ToUpper();
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
                    Console.WriteLine("Пешка чья? Ваша или противника?");
                    Console.WriteLine("Ответ:1.Моя 2.Врага");
                    string pawn = Console.ReadLine().ToUpper();
                    if (pawn == "МОЯ" || pawn == "1")
                    {
                        if (beforX == '2' && (afterX == '3' || afterX == '4'))
                            return true;
                        else
                        {
                            int movePawnX = Math.Abs(Convert.ToInt32(beforX - afterX));
                            int movePawnY = Convert.ToInt32(beforY - afterY);

                            if (movePawnY == 1 && beforX == afterX)
                                return true;
                            else if (movePawnY == 1 && movePawnX == 1)
                                return true;
                            else
                                Console.WriteLine("Неверно введены данные");
                        }
                    }  
                            
                   else
                   {

                        int movePawnX = Math.Abs(Convert.ToInt32(beforX - afterX));
                        int movePawnY = Convert.ToInt32(beforY - afterY);
                        if (movePawnY == -1 && beforX == afterX)
                            return true;
                       else if (movePawnY == -1 && movePawnX == 1)
                            return true;
                       else
                       Console.WriteLine("Неверно введены данные");
                   }
                            
                    
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
                   
                    if (Rook(beforX, beforY, afterX, afterY) || Bishop(beforX, beforY, afterX, afterY)) 
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
                        || (moveKnightX == 2 && moveKnightY == 1))
                        return true;
                    else
                        return false;
                }
                x++;



               //Для ферзя
               // bool boolQ1 = Rook(beforX, beforY, afterX, afterY);
               //  bool boolQ2 = Bishop(beforX, beforY, afterX, afterY);
               // if (boolQ1 || boolQ2)
            }
        }
    }
}

