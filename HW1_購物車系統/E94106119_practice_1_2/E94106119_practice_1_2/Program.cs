using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E94106119_practice_1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1 = 0;

            int[] thing = new int[] {0,0,0}; //購買初始數量
            int[] stock = new int[] {1,2,1}; //庫存
            double[] money = new double[] { 199, 460, 1100 }; //新台幣價格
            string money_name = "TWD";

            while (input1 != 7)
            {
                Console.WriteLine("(1)商品列表 (2)新增至購物車 (3)自購物車刪除 " +
                "(4)查看購物車 (5)結帳 (6)轉換幣值 (7)退出網站");
                Console.Write("輸入數字選擇功能 : ");
                input1 = int.Parse(Console.ReadLine());

                switch (input1)
                {
                    case 1:
                        Console.WriteLine("列表:");
                        Console.WriteLine("商品名稱 商品單價");
                        Console.WriteLine("1.潛水相機防丟繩 ({0}){1}", money_name, money[0]);
                        Console.WriteLine("2.潛水配重帶 ({0}){1}", money_name, money[1]);
                        Console.WriteLine("3.潛水作業指北針 ({0}){1}", money_name, money[2]);
                        Console.WriteLine();
                        break;

                    case 2:
                        int input2 = 0, input3 = 0;
                        Console.WriteLine("(1)潛水潛水相機防丟繩 (2)潛水配重帶 (3)潛水作業指北針");
                        Console.Write("輸入數字選擇商品 : ");
                        input2 = int.Parse(Console.ReadLine());
                        Console.Write("輸入數量 : ");
                        input3 = int.Parse(Console.ReadLine());

                        if (input2 == 1)
                        {
                            thing[0] += input3;
                        }
                        else if (input2 == 2)
                        {
                            thing[1] += input3;
                        }
                        else
                        {
                            thing[2] += input3;
                        }

                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("購物車內容:");
                        Console.WriteLine("商品 單價 數量 小計");
                        Console.WriteLine("1.潛水相機防丟繩 ({0}){1} {2} {3}", money_name, money[0] ,thing[0], thing[0] * money[0]);
                        Console.WriteLine("2.潛水配重帶 ({0}){1} {2} {3}", money_name, money[1], thing[1], thing[1] * money[1]);
                        Console.WriteLine("3.潛水作業指北針 ({0}){1} {2} {3}", money_name, money[2], thing[2], thing[2] * money[2]);

                        int input4 = 0, input5 = 0;
                        Console.Write("輸入數字選擇商品 : ");
                        input4 = int.Parse(Console.ReadLine());

                        if (input4 != 4)
                        {
                            Console.Write("輸入數量 : ");
                            input5 = int.Parse(Console.ReadLine());

                            switch (input4)
                            {
                                case 1:
                                    thing[0] -= input5;
                                    break;

                                case 2:
                                    thing[1] -= input5;
                                    break;

                                case 3:
                                    thing[2] -= input5;
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
                        Console.WriteLine("1.潛水相機防丟繩 ({0}){1} {2} {3}", money_name, money[0], thing[0], thing[0] * money[0]);
                        Console.WriteLine("2.潛水配重帶 ({0}){1} {2} {3}", money_name, money[1], thing[1], thing[1] * money[1]);
                        Console.WriteLine("3.潛水作業指北針 ({0}){1} {2} {3}", money_name, money[2], thing[2], thing[2] * money[2]);
                        Console.WriteLine();
                        break;

                    case 5:
                        //訂單商品顯示
                        Console.WriteLine("訂單商品 : ");
                        Console.WriteLine("商品 單價 數量 小計");
                        if (thing[0] != 0)
                        {
                            Console.WriteLine("潛水相機防丟繩 ({0}){1} {2} {3}", money_name, money[0], thing[0], thing[0] * money[0]);
                        }
                        if (thing[1] != 0)
                        {
                            Console.WriteLine("潛水配重帶 ({0}){1} {2} {3}", money_name, money[1], thing[1], thing[1] * money[1]);
                        }
                        if (thing[2] != 0)
                        {
                            Console.WriteLine("潛水作業指北針 ({0}){1} {2} {3}", money_name, money[2], thing[2], thing[2] * money[2]);
                        }
                        double sum = thing[0] * money[0] + thing[1] * money[1] + thing[2] * money[2];
                        Console.WriteLine("總價 = {0}", sum);

                        //開始結帳程序
                        string cinput1;
                        Console.Write("*是否要結帳(Y/N)*:");
                        cinput1 = Console.ReadLine();

                        if (cinput1 == "Y")
                        {
                            if ((thing[0] > stock[0]) || (thing[1] > stock[1])  || (thing[2] > stock[2]))
                            {
                                if (thing[0] > stock[0])
                                {
                                    Console.WriteLine("潛水相機防丟繩庫存不足!剩餘數量{0}!", stock[0]);
                                }
                                if (thing[1] > stock[1])
                                {
                                    Console.WriteLine("潛水配重帶庫存不足!剩餘數量{0}!", stock[1]);
                                }
                                if (thing[2]  > stock[2])
                                {
                                    Console.WriteLine("潛水作業指北針庫存不足!剩餘數量{0}!", stock[2]);
                                }
                                Console.WriteLine();
                                break;
                            }

                            else
                            {
                                string  discount;
                                int state;
                                Console.Write("*選擇結帳方式(1.線上支付 2.貨到付款):");
                                state = int.Parse(Console.ReadLine());
                                if((state != 1) && (state != 2)){
                                    Console.WriteLine("輸入錯誤!請重新輸入!");
                                    Console.WriteLine();
                                    break;
                                }
                                Console.Write("*折扣碼(若無折扣碼則輸入N):");
                                discount = Console.ReadLine();
                                if((discount != "1111") && (discount != "N"))
                                {
                                    Console.WriteLine("輸入錯誤!請重新輸入!");
                                    Console.WriteLine();
                                    break;
                                }
                                Console.WriteLine();

                                Console.WriteLine("訂單狀態:");
                                Console.WriteLine("商品 單價 數量 小計");
                                if (thing[0] != 0)
                                {
                                    Console.WriteLine("潛水相機防丟繩 ({0}){1} {2} {3}", money_name, money[0], thing[0], thing[0] * money[0]);
                                }
                                if (thing[1] != 0)
                                {
                                    Console.WriteLine("潛水配重帶 ({0}){1} {2} {3}", money_name, money[1], thing[1], thing[1] * money[1]);
                                }
                                if (thing[2] != 0)
                                {
                                    Console.WriteLine("潛水作業指北針 ({0}){1} {2} {3}", money_name, money[2], thing[2], thing[2] * money[2]);
                                }
                                Console.WriteLine("總價 = {0}", sum);

                                //折扣
                                if (discount == "1111")
                                {
                                    Console.WriteLine("總價(折扣後) = {0}", (sum * 0.95));
                                }
                                else { }

                                //狀態
                                if(state == 1)
                                {
                                    Console.WriteLine("狀態:已付款");
                                }
                                else
                                {
                                    Console.WriteLine("狀態:尚未付款");
                                }


                            }
                        }

                        else if(cinput1 == "N")
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("輸入錯誤!請重新輸入!");
                        }

                        Console.WriteLine();
                        break;
                    
                    case 6:
                        int choice;
                        Console.Write("選擇貨幣 1.TWD 2.USD 3.CNY 4.JPY :");
                        choice = int.Parse(Console.ReadLine());

                        if (choice == 1)
                        {
                            money_name = "TWD";
                            money[0] = 199;
                            money[1] = 460;
                            money[2] = 1100;
                        }
                        else if(choice == 2)
                        {
                            money_name = "USD";
                            money[0] = 6.169;
                            money[1] = 14.26;
                            money[2] = 34.1;
                        }
                        else if(choice == 3)
                        {
                            money_name = "CNY";
                            money[0] = 45.77;
                            money[1] = 105.8;
                            money[2] = 253;
                        }
                        else
                        {
                            money_name = "JPY";
                            money[0] = 913.41;
                            money[1] = 2111.4;
                            money[2] = 5049;
                        }
                        Console.WriteLine();
                        break;

                    case 7:
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
