using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Common.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailMatchAttribute : Attribute
    {
        public override bool Match(object value)
        {
            return (value != null
                && Regex.IsMatch(value.ToString(), "^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$"));
        }
    }
}
