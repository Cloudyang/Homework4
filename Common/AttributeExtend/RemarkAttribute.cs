using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Common.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class RemarkAttribute : Attribute
    {
        private string _Remark;
        public string Remark
        {
            get
            {
                return _Remark;
            }
        }

        public RemarkAttribute(string remark)
        {
            this._Remark = remark;
        }
    }

    public static class RemarkExtend
    {
        public static string GetRemark(this Enum eValue)
        {
            Type type = eValue.GetType();
            FieldInfo field = type.GetField(eValue.ToString());
            RemarkAttribute remarkAttribute = field.GetCustomAttribute(typeof(RemarkAttribute)) as RemarkAttribute;
            return remarkAttribute == null ? field.Name : remarkAttribute.Remark;
        }

        public static IList<string> GetALLRemark(this Enum eType)
        {
            IList<string> list = new List<string>();
            Type type = eType.GetType();

            foreach (var field in type.GetFields())
            {
                if (field.Name.Equals("value__")) continue; 
                RemarkAttribute remarkAttribute = field.GetCustomAttribute(typeof(RemarkAttribute)) as RemarkAttribute;
                list.Add(remarkAttribute == null ? field.Name : remarkAttribute.Remark);
            }
            return list;
        }

        public static void ShowList(this IList<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }            
        }
    }

    public enum People
    {
        /// <summary>
        /// 没有人
        /// </summary>
        Nobody,

        [Remark("中国人")]
        Chinese,

        [Remark("美国人")]
        American,

        [Remark("日本人")]
        Japanese,

        [Remark("印度人")]
        Indian,

        /// <summary>
        /// 某人
        /// </summary>
        Otherbody,
    }
}
