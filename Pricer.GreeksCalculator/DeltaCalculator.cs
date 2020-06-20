namespace Pricer.GreeksCalculator
{
    public class BlackScholesCalculator
    {
        public decimal S { get; }  //Underlying Price($$$ per share)
        public decimal X { get; } //X = strike price($$$ per share)
        public decimal Sigma { get; } //σ = volatility(% p.a.)
        public decimal R { get; } //r = continuously compounded risk-free interest rate(% p.a.)
        public decimal Q { get; } //q = continuously compounded dividend yield(% p.a.)
        public decimal T { get; } //t = time to expiration(% of year)

        public BlackScholesCalculator(decimal s, decimal x, decimal sigma, decimal r, decimal q, decimal t)
        {
            S = s;
            X = x;
            Sigma = sigma;
            R = r;
            Q = q;
            T = t;
        }

        public decimal Calculate()
        {
            return 0;
        }
    }
}