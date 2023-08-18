
class Program
{
    private static void Main(string[] args)
    {
        String name = "Krishna Reddy";
        Console.WriteLine("name is" + name);
        Console.WriteLine($"name is {name}");

        var age = 23;
        Console.WriteLine($"Age is {age}");
        age = 21;
        Console.WriteLine($"Age is {age}");
        // age = "Krishna"; // cant assign different data type, first time only it will freeze

        dynamic height = 12.34;
        Console.WriteLine($"Height is {height}");
        height = 30;
        Console.WriteLine($"Height is {height}");

    }
}