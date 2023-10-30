class Ar
{
    private int n; 
    private int[] arr;
    private int k; 

    public int N => n; 

    public int K => k; 

    public Ar(int a, int b) 
    {
        Random rand = new Random();
        n = rand.Next(1, 101); 
        arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            int rand_value = rand.Next(a, b + 1);
            int sign = rand.Next(1, 3);
            if (sign == 1)
            {
                arr[i] = rand_value; 
            }
            else
            {
                arr[i] = -rand_value; 
            }
            if (arr[i] % 2 == 0) 
                k++;
        }
    }

    public Ar(string input) 
    {
        char[] delimiter = { ':' };
        string[] tokens = input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        n = tokens.Length;
        arr = new int[n];
        k = 0;

        for (int i = 0; i < n; i++)
        {
            int value = int.Parse(tokens[i]);
            arr[i] = value;
            if (value % 2 == 0) 
                k++;
        }
    }

    public void Print() 
    {
        Console.WriteLine("Масив:");
        Console.WriteLine(string.Join(" ", arr));
    }

    public int P() 
    {
        for (int i = 0; i < n; i++)
        {
            if (arr[i] > 0)
                return i;
        }
        return -1; 
    }

    public int Pr(int i1, int i2) 
    {
        if (i1 < 0 || i2 >= n || i1 > i2)
            return 0; 
        return arr.Skip(i1).Take(i2 - i1 + 1).Aggregate(1, (x, y) => x * y);
    }

    public void Dispose() 
    {
        arr = null;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Random rand = new Random();

        Console.WriteLine("Оберіть конструктор (1 або 2): ");
        int choice = int.Parse(Console.ReadLine());

        Ar ar = null;

        if (choice == 1)
        {
            Console.Write("Введіть a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введіть b: ");
            int b = int.Parse(Console.ReadLine());
            ar = new Ar(a, b);
        }
        else if (choice == 2)
        {
            Console.Write("Введіть рядок з числами, розділеними символом «:»: ");
            string input = Console.ReadLine();
            ar = new Ar(input);
        }
        else
        {
            Console.WriteLine("Неправильний вибір конструктора.");
            return;
        }

        ar.Print();
        Console.WriteLine("Кількість парних елементів: " + ar.K);

        int firstPositiveIndex = ar.P();
        if (firstPositiveIndex != -1)
        {
            Console.WriteLine("Індекс першого позитивного елементу: " + firstPositiveIndex);
            Console.WriteLine("Добуток елементів правіше від знайденого: " + ar.Pr(firstPositiveIndex + 1, ar.N - 1));
        }
        else
        {
            Console.WriteLine("Позитивних елементів немає.");
        }
    }
}
