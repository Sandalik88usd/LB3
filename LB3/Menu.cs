using System.Runtime.CompilerServices;

namespace LB3;

public class Menu
{
    public void startMenu()
    {
        bool isWork = true;
        string name;
        int operation = 0;
        int numberFirstPolynomial;
        int numberSecondPolynomial;
        JsonFiles jsonFiles = new JsonFiles();
        Coefficient coefficients = new Coefficient();
        List<Polynomial> polynomial = new List<Polynomial>();
        List<int> secondPolynomial = new List<int>();
        for (int i = 0; i < coefficients.CountOfRows(); i++)
            polynomial.Add(new Polynomial(coefficients.Coefficients, i,
                coefficients.CountOfColumns()));

        while (isWork)
        {
            Console.WriteLine(
                "\nОберіть операцію:\n1 - Вивести многочлени в консоль\n2 - Обрахувати значення " +
                "многочленна\n3 - Створити новий многочлен додаванням\n4 - Створити новий многочлен " +
                "відніманням\n5 - Створити новий многочлен множенням\n6 - Зберегти многочлен\n7 -" +
                " Відкрити json файл та створити об'єкт класу\n8 - Вийти з програми\n");
            try
            {
                operation = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("\nВведене значення не є цілим числом: " + e.Message);
            }

            Console.WriteLine();

            switch (operation)
            {
                case 1:
                    ShowPolynomials(polynomial);
                    break;
                case 2:
                    Calculatepolynomial(polynomial);
                    break;
                case 3:
                    ShowPolynomials(polynomial);
                    ChoosePolynomials(polynomial, out numberFirstPolynomial, out numberSecondPolynomial);
                    if(CheckValues(polynomial,  numberFirstPolynomial, numberSecondPolynomial))
                    {
                        secondPolynomial.AddRange(polynomial[numberSecondPolynomial].Coefficients);
                        polynomial.Add(polynomial[numberFirstPolynomial].AddPolynomials(secondPolynomial));
                        Console.WriteLine("\nНовий многочлен = " + polynomial[polynomial.Count - 1].ShowPolynomial());
                    }

                    break;
                case 4:
                    ShowPolynomials(polynomial);
                    ChoosePolynomials(polynomial, out numberFirstPolynomial, out numberSecondPolynomial);
                    if(CheckValues(polynomial,  numberFirstPolynomial, numberSecondPolynomial))
                    {
                        secondPolynomial.AddRange(polynomial[numberSecondPolynomial].Coefficients);
                        polynomial.Add(polynomial[numberFirstPolynomial].SubtractPolynomials(secondPolynomial));
                        Console.WriteLine("\nНовий многочлен = " + polynomial[polynomial.Count - 1].ShowPolynomial());
                    }

                    break;
                case 5:
                    ShowPolynomials(polynomial);
                    ChoosePolynomials(polynomial, out numberFirstPolynomial, out numberSecondPolynomial);
                    if(CheckValues(polynomial,  numberFirstPolynomial, numberSecondPolynomial))
                    {
                        secondPolynomial.AddRange(polynomial[numberSecondPolynomial].Coefficients);
                        polynomial.Add(polynomial[numberFirstPolynomial].MultiplyPolynomials(secondPolynomial));
                        Console.WriteLine("\nНовий многочлен = " + polynomial[polynomial.Count - 1].ShowPolynomial());
                    }

                    break;
                case 6:
                    Console.Write("Оберіть назву файла: ");
                    name = Console.ReadLine();
                    jsonFiles.SavePolynomialInFile(name, polynomial);
                    break;
                case 7:
                    Console.Write("Оберіть назву файла: ");
                    name = Console.ReadLine();
                    if (jsonFiles.ReadPolynomialsFromFile(name, polynomial) != null)
                        polynomial = jsonFiles.ReadPolynomialsFromFile(name, polynomial);
                    break;
                case 8:
                    isWork = false;
                    break;
                default:
                    Console.WriteLine("\nВведіть правильний номер!");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    private void ShowPolynomials(List<Polynomial> polynomial)
    {
        for (int i = 0; i < polynomial.Count; i++)
            Console.WriteLine($"{i + 1} - многочлен = " + polynomial[i].ShowPolynomial());
    }

    private void Calculatepolynomial(List<Polynomial> polinomials)
    {
        ShowPolynomials(polinomials);
        try
        {
            Console.Write("\nОберіть номер многочлена, який потрібно обчислити: ");
            int numberOfPolynomial = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Оберіть значення x: ");
            int x = int.Parse(Console.ReadLine());
            if (numberOfPolynomial < polinomials.Count && numberOfPolynomial>=0)
                Console.WriteLine($"\nAnswer of {numberOfPolynomial + 1} polynomial = " +
                                  polinomials[numberOfPolynomial].SolvePolynomial(x));
            else
                Console.WriteLine("\nІндекс повинен бути більше нуля!");
        }
        catch (FormatException e)
        {
            Console.WriteLine("\nВведене значення не є цілим числом: " + e.Message);
        }
    }
    
    private void ChoosePolynomials(List<Polynomial> polynomials, out int numberFirstPolynomial,
        out int numberSecondPolynomial)
    {
        try
        {
            Console.Write("\nОберіть номер першого многочлена: ");
            numberFirstPolynomial = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Оберіть номер другого многочлена: ");
            numberSecondPolynomial = int.Parse(Console.ReadLine()) - 1;
        }
        catch (FormatException e)
        {
            numberFirstPolynomial = polynomials.Count + 1;
            numberSecondPolynomial = polynomials.Count + 1;
            Console.WriteLine("Введене значення не є цілим числом: " + e.Message);
        }
    }

    private bool CheckValues(List<Polynomial> polynomial,int numberFirstPolynomial,int numberSecondPolynomial)
    {
        bool isCorrect = false;
        if (numberFirstPolynomial < 0 || numberSecondPolynomial < 0)
        {
            Console.WriteLine("\nІндекс повинен бути більше нуля!");
        }
        else if (numberFirstPolynomial > polynomial.Count || numberSecondPolynomial > polynomial.Count)
        {
            Console.WriteLine("\nТакого многочлена не існує!");
        }
        else
        {
            isCorrect = true;
        }
        return isCorrect;
    }
}