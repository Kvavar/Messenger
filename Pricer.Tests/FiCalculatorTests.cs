using NUnit.Framework;
using Pricer.Math;
using math = System.Math;

namespace Pricer.Tests
{
    [TestFixture]
    public class FiCalculatorTests
    {
        private ICalculator _calculator;
        private const double AllowedDiff = 0.0005;

        [Test]
        public void NormalZeroTest()
        {
            _calculator = new FiCalculator(1.0, 0.0, -6.0);
            var granularity = 100000;
            var actual = _calculator.Calculate(0.0, granularity);

            var expected = 0.5;
            var diff = math.Abs((actual - expected) / expected);

            Assert.IsTrue(diff < AllowedDiff);
        }

        [Test]
        public void NormalInfinitiveTest()
        {
            _calculator = new FiCalculator(1.0, 0.0, -6.0);
            var granularity = 100000;
            var actual = _calculator.Calculate(10.0, granularity);

            var expected = 1.0;
            var diff = math.Abs((actual - expected) / expected);

            Assert.IsTrue(diff < AllowedDiff);
        }

        [Test]
        public void NormalNegativeInfinitiveTest()
        {
            _calculator = new FiCalculator(1.0, 0.0, -6.0);
            var granularity = 100000;
            var actual = _calculator.Calculate(-5.0, granularity);

            Assert.IsTrue(actual < AllowedDiff);
        }

        [Test]
        public void NormalLowerSigmaZeroTest()
        {
            _calculator = new FiCalculator(0.5, 0.0, -6.0);
            var granularity = 100000;
            var actual = _calculator.Calculate(0.0, granularity);

            var expected = 0.5;
            var diff = math.Abs((actual - expected) / expected);

            Assert.IsTrue(diff < AllowedDiff);
        }

        [Test]
        public void NormalHigherSigmaZeroTest()
        {
            _calculator = new FiCalculator(3.0, 0.0, -15.0);
            var granularity = 100000;
            var actual = _calculator.Calculate(0.0, granularity);

            var expected = 0.5;
            var diff = math.Abs((actual - expected) / expected);

            Assert.IsTrue(diff < AllowedDiff);
        }

        [Test]
        public void NormalHigherMuOneTest()
        {
            _calculator = new FiCalculator(1.0, 1.0, -6.0);
            var granularity = 100000;
            var actual = _calculator.Calculate(1.0, granularity);

            var expected = 0.5;
            var diff = math.Abs((actual - expected) / expected);

            Assert.IsTrue(diff < AllowedDiff);
        }
    }
}