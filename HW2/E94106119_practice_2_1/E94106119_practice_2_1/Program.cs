using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace E94106119_practice_2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] class_ = new string[0];
            int[] score = new int[0];
            int[] credit = new int[0];

            string pattern = @"^.{2}-.{3}$"; //定義科目代碼格式xx-xxx

            while (true)
            {
                string input0;
                Console.WriteLine("## 成績計算器 ##");
                Console.WriteLine("1. 新增科目(create)");
                Console.WriteLine("2. 刪除科目(delete)");
                Console.WriteLine("3. 更新科目(update)");
                Console.WriteLine("4. 列印成績單(print)");
                Console.WriteLine("5. 退出選單(exit)");
                Console.Write("輸入要執行的指令操作: ");
                input0 = Console.ReadLine();
                string[] subs = input0.Split(' ');
                int length = subs.Length;

                bool match_pattern = false;
                if (length > 1) {
                    match_pattern = Regex.IsMatch(subs[1], pattern); //確認科目代碼格式
                }
                //新增科目
                if ((subs[0] == "create") && (match_pattern == true) && (length == 4))
                {
                    if ((int.TryParse(subs[2], out int value_0)) && (int.TryParse(subs[3], out int value_1))){
                        if ((value_0 >= 0) && (value_0 <= 100)) 
                        {
                            if((value_1 >= 0) && (value_1 <= 10))
                            {
                                int check = 0;
                                foreach(string s in class_) {
                                    if (s == subs[1])
                                    {
                                        check ++;
                                        break;
                                    }
                                }

                                if(check == 1)
                                {
                                    Console.WriteLine("科目已存在");
                                }
                                else
                                {
                                    int check0 = 0;
                                    for (int i = 0; i <= class_.Length - 1; i++)
                                    {
                                        if (class_[i] == null)
                                        {
                                            check0++;
                                            class_[i] = subs[1];
                                            score[i] = value_0;
                                            credit[i] = value_1;
                                            break;
                                        }
                                    }
                                    if (check0 == 0)
                                    {
                                        Array.Resize(ref score, score.Length + 1);
                                        score[score.Length - 1] = value_0;
                                        Array.Resize(ref credit, credit.Length + 1);
                                        credit[credit.Length - 1] = value_1;
                                        Array.Resize(ref class_, class_.Length + 1);
                                        class_[class_.Length - 1] = subs[1];
                                    }
                                    Console.WriteLine("科目已新增");
                                }
                            }
                            else
                            {
                                Console.WriteLine("學分數異常! 請重新輸入!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("成績分數異常! 請重新輸入!");
                        }
                    }

                    else
                    {
                        Console.WriteLine("指令格式不符! 請重新輸入!");
                    }
                }

                //刪除科目
                else if ((subs[0] == "delete") && (match_pattern == true) && (length == 2))
                {
                    int check1 = 0;
                    foreach(string s in class_) { 
                        if (s == subs[1])
                        {
                            check1++;
                            break;
                        }
                    }
                    if(check1 == 0)
                    {
                        Console.WriteLine("科目不存在");
                    }
                    else
                    {
                        int index = Array.IndexOf(class_, subs[1]);
                        class_[index] = null;
                        score[index] = -1;
                        credit[index] = -1;
                        Console.WriteLine("科目已刪除");
                    }
                }

                //更新科目
                else if ((subs[0] == "update") && (match_pattern == true) && (length == 4))
                {
                    if ((int.TryParse(subs[2], out int value_2)) && (int.TryParse(subs[3], out int value_3)))
                    {
                        if ((value_2 >= 0) && (value_2 <= 100))
                        {
                            if((value_3 >= 0) && (value_3 <= 10))
                            {
                                int check2 = 0;
                                foreach(string a in class_)
                                {
                                    if(a == subs[1])
                                    {
                                        check2++;
                                        int index0 = Array.IndexOf(class_, subs[1]);
                                        score[index0] = value_2;
                                        credit[index0] = value_3;
                                        Console.WriteLine("科目已更新");
                                        break;
                                    }
                                }
                                if(check2 == 0){
                                    Console.WriteLine("科目不存在");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("學分數異常! 請重新輸入!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("成績分數異常! 請重新輸入!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("指令格式不符! 請重新輸入!");
                    }
                }

                //列印成績單
                else if ((subs[0] == "print") && (length == 1))
                {
                    Console.WriteLine();
                    Console.WriteLine("我的成績單:");
                    Console.WriteLine("編號  科目代碼    分數    等第    學分數");

                    int[] score_copy = new int[score.Length];
                    Array.Copy(score, score_copy, score.Length);

                    Array.Sort(score, class_ );
                    Array.Sort(score_copy, credit);
                    Array.Reverse(score);
                    Array.Reverse(class_);
                    Array.Reverse(credit);
                    int number = 1;
                    int total_score = 0;
                    int total_credit = 0;
                    int indeed_credit = 0;
                    double gpa_new = 0;
                    double gpa_old = 0;
                    for (int i = 0; i <= class_.Length-1 ; i++)
                    {
                        
                        if (class_[i] != null)
                        { 
                            total_score += score[i] * credit[i];
                            total_credit += credit[i];
                            
                            string grade;
                            if ((score[i] <= 100) && (score[i] >= 90))
                            {
                                grade = "A+";
                                gpa_new += 4.3 * credit[i];
                                gpa_old += 4 * credit[i];
                                indeed_credit += credit[i];
                            }
                            else if ((score[i] <= 89) && (score[i] >= 85))
                            {
                                grade = "A";
                                gpa_new += 4.0 * credit[i];
                                gpa_old += 4 * credit[i];
                                indeed_credit += credit[i];
                            }
                            else if ((score[i] <= 84) && (score[i] >= 80))
                            {
                                grade = "A-";
                                gpa_new += 3.7 * credit[i];
                                gpa_old += 4.0 * credit[i];
                                indeed_credit += credit[i];
                            }
                            else if ((score[i] <= 79) && (score[i] >= 77))
                            {
                                grade = "B+";
                                gpa_new += 3.3 * credit[i];
                                gpa_old += 3.0 * credit[i];
                                indeed_credit += credit[i];
                            }
                            else if ((score[i] <= 76) && (score[i] >= 73))
                            {
                                grade = "B";
                                gpa_new += 3.0 * credit[i];
                                gpa_old += 3.0 * credit[i];
                                indeed_credit += credit[i];
                            }
                            else if ((score[i] <= 72) && (score[i] >= 70))
                            {
                                grade = "B-";
                                gpa_new += 2.7 * credit[i];
                                gpa_old += 3.0 * credit[i];
                                indeed_credit += credit[i];
                            }
                            else if ((score[i] <= 69) && (score[i] >= 67))
                            {
                                grade = "C+";
                                gpa_new += 2.3 * credit[i];
                                gpa_old += 2.0 * credit[i];
                                indeed_credit += credit[i];
                            }
                            else if ((score[i] <= 66) && (score[i] >= 63))
                            {
                                grade = "C";
                                gpa_new += 2.0 * credit[i];
                                gpa_old += 2.0 * credit[i];
                                indeed_credit += credit[i];
                            }
                            else if ((score[i] <= 62) && (score[i] >= 60))
                            {
                                grade = "C-";
                                gpa_new += 1.7 * credit[i];
                                gpa_old += 2.0 * credit[i];
                                indeed_credit += credit[i];
                            }
                            else if ((score[i] <=59) && (score[i] >= 50))
                            {
                                grade = "F";
                                gpa_new += 0;
                                gpa_old += 1.0 * credit[i];
                                indeed_credit += 0;
                            }
                            else
                            {
                                grade = "F";
                                gpa_new += 0;
                                gpa_old += 0;
                                indeed_credit += 0;
                            }

                            Console.WriteLine($"{number}      {class_[i]}\t   {score[i]}\t   {grade}\t    {credit[i]}");
                            number++;
                        }
                    }

                    if(total_credit != 0)
                    {
                        double ave_score = Math.Round(((double)total_score / total_credit) , 2);
                        double ave_old_gpa = Math.Round((gpa_old / total_credit), 1);
                        double ave_new_gpa = Math.Round((gpa_new / total_credit), 1);
                        string format_score = ave_score.ToString("F2");
                        string format_old = ave_old_gpa.ToString("F1");
                        string format_new = ave_new_gpa.ToString("F1");
                        Console.WriteLine("總平均: {0}", format_score);
                        Console.WriteLine($"GPA: {format_old}/4.0 (舊制), {format_new}/4.3 (新制)");
                        Console.WriteLine($"實拿學分數/總學分數: {indeed_credit}/{total_credit}");
                    }
                    else
                    {
                        Console.WriteLine("總平均: 0.00");
                        Console.WriteLine($"GPA: 0.0/4.0 (舊制), 0.0/4.3 (新制)");
                        Console.WriteLine($"實拿學分數/總學分數: 0/0");
                    }
                    
                    
                }

                //退出選單
                else if ((subs[0] == "exit") && (length == 1))
                {
                    Console.WriteLine("離開成績計算器");
                    break;
                }

                else
                {
                    Console.WriteLine("指令格式不符! 請重新輸入!");
                }

                Console.WriteLine();
            }
            Console.Read();

            
        }
    }
}
