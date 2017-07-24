using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.InterceptionExtension;
using Model;
using Common.AttributeExtend;

namespace UnityAop.CallHandler
{
    public class ValidateHandler : Microsoft.Practices.Unity.InterceptionExtension.ICallHandler
    {
        public int Order
        {
            get;
            set;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            UserMatch user = input.Inputs[0] as UserMatch;
            if (!user.IsMatch<UserMatch>())
            {
                Console.WriteLine($"显示如下错误信息，发生时间：{DateTime.Now}");
                StringBuilder sb = new StringBuilder();
                foreach (var item in user.MatchesWarnInfo<UserMatch>())
                {
                    var message = $"报错名：{item.Key},数据值：{item.Value}";
                    sb.AppendLine(message);
                    Console.WriteLine(message);
                }
                return input.CreateExceptionMethodReturn(new Exception(sb.ToString()));
            }
            return getNext()(input, getNext);
        }
    }
}
