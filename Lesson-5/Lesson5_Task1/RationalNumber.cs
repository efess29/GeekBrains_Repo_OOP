using System;

namespace Lesson5_Task1
{
    public sealed class RationalNumber
    {
        private int _num;
        private int _denum;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RationalNumber"/>
        /// </summary>
        public RationalNumber() : this(0, 1)
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RationalNumber"/> с параметрами
        /// </summary>
        /// <param name="num"></param>
        /// <param name="denum"></param>
        public RationalNumber(int num, int denum)
        {
            _num = num;
            _denum = denum;
        }


        public int Num => _num;

        public int Denum => _denum;

        public static RationalNumber operator ++(RationalNumber num)
        {
            return new RationalNumber(num._num + num._denum, num._denum);
        }

        public static RationalNumber operator --(RationalNumber num)
        {
            return new RationalNumber(num._num - num._denum, num._denum);
        }

        public static RationalNumber operator -(RationalNumber number1, RationalNumber number2)
        {
            int lcm = 1;

            if (number1._denum != number2._denum)
            {
                lcm = CalculateLeastCommonMultiple(number1._denum, number2._denum);
            }

            RationalNumber result = new RationalNumber(number1._num * (lcm / number1._denum) - number2._num * (lcm / number2._denum), lcm);

            TrySimplify(result);

            return result;
        }

        public static RationalNumber operator +(RationalNumber number1, RationalNumber number2)
        {
            int lcm = 1;
            if (number1._denum != number2._denum)
            {
                lcm = CalculateLeastCommonMultiple(number1._denum, number2._denum);
            }

            RationalNumber result = new RationalNumber(number1._num * (lcm / number1._denum) + number2._num * (lcm / number2._denum), lcm);

            TrySimplify(result);

            return result;
        }

        public static RationalNumber operator *(RationalNumber multiplier1, RationalNumber multiplier2)
        {
            RationalNumber result = new RationalNumber(multiplier1._num * multiplier2._num, multiplier1._denum * multiplier2._denum);

            int gcd = CalculateGreatestCommonDiv(result._num, result._denum);
            
            while (gcd > 1)
            {
                result._num /= gcd;
                result._denum /= gcd;
                gcd = CalculateGreatestCommonDiv(result._num, result._denum);
            }

            return result;
        }

        public static RationalNumber operator /(RationalNumber number1, RationalNumber number2)
        {
            int temp = number2._denum;
            number2._denum = number2._num;
            number2._num = temp;
            
            if (number2._denum < 0)
            {
                number2._denum *= -1;
                number2._num *= -1;
            }

            return number1 * number2;
        }

        public static bool operator ==(RationalNumber number1, RationalNumber number2)
        {
            if (number1._denum != number2._denum)
            {
                int lcm = CalculateLeastCommonMultiple(number1._denum, number2._denum);
                number1._num *= (lcm / number1._denum);
                number2._num *= (lcm / number2._denum);
            }

            return number1._num == number2._num;
        }

        public static bool operator !=(RationalNumber number1, RationalNumber number2)
        {
            if (number1._denum != number2._denum)
            {
                int lcm = CalculateLeastCommonMultiple(number1._denum, number2._denum);
                number1._num *= (lcm / number1._denum);
                number2._num *= (lcm / number2._denum);
            }

            return number1._num != number2._num;
        }

        public static bool operator <(RationalNumber number1, RationalNumber number2)
        {
            if (number1._denum != number2._denum)
            {
                int lcm = CalculateLeastCommonMultiple(number1._denum, number2._denum);
                number1._num *= (lcm / number1._denum);
                number2._num *= (lcm / number2._denum);
            }

            return number1._num < number2._num;
        }

        public static bool operator >(RationalNumber number1, RationalNumber number2)
        {
            if (number1._denum != number2._denum)
            {
                int lcm = CalculateLeastCommonMultiple(number1._denum, number2._denum);
                number1._num *= (lcm / number1._denum);
                number2._num *= (lcm / number2._denum);
            }

            return number1._num > number2._num;
        }

        public static bool operator <=(RationalNumber number1, RationalNumber number2)
        {
            if (number1._denum != number2._denum)
            {
                int lcm = CalculateLeastCommonMultiple(number1._denum, number2._denum);
                number1._num *= (lcm / number1._denum);
                number2._num *= (lcm / number2._denum);
            }

            return number1._num <= number2._num;
        }

        public static bool operator >=(RationalNumber number1, RationalNumber number2)
        {
            if (number1._denum != number2._denum)
            {
                int lcm = CalculateLeastCommonMultiple(number1._denum, number2._denum);
                number1._num *= (lcm / number1._denum);
                number2._num *= (lcm / number2._denum);
            }

            return number1._num >= number2._num;
        }

        public static explicit operator int(RationalNumber number) => number._num / number._denum;

        public static explicit operator float(RationalNumber number) => (float)number._num / number._denum;

        public static explicit operator double(RationalNumber number) => (double)number._num / number._denum;

        public static explicit operator decimal(RationalNumber number) => (decimal)number._num / number._denum;

        public static RationalNumber ConvertFrom(decimal value)
        {
            string[] temp = value.ToString().Split(',');
            
            if (temp.Length == 1)
            {
                return new RationalNumber((int)value, 1);
            }

            int scale = (int)Math.Pow(10, temp[1].Length);
            RationalNumber result = new RationalNumber((int)(value * scale), scale);
            TrySimplify(result);

            return result;
        }

        public bool Equals(RationalNumber number) => this == number;

        public override string ToString()
        {
            float result = (float)this;
            return result.ToString();
        }

        public override bool Equals(object obj) => Equals(obj as RationalNumber);

        public override int GetHashCode() => base.GetHashCode();

        private static void TrySimplify(RationalNumber number)
        {
            int gcd = CalculateGreatestCommonDiv(number._num, number._denum);

            while (gcd > 1)
            {
                number._num /= gcd;
                number._denum /= gcd;
                gcd = CalculateGreatestCommonDiv(number._num, number._denum);
            }
        }

        // =================================================================== //

        /// <summary>
        /// Представляет метод вычисления наибольшего общего делителя
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        public static int CalculateGreatestCommonDiv(int number1, int number2)
        {
            if (number2 < 0)
            {
                number2 = -number2;
            }

            if (number1 < 0)
            {
                number1 = -number1;
            }

            while (number2 > 0)
            {
                int temp = number2;
                number2 = number1 % number2;
                number1 = temp;
            }

            return number1;
        }

        /// <summary>
        /// Представляет метод вычисления наименьшего общего множителя
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        public static int CalculateLeastCommonMultiple(int number1, int number2)
        {
            return Math.Abs(number1 * number2) / CalculateGreatestCommonDiv(number1, number2);
        }
    }
}
