namespace LB3;

public class Polynomial
{
    public List<int> Coefficients { get; set; }
    private int[] _array;

    public Polynomial(int[,] coefficients, int numberOfCollection, int CountOfCoeficients)
    {
        _array = new int[CountOfCoeficients];
        Coefficients = new List<int>();
        for (int i = 0; i < CountOfCoeficients; i++)
        {
            _array[i] = coefficients[numberOfCollection, i];
        }

        Coefficients.AddRange(_array);
    }
    public Polynomial(List<int> newPolynomial)
    {
        Coefficients = new List<int>();
        Coefficients.AddRange(newPolynomial);
    }
    public Polynomial()
    {
        Coefficients = new List<int>();
    }

    public string ShowPolynomial()
    {
        string polynominal = null;
        for (int i = 0; i < Coefficients.Count; i++)
        {
            if (i == 0)
                polynominal += $"{Coefficients[i]}";
            else if (i == 1)
                polynominal += $"+({Coefficients[i]}x)";
            else
                polynominal += $"+({Coefficients[i]}x^{i})";
        }

        return polynominal;
    }
    
    public double SolvePolynomial(double x)
    {
        double polynominal = 0;
        for (int i = 0; i < Coefficients.Count; i++)
        {
            if (i == 0)
                polynominal += Coefficients[i];
            else if (i == 1)
                polynominal += Coefficients[i] * x;
            else
                polynominal += Coefficients[i] * Math.Pow(x, i);
        }

        return polynominal;
    }

    public Polynomial AddPolynomials(List<int> polynomial2)
    {
        List<int> newPolynomial = new List<int>();
        int[] values = new int[Coefficients.Count];
        for (int i = 0; i < Coefficients.Count; i++)
        {
            values[i] = Coefficients[i] + polynomial2[i];
        }
        newPolynomial.AddRange(values);
        return new Polynomial(newPolynomial);
    }
    public Polynomial SubtractPolynomials(List<int> polynomial2)
    {
        List<int> newPolynomial = new List<int>();
        int[] values = new int[Coefficients.Count];
        for (int i = 0; i < Coefficients.Count; i++)
        {
            values[i] = Coefficients[i] - polynomial2[i];
        }
        newPolynomial.AddRange(values);
        return new Polynomial(newPolynomial);
    }
    public Polynomial MultiplyPolynomials(List<int> polynomial2)
    {
        List<int> newPolynomial = new List<int>();
        int[] values = new int[Coefficients.Count];
        for (int i = 0; i < Coefficients.Count; i++)
        {
            values[i] = Coefficients[i] * polynomial2[i];
        }
        newPolynomial.AddRange(values);
        return new Polynomial(newPolynomial);
    }
    
}