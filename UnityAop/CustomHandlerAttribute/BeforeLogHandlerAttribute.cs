using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using UnityAop.CallHandler;

namespace UnityAop.CustomHandlerAttribute
{
    public class BeforeLogHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new BeforeLogHandler() { Order = this.Order };
        }
    }
}
