using System;
using math = System.Math;

namespace Pricer.Math
{
    public class FiCalculator : ICalculator
    {
        private readonly double _start;
        private readonly Func<double, double> _normal;

        public FiCalculator(double sigma, double mu, double start)
        {
            _start = start;
            _normal = x => 1 / (sigma * math.Sqrt(2 * math.PI)) * math.Pow(math.E, -0.5 * math.Pow((x - mu) / sigma, 2));
        }

        public double Calculate(double x, int granularity)
        {
            if (x <= _start)
            {
                throw new InvalidOperationException($"Argument {nameof(x)} should be greater than {nameof(_start)}.");
            }

            var step = (x - _start) / granularity;
            var result = 0.5 * step * (_normal(_start) + _normal(x));
            var i = _start + step;

            while (i < x)
            {
                result += _normal(i) * step;
                i += step;
            }

            return result;
        }
    }
}