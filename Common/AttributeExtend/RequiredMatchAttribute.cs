using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredMatchAttribute : Attribute
    {
        public override bool Match(object value)
        {
            return (value != null
                && !string.IsNullOrWhiteSpace(value.ToString()));
        }
    }
}