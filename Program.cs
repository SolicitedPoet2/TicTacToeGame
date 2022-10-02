using System;

namespace TicTacToeGame
{
    class Game
    {
        string start;
        string turn;
        bool isPlaying;
        char Win;
        char[,] area = new char[3,3]{{'N', 'N', 'N'},
                                     {'N', 'N', 'N'},
                                     {'N', 'N', 'N'}
                                    };
        
        void show()
        {
            Console.WriteLine("Columns 1 2 3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("LINE" + "| " + (i+1) + " "); 
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(area[i,j] + " ");
                }
                Console.Write("\n");
            }
        }
        void verifyWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if((area[0,i] == 'X') && (area[1,i] == 'X') && (area[2, i] == 'X'))
                {
                    Win = 'X';
                    isPlaying = false;
                    return;
                }
                else if((area[0,i] == 'O') && (area[1,i] == 'O') && (area[2, i] == 'O'))
                {
                    Win = 'O';
                    isPlaying = false;
                    return;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if((area[i,0] == 'X') && (area[i,1] == 'X') && (area[i,2] == 'X'))
                {
                    Win = 'X';
                    isPlaying = false;
                    return;
                }
                else if((area[i,0] == 'O') && (area[i,1] == 'O') && (area[i,2] == 'O'))
                {
                    Win = 'O';
                    isPlaying = false;
                    return;
                }
            }
            if((area[0,0] == 'X') && (area[1,1] == 'X') && (area[2,2] == 'X'))
            {
                Win = 'X';
                isPlaying = false;
                return;
            }
            else if((area[0,0] == 'O') && (area[1,1] == 'O') && (area[2,2] == 'O'))
            {
                Win = 'O';
                isPlaying = false;
                return;
            }
            if((area[0,2] == 'X') && (area[1,1] == 'X') && (area[2,0] == 'X'))
            {
                Win = 'X';
                isPlaying = false;
                return;
            }
            else if((area[0,2] == 'O') && (area[1,1] == 'O') && (area[2,0] == 'O'))
            {
                Win = 'O';
                isPlaying = false;
                return;
            }
            foreach (var item in area)
            {
                if (item == 'N')
                {
                    return;
                }
            }
            Win = 'N';
            isPlaying = false;
            return;
        }
        void update(char XorO, int x, int y) 
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (area[i,j] == 'N' && (i == x && j == y))
                    {
                        Console.Clear(); 
                        area[i,j] = XorO;
                        verifyWin();
                        return;
                    }

                }
            }
            Console.Clear();
            Console.WriteLine("A " + XorO + " already is on the Coordinate X: " + (x+1) + " and Coordinate Y: " + (y+1));
            if (XorO == 'O')
            {
                turn = "O";
            }
            else
            {
                turn = "X";
            }
            return;
        }
        void game(string start)
        {
            Console.Clear();
            isPlaying = true;
            turn = start;
            int x;
            int y;
            Loop:
            show();
            switch(turn)
            {
                case "X":
                        XAgain:
                        Console.Write("The X turn!\nSay the coordinates\nCoordinate X(line): ");
                        try
                        {
                            x = Int32.Parse(Console.ReadLine()) - 1;
                        }
                        catch(FormatException e)
                        {
                            Console.WriteLine("Only enter integer numbers, please");
                            goto XAgain;
                        }
                        if (x > 2 || x < 0)
                        {
                            Console.WriteLine("The Max value of X is 3, don't enter a number higher or lower than it");
                            goto XAgain;
                        }
                        Console.Write("Coordinate Y(column): ");
                        try
                        {
                            y = Int32.Parse(Console.ReadLine()) - 1;
                        }
                        catch(FormatException e)
                        {
                            Console.WriteLine("Only enter integer numbers, please");
                            goto XAgain;
                        }
                        if (y > 2 || y < 0)
                        {
                            Console.WriteLine("The Max value of X is 3, don't enter a number higher or lower than it");
                            goto XAgain;
                        }
                        turn = "O";
                        update('X', x, y);
                    break;
                case "O":
                        OAgain:
                        Console.Write("The O turn!\nSay the coordinates\nCoordinate X(line): ");
                        try
                        {
                            x = Int32.Parse(Console.ReadLine()) - 1;
                        }
                        catch(FormatException e)
                        {
                            Console.WriteLine("Only enter integer numbers, please");
                            goto OAgain;
                        }
                        if (x > 2 || x < 0)
                        {
                            Console.WriteLine("The Max value of X is 3, don't enter a number higher or lower than it");
                            goto OAgain;
                        }
                        Console.Write("Coordinate Y(column): ");
                        try
                        {
                            y = Int32.Parse(Console.ReadLine()) - 1;
                        }
                        catch(FormatException e)
                        {
                            Console.WriteLine("Only enter integer numbers, please");
                            goto OAgain;
                        }
                        if (y > 2 || y < 0)
                        {
                            Console.WriteLine("The Max value of X is 3, don't enter a number higher or lower than it");
                            goto OAgain;
                        }
                        turn = "X";
                        update('O', x, y);
                    break;
            }

            if (isPlaying)
            {
                goto Loop;
            }
            if (Win == 'X')
            {
                Console.WriteLine("The X won!");
                show();
            }
            else if (Win == 'O')
            {
                Console.WriteLine("The O won!");
                show();
            }
            else if (Win == 'N')
            {
                Console.WriteLine("The game ended in a draw");
                show();
            }
        }   
        public Game()
        {
            Console.Clear();
            Return:
            Console.WriteLine("Hello to tic tac toe game!\nThe N means null.");
            Console.Write("Who will start?\nX or O?: ");
            start = Console.ReadLine();
            switch(start)
            {
                case "X":
                    game(start);
                    break;
                case "O":
                    game(start);
                    break;   
                default:
                    Console.WriteLine("You must type X or O, any others letters are not allowed.\nRestarting...");
                    goto Return; 
            }
        }
        static void Main(String[] args)
        {
            Game game = new Game();
        }  
    }
}