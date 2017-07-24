using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LengthValidateAttribute : AbstractValidateAttribute
    {
        private int _Min = 0;
        private int _Max = 0;

        public LengthValidateAttribute(int min, int max=0)
        {
            this._Min = min;
            this._Max = max;
        }

        public override bool Validate<T>(T value)
        {
            var length = value.ToString().Length;
            return value != null
                && length >= _Min
                && (_Max == 0 || length <= _Max); //如果max=0 代表没有限制
        }
    }
}