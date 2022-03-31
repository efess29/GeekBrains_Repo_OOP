using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_Task2
{
    public class ComplexNumber
    {
        private double _realA;
        private double _realB;

        public double RealA
        {
            get
            {
                return _realA;
            }

            set
            {
                _realA = value;
            }
        }

        public double RealB
        {
            get
            {
                return _realB;
            }
            
            set
            {
                _realB = value;
            }
        }

        public ComplexNumber()
        {
            RealA = 0;
            RealB = 0;
        }

        public ComplexNumber(double A, double B)
        {
            RealA = A;
            RealB = B;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RealA);
            builder.Append(" + ");
            builder.Append(RealB);
            builder.Append('i');
            
            return builder.ToString();
        }

        public static bool operator ==(ComplexNumber n1, ComplexNumber n2)
        {
            return Equals(n1, n2);
        }

        public static bool operator !=(ComplexNumber n1, ComplexNumber n2)
        {
            return !(n1 == n2);
        }

        public static ComplexNumber operator +(ComplexNumber n1, ComplexNumber n2)
        {
            var A = n1.RealA + n2.RealA;
            var B = n1.RealB + n2.RealB;
            return new ComplexNumber(A, B);
        }

        public static ComplexNumber operator -(ComplexNumber n1, ComplexNumber n2)
        {
            var A = n1.RealA - n2.RealA;
            var B = n1.RealB - n2.RealB;
            return new ComplexNumber(A, B);
        }

        public static ComplexNumber operator *(ComplexNumber n1, ComplexNumber n2)
        {
            var A = n1.RealA * n2.RealA - n1.RealB * n2.RealB;
            var B = n1.RealA * n2.RealB + n1.RealB * n2.RealA;
            return new ComplexNumber(A, B);
        }
    }
}
