using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E94106119_practice_1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1 = 0;
            
            int thing1 = 0;
            int thing2 = 0;
            int thing3 = 0;
            
            while (input1 != 6)
            {
                Console.WriteLine("(1)商品列表 (2)新增至購物車 (3)自購物車刪除 " +
                "(4)查看購物車 (5)計算總金額 (6)退出網站");
                Console.Write("輸入數字選擇功能 : ");
                 input1 = int.Parse(Console.ReadLine());

                switch (input1)
                {
                    case 1:
                        Console.WriteLine("列表:");
                        Console.WriteLine("商品名稱 商品單價");
                        Console.WriteLine("1.潛水相機防丟繩 (TWD)199");
                        Console.WriteLine("2.潛水配重帶 (TWD)460");
                        Console.WriteLine("3.潛水作業指北針 (TWD)1100");
                        Console.WriteLine();
                        break;

                    case 2:
                        int input2 = 0, input3 = 0 ;
                        Console.WriteLine("(1)潛水潛水相機防丟繩 (2)潛水配重帶 (3)潛水作業指北針");
                        Console.Write("輸入數字選擇商品 : ");
                        input2 = int.Parse(Console.ReadLine());
                        Console.Write("輸入數量 : ");
                        input3 = int.Parse(Console.ReadLine());
                        
                        if (input2 == 1)
                        {
                            thing1 +=  input3;
                        }
                        else if(input2 == 2)
                        {
                            thing2 +=  input3;
                        }
                        else
                        {
                            thing3 += input3; 
                        }

                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("購物車內容:");
                        Console.WriteLine("商品 單價 數量 小計");
                        Console.WriteLine("1.潛水相機防丟繩 (TWD)199 {0} {1}", thing1, thing1 * 199);
                        Console.WriteLine("2.潛水配重帶 (TWD)460 {0} {1}", thing2, thing2 * 460);
                        Console.WriteLine("3.潛水作業指北針 (TWD)1100 {0} {1}", thing3, thing3*1100);

                        int input4 = 0, input5 = 0;
                        Console.Write("輸入數字選擇商品 : ");
                        input4 = int.Parse(Console.ReadLine());

                        if(input4 != 4)
                        {
                            Console.Write("輸入數量 : ");
                            input5 = int.Parse(Console.ReadLine());

                            switch (input4)
                            {
                                case 1:
                                    thing1 -= input5;
                                    break;

                                case 2:
                                thing2 -= input5;
                                break;

                                case 3:
                                thing3 -= input5;
                                break;

                            }
                            Console.WriteLine("成功刪除商品!");
                        }

                        else
                        {
                            Console.WriteLine("輸入錯誤!請重新輸入!");
                        }

                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine("購物車內容：");
                        Console.WriteLine("商品 單價 數量 小計");
                        Console.WriteLine("1.潛水相機防丟繩 (TWD)199 {0} {1}", thing1, thing1 * 199);
                        Console.WriteLine("2.潛水配重帶 (TWD)460 {0} {1}", thing2, thing2 * 460);
                        Console.WriteLine("3.潛水作業指北針 (TWD)1100 {0} {1}", thing3, thing3 * 1100);
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.WriteLine("訂單商品 : ");
                        Console.WriteLine("商品 單價 數量 小計");
                        
                        if(thing1 != 0)
                        {
                            Console.WriteLine("潛水相機防丟繩 (TWD)199 {0} {1}", thing1, thing1 * 199);
                        }

                        if(thing2 != 0)
                        {
                            Console.WriteLine("潛水配重帶 (TWD)460 {0} {1}", thing2, thing2 * 460);
                        }

                        if(thing3 != 0)
                        {
                            Console.WriteLine("潛水作業指北針 (TWD)1100 {0} {1}", thing3, thing3 * 1100);
                        }
                        int sum = thing1 * 199 + thing2 * 460 + thing3 * 1100;
                        Console.WriteLine("總價 = {0}", sum);

                        Console.WriteLine();
                        break;

                    case 6:
                        break;

                    default:
                        Console.WriteLine("輸入錯誤!請重新輸入!");
                        Console.WriteLine();
                        break;
                }

            }

        }
    }
}
