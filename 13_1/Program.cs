using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;

namespace _13_1
{
    internal class Program
    {
        delegate int Transformer(int a);

        static void Main(string[] args)
        {
            int[] arr = Creator(10);
            Console.WriteLine("-Тест 1 - УДВОЕНИЕ\nВходной массив:");
            Printer(arr);
            int[] newarr = Transform(arr, Doubler);
            Console.WriteLine("Выходной массив:");
            Printer(newarr);







            Console.WriteLine("Press any key..");
            Console.ReadKey();
        }

        static int[] Transform(int[] nums, Transformer trans)

        {
            int len = nums.Length;
            int[] retarr = new int[len];
            int index = 0;
            foreach (var num in nums)
            {
                retarr[index] = trans(num);
                index++;
            }
            return retarr;
        }
        static int Doubler(int a)
        {
            return a * 2;
        }
        static int Squarer(int a)
        {
            return a * a;
        }
        static int Moduler(int a)
        {
            if (a < 0) return a * -1;
            return a;
        }
        static int[] Creator(int n)
        {
            Random rnd = new Random();
            int[] testarr = new int[n];
            for (int i = 0; i < n; i++)
            {
                testarr[i] = rnd.Next(-99, 100);
            }
            return testarr;
        }
        static void Printer(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n");
        }

    }
}
