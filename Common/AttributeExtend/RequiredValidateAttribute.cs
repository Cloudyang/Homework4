using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredValidateAttribute : AbstractValidateAttribute
    {
        public override bool Validate<T>(T value)
        {
            return (value != null
                && !string.IsNullOrWhiteSpace(value.ToString()));
        }
    }
}