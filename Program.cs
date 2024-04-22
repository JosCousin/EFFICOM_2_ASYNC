internal class Program
{
    private async static Task Main(string[] args)
    {
        for (int i = 0; i < 2; i++)
        {
            await CreateFile(i);
        }
        for (int i = 0; i < 2; i++)
        {
                    ReadFile(i);

        }
        Console.WriteLine("test");
        Console.ReadLine();
    }

    private async static Task CreateFile(int a)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter($"C:\\Bureau2.0\\EFFICOM 2 ASYNC\\text{a}.txt"))
            {
                for (int i = 0; i < 500000; i++)
                {
                    await sw.WriteLineAsync($"ligne {i}");
                }
            }
            Console.WriteLine("File created successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Fin de création.");
        }
    }

    private async static Task ReadFile(int a)
    {
        try
        {
            using StreamReader sr = new StreamReader($"C:\\Bureau2.0\\EFFICOM 2 ASYNC\\text{a}.txt");
            string line;
            while ((line = await sr.ReadLineAsync()) != null)
            {
                if (line.Contains("2"))
                {
                    Console.WriteLine($"fichier text{a}: {line}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Fin de lecture");
        }
    }
}
