using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Common.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailValidateAttribute : AbstractValidateAttribute
    {
        public override bool Validate<T>(T value)
        {
            return (value != null
                && Regex.IsMatch(value.ToString(), "^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$"));
        }
    }
}
