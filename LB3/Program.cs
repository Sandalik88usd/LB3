using System.Text.Json;
using System.Text;

namespace LB3;

class Program
{
    public static void Main(string[] args)
    {
        Coefficient coefficients = new Coefficient();
        Console.ReadKey();
    }
}

class Coefficient
{
    public List<List<int>> ListOfCoefficients = new List<List<int>>()
    {
        new List<int>() { 4, -6, 3, -8, 0, 5 },
        new List<int>() { -3, 7, 9, 2, 1, -5 },
        new List<int>() { 34, -1, 7, -9, 11, 2 },
        new List<int>() { 13, 9, -2, 7, 6, 0 },
        new List<int>() { 5, -7, 11, 9, 10, -5 }
    };


    public int CountOfColumns()
    {
        return ListOfCoefficients[0].Count;
    }

    public int CountOfRows()
    {
        return ListOfCoefficients.Count;

    }
}