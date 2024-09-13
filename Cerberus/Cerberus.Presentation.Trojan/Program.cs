using System.Runtime.InteropServices;

public class Program
{

    [DllImport("Cerberus.Malicious.dll")]
    public static extern int testMan();


    private static void Main(string[] args)
    {
        
        Console.WriteLine(testMan());
    }
}