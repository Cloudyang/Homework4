using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Common.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class AbstractValidateAttribute : Attribute
    {
        public abstract bool Validate<T>(T value);
    }

    public static class ValidateExtend
    {
        #region 模仿老师课堂教程实现方式
        public static bool IsValidate<T>(this T t)
        {
            string warnInfo = string.Empty;
            return IsValidate<T>(t, out warnInfo);
        }

        public static bool IsValidate<T>(this T t,out string warnInfo)
        {
            Type type = typeof(T);
            warnInfo = string.Empty;
            foreach (var property in type.GetProperties())
            {
                //方法1实现参照课程Save<T>
                var oAttributeArray = property.GetCustomAttributes(typeof(AbstractValidateAttribute), true);
                //方法2实现参照Attribute静态方法GetCustomAttributes
                //var oAttributeArray = Attribute.GetCustomAttributes(property);
                foreach (var oAttribute in oAttributeArray)
                {
                    AbstractValidateAttribute ValidateAttribute = oAttribute as AbstractValidateAttribute;
                    if (ValidateAttribute != null)
                    {
                        if (!ValidateAttribute.Validate(property.GetValue(t)))
                        {
                            warnInfo = property.Name;
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        #region 学习Attribute类发现有自带虚方法Match
        public static bool IsMatch<T>(this T t)
        {
            string warnInfo = string.Empty;
            return IsMatch<T>(t, out warnInfo);
        }

        public static bool IsMatch<T>(this T t, out string warnInfo)
        {
            Type type = typeof(T);
            warnInfo = string.Empty;
            foreach (var property in type.GetProperties())
            {
                //方法2实现参照Attribute静态方法GetCustomAttributes
                var oAttributeArray = Attribute.GetCustomAttributes(property);
                foreach (var oAttribute in oAttributeArray)
                {
                    if (!oAttribute.Match(property.GetValue(t)))
                    {
                        warnInfo = property.Name;
                        return false;
                    }
                }
            }
            return true;
        }

        public static Dictionary<string,object> MatchesWarnInfo<T>(this T t)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            Type type = typeof(T);
            foreach (var property in type.GetProperties())
            {
                //方法2实现参照Attribute静态方法GetCustomAttributes
                var oAttributeArray = Attribute.GetCustomAttributes(property);
                foreach (var oAttribute in oAttributeArray)
                {
                    var value = property.GetValue(t);
                    if (!oAttribute.Match(value))
                    {
                        dict.Add(property.Name, value);
                    }
                }
            }
            return dict;
        }
        #endregion
    }
}
