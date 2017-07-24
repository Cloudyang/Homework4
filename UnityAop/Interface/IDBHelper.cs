using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAop.Interface
{
    /// <summary>
    /// UnityAop基于特性方式实现简单配置，来个接口里面包含Insert，一个实现类完成Insert方法(不需要具体实现)；
    /// 然后通过接口增加特性，完成插入前日志、插入后日志,
    /// 大家试试多线程完成这个方法，AOP有没有影响
    /// </summary>
    public interface IDBHelper
    {
        void Insert<T>(T data);
    }
}
