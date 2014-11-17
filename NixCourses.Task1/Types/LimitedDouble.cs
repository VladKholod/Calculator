using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixCourses.Task1.Types
{
    public struct LimitedDouble
    {
        private readonly double _value;

        public const double Min_Value = -7d;
        public const double Max_Value = 36d;

        public double Value 
        {
            get { return _value; }
        }

        public LimitedDouble(double value)
        {
            ValidateValue(ref value);
            this._value = value;
        }

        private static void ValidateValue(ref double value) 
        {
            if (value < Min_Value)
            {
                value += Max_Value - Min_Value;
                ValidateValue(ref value);
            }

            if (value > Max_Value)
            {
                value += Min_Value - Max_Value;
                ValidateValue(ref value);
            }
        }


        #region implicit operators
        public static implicit operator LimitedDouble(double value) 
        {
            return new LimitedDouble(value);
        }

        public static implicit operator double(LimitedDouble value) 
        {
            return value.Value;
        }
        #endregion

        #region operatiors +,-,*,/,^
        public static LimitedDouble operator +(LimitedDouble ld1, LimitedDouble ld2) 
        {
            return new LimitedDouble(ld1.Value + ld2.Value);
        }

        public static LimitedDouble operator -(LimitedDouble ld1, LimitedDouble ld2)
        {
            return new LimitedDouble(ld1.Value - ld2.Value);
        }

        public static LimitedDouble operator *(LimitedDouble ld1, LimitedDouble ld2) 
        {
            return new LimitedDouble(ld1.Value * ld2.Value);
        }

        public static LimitedDouble operator /(LimitedDouble ld1, LimitedDouble ld2) 
        {
            return new LimitedDouble(ld1.Value / ld2.Value);
        }

        public static LimitedDouble operator ^(LimitedDouble ld1, LimitedDouble ld2) 
        {
            return new LimitedDouble(Math.Pow(ld1.Value, ld2.Value));
        }
        #endregion

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
