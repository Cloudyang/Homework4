using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Practices.Unity.InterceptionExtension;
using Model;

namespace UnityAop.CallHandler
{
    public class AfterLogHandler : ICallHandler
    {
        public int Order
        {
            get;
            set;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //先将getNext()(input, getNext)缓存，目的是执行这块，而后执行方法体内容
            IMethodReturn methodReturn = getNext()(input, getNext);
            Thread.Sleep(500);
            var user = input.Inputs["data"] as UserMatch;
            Console.WriteLine($"完成日志：{user.Account}用户插入成功 发生时间：{DateTime.Now}");
            return methodReturn;
        }
    }

}
