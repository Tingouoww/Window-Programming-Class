using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E94106119_practice_3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------### 社員資料登記 ###----------------------------------");
            Console.WriteLine("新增社員資訊:\tregister\tname\tdepartment\tID");
            Console.WriteLine("以特定屬性查詢:\tsearch\t\ttag\tWant_search_string");
            Console.WriteLine("授予社員職位:\tentitle\t\tname\tdepartment\tID\tThat_title");
            Console.WriteLine("所有社員列表:\tcheck");
            Console.WriteLine("指令格式列表:\thelp");
            Console.WriteLine("離開此程式:\texit");

            ArrayList name = new ArrayList();
            ArrayList department = new ArrayList();
            ArrayList ID = new ArrayList();
            ArrayList level = new ArrayList();
            ArrayList title = new ArrayList();
            

            while (true)
            {
                Console.WriteLine("");
                Console.Write("");
                string input0;
                input0 = Console.ReadLine();
                string[] sp = input0.Split(' ');

                //新增社員
                if (sp[0] == "register")
                {
                    bool check_reg = true;
                    for (int i = 0; i < name.Count; i++)
                    {
                        if (((string)name[i] == sp[1]) && ((string)department[i] == sp[2]) && ((string)ID[i] == sp[3]))
                        {
                            check_reg = false;
                            if ((string)level[i] == "萌新社員")
                            {
                                level[i] = "資深社員";
                                Console.WriteLine("已晉升為資深社員");
                            }
                            else if ((string)level[i] == "資深社員")
                            {
                                level[i] = "永久社員";
                                Console.WriteLine("已晉升為永久社員");
                            }
                            else
                            {
                                Console.WriteLine("已經是永久社員了喔");
                            }
                            break;
                        }
                    }
                    if(check_reg == true)
                    {
                        string pattern1 = "^[A-Z]\\d{8}$";
                        string pattern2 = "^[A-Z]{2}\\d{7}$";
                        bool Match =( (Regex.IsMatch(sp[3], pattern1)) || (Regex.IsMatch(sp[3], pattern2)));
                        if (Match)
                        {
                            name.Add(sp[1]);
                            department.Add(sp[2]);
                            ID.Add(sp[3]);
                            level.Add("萌新社員");
                            title.Add("無");
                            Console.WriteLine("歡迎新社員!!");
                        }
                        else
                        {
                            Console.WriteLine("輸入的學號不符格式喔");
                        }
                        
                    }
                }

                //查詢社員
                else if (sp[0] == "search")
                {
                    if (sp[1] == "name")
                    {
                        bool check_name = false;
                        for(int i = 0; i < name.Count; i++)
                        {
                            if ((string)name[i] == sp[2])
                            {
                                check_name = true;
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", name[i], department[i], ID[i], level[i], title[i]);
                            }
                        }
                        if(check_name == false)
                        {
                            Console.WriteLine("\t找不到這個人ㄟ");
                        }
                    }
                    else if (sp[1] == "department")
                    {
                        bool check_depart = false;
                        for(int i = 0; i < department.Count; i++)
                        {
                            if ((string)department[i] == sp[2])
                            {
                                check_depart = true;
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", name[i], department[i], ID[i], level[i], title[i]);
                            }
                        }
                        if(check_depart == false)
                        {
                            Console.WriteLine("\t找不到這個系的人ㄟ");
                        }
                    }
                    else if (sp[1] == "ID")
                    {
                        bool check_ID = false;
                        for(int i = 0; i  < ID.Count; i++)
                        {
                            if ((string)ID[i] == sp[2])
                            {
                                check_ID = true;
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", name[i], department[i], ID[i], level[i], title[i]);
                            }
                        }
                        if(check_ID == false)
                        {
                            Console.WriteLine("\t找不到這個學號的人ㄟ");
                        }
                    }
                    else if (sp[1] == "level")
                    {
                        if ((sp[2] != "萌新社員") && (sp[2] != "資深社員") && (sp[2] != "永久社員"))
                        {
                            Console.WriteLine("\t找不到這個等級的人ㄟ(社員等級只有「萌新」、「資深」或「永久」喔!)");
                        }
                        else
                        {
                            bool check_level = false;
                            for (int i = 0; i < level.Count; i++)
                            {
                                if ((string)level[i] == sp[2])
                                {
                                    check_level = true;
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", name[i], department[i], ID[i], level[i], title[i]);
                                }
                            }
                            if (check_level == false)
                            {
                                Console.WriteLine("\t找不到這個等級的人ㄟ");
                            }
                        }
                    }
                    else if (sp[1] == "title")
                    {
                        bool check_title = false;
                        for(int i = 0; i < title.Count; i++)
                        {
                            if ((string)title[i] == sp[2])
                            {
                                check_title = true;
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", name[i], department[i], ID[i], level[i], title[i]);
                            }
                        }
                        if(check_title == false)
                        {
                            Console.WriteLine("\t找不到這個職務的人ㄟ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t不存在這個功能,有疑慮請打help");
                    }
                }

                //建立職務
                else if (sp[0] == "entitle")
                {
                    bool check1 = false;
                    for(int i = 0; i < name.Count; i++)
                    {
                        if ((sp[1] == (string)name[i]) && (sp[2] == (string)department[i]) && (sp[3] == (string)ID[i]))
                        {
                            check1 = true;      
                            bool boss1 = sp[4].Contains("社長"); //判斷是否想將某人晉升社長
                            //若想將某人晉升為社長，則先判斷是否有人已經是社長
                            if (boss1)
                            {
                                int a = 0; //a = 0尚無找到已經是社長的人
                                for (int m = 0; m < name.Count; m++)
                                {
                                    bool boss2 = ((string)title[m]).Contains("社長"); //判斷是否有人已經是社長
                                    if (boss2)
                                    {
                                        if(m == i)
                                        {
                                            a = 1;
                                            Console.WriteLine($"\t{name[m]}本來就是社長了!");
                                            break;
                                        }
                                        else
                                        {
                                            a = 1; //找到已經是社長的人
                                            Console.WriteLine($"\t我們的社長只有{name[m]}一個人，你不要想篡位!");
                                            break;
                                        }
                                    }
                                }
                                //a=0表示沒有找到已經是社長的人
                                if(a == 0)
                                {
                                    title[i] = sp[4];
                                    Console.WriteLine($"\t{sp[1]}已晉升為{sp[4]}!");
                                }
                            }
                            else
                            {
                                //若沒有要將這個人變成社長，則判斷他是不是早就是這個職務
                                if (sp[4] == (string)title[i])
                                {
                                    Console.WriteLine($"\t{sp[1]}本來就是{sp[4]}了");
                                }
                                else
                                {
                                    title[i] = sp[4];
                                    Console.WriteLine($"\t{sp[1]}已晉升為{sp[4]}!");
                                }
                            }
                        }
                    }
                    if(check1 == false)
                    {
                        Console.WriteLine("\t找不到這個人ㄟ");
                    }
                }

                //印出所有社員資訊
                else if (sp[0] == "check")
                {
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    for(int i = 0; i < name.Count; i++)
                    {
                        Console.WriteLine($"{name[i]}\t{department[i]}\t{ID[i]}\t{level[i]}\t{title[i]}");
                    }
                    Console.WriteLine("------------------------------------------------------------------------------------");
                }

                //幫助
                else if (sp[0] == "help")
                {
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine("新增社員資訊:\tregister\tname\tdepartment\tID");
                    Console.WriteLine("以特定屬性查詢:\tsearch\t\ttag\tWant_search_string");
                    Console.WriteLine("授予社員職位:\tentitle\t\tname\tdepartment\tID\tThat_title");
                    Console.WriteLine("所有社員列表:\tcheck");
                    Console.WriteLine("指令格式列表:\thelp");
                    Console.WriteLine("離開此程式:\texit");
                    Console.WriteLine("------------------------------------------------------------------------------------");
                }

                //離開程式
                else if (sp[0] == "exit")
                {
                    break;
                }

                //無此功能
                else
                {
                    Console.WriteLine("\t不存在該功能，有疑慮請打help");
                }
             }
            
           Console.ReadKey();
        }
    }
}
