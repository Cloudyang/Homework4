using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.AttributeExtend;
using Model;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(People.Chinese.GetRemark());

            People.Otherbody.GetALLRemark().ShowList();

            #region 测试模仿课程方法
            {
                User user1 = new User()
                {
                    Id = 963,
                    Account = "LaoYang",
                    Email = "2645660419@qq.com",
                    Mobile = "13566626562"
                };
                string errorName;
                Console.WriteLine($"状态{user1.IsValidate(out errorName)}，报错属性名：{errorName}");
            }
            #endregion

            List<UserMatch> users = new List<UserMatch>();
            #region 学习Attribute类发现有自带虚方法Match
            {
                UserMatch user1 = new UserMatch()
                {
                    Id = 963,
                    Account = "yang",
                    Email = "#2645660419@qq.com",
                    Mobile = "13566625632错误"
                };
                users.Add(user1);
                string errorName;
                Console.WriteLine($"状态{user1.IsMatch(out errorName)}，报错属性名：{errorName}");

                foreach (var kvEnity in user1.MatchesWarnInfo())
                {
                    Console.WriteLine($"报错名：{kvEnity.Key},报错值：{kvEnity.Value}");
                }
            }
            #endregion

            #region UnityAop实现Parallel并发调用
            UserMatch user2 = new UserMatch()
            {
                Id = 963,
                Account = "loayang",
                Email = "2645660419@qq.com",
                Mobile = "13566625632"
            };

            users.Add(user2);
            Console.WriteLine("***********************演示UnityAOP多线程并发***************************");
            try
            {
                Parallel.ForEach(users, user =>
                {
                    UnityAop.UnityAOP.Show(user);
                });
            }
            catch (AggregateException aex)
            {
                Console.WriteLine("################捕获到异常反馈如下：##################");
                foreach (var iex in aex.InnerExceptions)
                {
                    Console.WriteLine(iex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            Console.ReadKey();
        }

    }
}
