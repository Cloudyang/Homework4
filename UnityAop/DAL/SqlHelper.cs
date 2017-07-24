using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityAop.Interface;
using Model;
using UnityAop.CustomHandlerAttribute;

namespace UnityAop.DAL
{
    [ValidateHandler(Order = 1)]
    [BeforeLogHandler(Order = 2)]
    [AfterLogHandler(Order = 3)]
    public class SqlHelper : IDBHelper
    {
        public void Insert<T>(T t)
        {
            Console.WriteLine($"数据成功插入:{t.ToString()}");
        }
    }
}
