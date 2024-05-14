using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E94106119_practice_2_2
{
    internal class Program
    {   
        //存放鬼(避開第一次翻牌)
        static void Place_ghost(char[,] place, int ghost, int look_x, int look_y)
        {
            Random random = new Random();
            int a, b;
            while(ghost > 0)
            {
                a = random.Next(place.GetLength(0));
                b = random.Next(place.GetLength(1));

                if(look_x == a && look_y == b)
                {
                    continue;
                }
                else
                {
                    if (place[a, b] != 'X')
                    {
                        place[a, b] = 'X';
                        ghost--;
                    }
                }
            }
        }

        //計算每格鄰近的鬼
        static void Check_num(char[,] place)
        {
            for(int i = 0; i < place.GetLength(0); i++)
            {
                for(int j = 0; j < place.GetLength(1); j++)
                {
                    if (place[i,j] != 'X')
                    {
                        int num = 0;
                        for(int k = i-1; k <=i+1; k++)
                        {
                            for(int m = j-1; m <=j+1; m++)
                            {
                                if((k >= 0) && (m >= 0) && (k < place.GetLength(0)) && (m < place.GetLength(1)))
                                {
                                    if ((k == i) && (m == j))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if (place[k,m] == 'X')
                                        {
                                            num++;
                                        }
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }

                        place[i, j] = char.Parse(num.ToString());
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        //主程式
        static void Main(string[] args)
        {
            int x, y;
            int ghost;
            string input0;

            //設定遊戲參數
            Console.WriteLine("設定遊戲參數");
            Console.Write("輸入空間的大小: ");
            input0 = Console.ReadLine();
            string[] space = input0.Split(',');
            x = int.Parse(space[0]);
            y = int.Parse(space[1]);
            Console.Write("輸入鬼的數量: ");
            ghost = int.Parse(Console.ReadLine());

            //若參數設定錯誤則結束
            if (x * y <= ghost)
            {
                Console.WriteLine("遊戲參數錯誤!");
                Console.WriteLine();
                Console.WriteLine("請按任意鍵結束程式");
            }
            
            //若無誤則進入遊戲
            else
            {
                Console.Clear();

                char[,] game = new char[x, y]; //遊戲實時狀況
                for (int n = 0; n < game.GetLength(0); n++)
                {
                    for (int k = 0; k < game.GetLength(1); k++)
                    {
                        game[n, k] = '-';
                    }
                }
                char[,] place = new char[x, y]; //遊戲內存狀況

                //輸出遊戲畫面
                string format1 = "{0,-3}";
                string format2 = "{0,-2}";
                Console.Write(format1,' ');
                for(int n = 0; n < y; n++)
                {
                    Console.Write(format2, ((char)(n + 65)).ToString());
                }
                Console.WriteLine();
                for (int i = 0; i < x; i++)
                {
                    Console.Write(string.Format(format1, i));
                    for (int j = 0; j < y; j++)
                    {
                        Console.Write(string.Format(format2, game[i,j]));
                    }
                    Console.WriteLine();
                }

                int win_count = 0;
                //第一次查看位置
                while (true)
                {
                    Console.Write("輸入要查看的位置: ");
                    string input1 = Console.ReadLine();
                    string[] space_look = input1.Split(',');
                    int look_x = int.Parse(space_look[0]);
                    int look_y = (int)char.Parse(space_look[1]) - 65;

                    if ((look_x < 0) || (look_y < 0) || (look_x >= x) || (look_y >= y))
                    {
                        Console.WriteLine("無效的輸入，請再試一次");
                    }
                    else
                    {
                        //建立遊戲內容
                        Place_ghost(place, ghost, look_x, look_y);
                        Check_num(place);
                        game[look_x, look_y] = place[look_x, look_y];
                        win_count++;
                        Console.Clear();
                        break;
                    }
                }

                //已建立遊戲內容
                //第二次後查看位置
                bool run = true;
                while (run)
                 {
                    Console.Write(format1, ' ');
                    for (int n = 0; n < y; n++)
                    {
                        Console.Write(format2, ((char)(n + 65)).ToString());
                    }
                    Console.WriteLine();
                    for (int i = 0; i < x; i++)
                    {
                        Console.Write(string.Format(format1, i));
                        for (int j = 0; j < y; j++)
                        {
                            Console.Write(string.Format(format2, game[i,j]));
                        }
                        Console.WriteLine();
                    }

                    while (true)
                     {
                        Console.Write("輸入要查看的位置: ");
                        string input2 = Console.ReadLine();
                        string[] space_game = input2.Split(',');
                        int look_x0 = int.Parse(space_game[0]);
                        int look_y0 = (int)char.Parse(space_game[1]) - 65;

                        //輸入有問題
                        if ((look_x0 < 0) || (look_x0 >= x) || (look_y0 < 0) || (look_y0 >= y) || (game[look_x0, look_y0] != '-'))
                        {
                            Console.WriteLine("無效的輸入，請再試一次");
                        }
                        //被鬼抓了GG
                        else if (place[look_x0,look_y0] == 'X')
                        {
                            run = false;
                            Console.Clear();
                            Console.Write(format1, ' ');
                            for (int n = 0; n < y; n++)
                            {
                                Console.Write(format2, ((char)(n + 65)).ToString());
                            }
                            Console.WriteLine();
                            for (int i = 0; i < x; i++)
                            {
                                Console.Write(string.Format(format1, i));
                                for (int j = 0; j < y; j++)
                                {
                                    Console.Write(string.Format(format2, place[i, j]));
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine("遊戲結束! 你被鬼抓到了");
                            break;
                        }
                        //沒被鬼抓時就繼續
                        else
                        {
                            game[look_x0, look_y0] = place[look_x0, look_y0];
                            win_count++;
                            
                            //判斷有沒有翻開所有的非鬼牌
                            if(win_count == x*y - ghost)
                            {
                                run = false;
                                Console.Clear();
                                Console.Write(format1, ' ');
                                for (int n = 0; n < y; n++)
                                {
                                    Console.Write(format2, ((char)(n + 65)).ToString());
                                }
                                Console.WriteLine();
                                for (int i = 0; i < x; i++)
                                {
                                    Console.Write(string.Format(format1, i));
                                    for (int j = 0; j < y; j++)
                                    {
                                        Console.Write(string.Format(format2, place[i, j]));
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("遊戲結束! 你成功躲避所有的鬼了");
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                break;
                            }
                        }
                     }
                 }
            }
            Console.ReadKey();
        }
    }
}
