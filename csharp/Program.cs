using System;

namespace TextObfuscation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var text = "Always look on the bright side of life!";

            var manager = new TextManager();
            var result = manager.Convert(text);

            Console.WriteLine($"text: {text}");
            Console.WriteLine($"result: {result}");
        }
    }
}
