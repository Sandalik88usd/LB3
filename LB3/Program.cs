using System.Text.Json;
using System.Text;

namespace LB3;

class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Menu menu = new Menu();
        menu.startMenu();

        Console.ReadKey();
    }
}

class Coefficient
{
    public int[,] Coefficients =
    {
        { 4, -6, 3, -8, 0, 5 },
        { -3, 7, 9, 2, 1, -5 },
        { 34, -1, 7, -9, 11, 2 },
        { 13, 9, -2, 7, 6, 0 },
        { 5, -7, 11, 9, 10, -5 }
    };


    public int CountOfColumns()
    {
        return Coefficients.GetLength(1);
    }

    public int CountOfRows()
    {
        return Coefficients.GetLength(0);
    }
}

class JsonFiles
{
    public async void SavePolynomialInFile(string name, List<Polynomial> polynomial)
    {
        using (FileStream file = new FileStream(name, FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync(file, polynomial);

            Console.WriteLine("Data has been saved to file\n");
        }
    }

    public List<Polynomial> ReadPolynomialsFromFile(string name, List<Polynomial> polynomials)
    {
        if (File.Exists(@"C:\Users\sanda\RiderProjects\Lab3\Lab3\LB3\LB3\bin\Debug\net6.0\" + name))
        {
            using (StreamReader reader = File.OpenText(name))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                return polynomials = JsonSerializer.Deserialize<List<Polynomial>>(reader.ReadToEnd(), options);
            }
        }
        else
        {
            Console.WriteLine("Такого файла не існує!");
            return polynomials = null;
        }
    }
}