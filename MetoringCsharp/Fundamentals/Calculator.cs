using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Fundamentals
{
    public class Calculator
    {
        private double _valueFirst;
        private double _valueSecond;
        private double _result;

        public double ValueFirst
        {
            get
            {
                return _valueFirst;
            }
            set
            {
                _valueFirst = value;
            }
        }
        public double ValueSecond
        {
            get
            {
                return _valueSecond;
            }
            set
            {
                _valueSecond = value;
            }
        }
        public double Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        public Calculator(double valueFirst, double valueSecond)
        {
            ValueFirst = valueFirst;
            ValueSecond = valueSecond;
            Result = valueFirst + valueSecond;
        }

        public Calculator()
        {

        }

        public double Sum(double valueFirst, double valueSecond)
        {
            ValueFirst = valueFirst;
            ValueSecond = valueSecond;

            Result = ValueFirst + ValueSecond;

            return Result;
        }

        public double Sum()
        {
            Result = ValueFirst + ValueSecond;
            return Result;
        }

        public double Subtract(double valueFirst, double valueSecond)
        {
            ValueFirst = valueFirst;
            ValueSecond = valueSecond;

            Result = ValueFirst - ValueSecond;

            return Result;
        }

        public double Subtract()
        {
            Result = ValueFirst - ValueSecond;

            return Result;
        }

        public double Multiplication(double valueFirst, double valueSecond)
        {
            ValueFirst = valueFirst;
            ValueSecond = valueSecond;

            Result = ValueFirst * ValueSecond;

            return Result;
        }

        public double Multiplication()
        {
            Result = ValueFirst * ValueSecond;

            return Result;
        }

        public double Division(double valueFirst, double valueSecond)
        {
            ValueFirst = valueFirst;
            ValueSecond = valueSecond;

            Result = ValueFirst / ValueSecond;

            return Result;
        }

        public double Division()
        {
            Result = ValueFirst / ValueSecond;

            return Result;
        }

    }
}
