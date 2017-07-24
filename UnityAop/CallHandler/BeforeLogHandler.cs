using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.InterceptionExtension;
using Model;

namespace UnityAop.CallHandler
{
    public class BeforeLogHandler : Microsoft.Practices.Unity.InterceptionExtension.ICallHandler
    {
        public int Order
        {
            get;
            set;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            UserMatch user = input.Inputs[0] as UserMatch;
            string message = $"ID:{user.Id},Accout:{user.Account},Email:{user.Email}";
            Console.WriteLine($"插入前日志：{message},发生时间：{DateTime.Now}");


            return getNext()(input, getNext);
        }
    }
}
