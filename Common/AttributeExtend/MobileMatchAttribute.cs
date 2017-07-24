using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Common.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MobileMatchAttribute : Attribute
    {
        public override bool Match(object value)
        {
            return (value != null
                && Regex.IsMatch(value.ToString(), "^[1][358][0-9]{9}$"));
        }
    }
}
