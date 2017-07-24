using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using UnityAop.Interface;
using Model;
using UnityAop.DAL;

namespace UnityAop
{
    /// <summary>
    /// 参考课程内容
    /// </summary>
    public class UnityAOP 
    {
        public static void Show(UserMatch user)
        {
            IUnityContainer container = new UnityContainer();//声明一个容器
            container.RegisterType<IDBHelper, SqlHelper>();////声明SqlHelper并注册IDBHelper
            IDBHelper dbHelper = container.Resolve<IDBHelper>();
         //   dbHelper.Insert(user);//调用

            container.AddNewExtension<Interception>().Configure<Interception>()
                .SetInterceptorFor<IDBHelper>(new InterfaceInterceptor());

            IDBHelper dbHelperWithIsVaild = container.Resolve<IDBHelper>();
            Console.WriteLine($"==============={user.Account}==如下运行通过UnityAop带检验================");
            dbHelperWithIsVaild.Insert(user);
        }
    }

    
}
