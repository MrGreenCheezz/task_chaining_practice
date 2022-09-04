using System;
using System.Threading.Tasks;
using System.Linq;

namespace task_chaining_practice
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Task<int[]> task1 = new Task<int[]>(() => GenerateArray());
            Task<int[]> task2 = task1.ContinueWith(task => MultiplyArray(task.Result));
            Task<int[]> task3 = task2.ContinueWith(task => AscendingArraySort(task.Result));
            Task<int> task4 = task3.ContinueWith(task => CalculateAverage(task.Result));

            task1.Start();
            task4.Wait();
            Console.WriteLine("Program ends here!");
        }

        public static int[] GenerateArray()
        {
            var random = new Random();
            int[] resultArray = new int[10];
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = random.Next(0, 200);
            }
            WriteArrayToConsole(resultArray, "GenerateArray");
            return resultArray;
        }

        public static int[] MultiplyArray(int[] inputArray)
        {
            if(inputArray == null)
            {
                throw new ArgumentNullException();
            }

            var random = new Random();
            int[] resultArray = new int[10];
            var randInt = random.Next(0, 200);
            for (int i = 0; i < inputArray.Length; i++)
            {
                resultArray[i] = randInt * inputArray[i];
            }
            WriteArrayToConsole(resultArray, "MultiplyArray by " + randInt);
            return resultArray;
        }

        public static int[] AscendingArraySort(int[] inputArray)
        {
            if(inputArray == null)
            {
                throw new ArgumentNullException();
            }
            var resultArray = from i in inputArray
                              orderby i ascending
                              select i;
            WriteArrayToConsole(resultArray.ToArray(), "AscendingArraySort");
            return resultArray.ToArray();
        }

        public static int CalculateAverage(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException();
            }
            int sum = 0;
            foreach (int i in inputArray)
            {
                sum += i;
            }
            int[] temp = new int[1];
            temp[0] = sum / inputArray.Length;
            WriteArrayToConsole(temp, "CalculateAverage");
            return temp[0];
        }

        public static void WriteArrayToConsole(int[] inputArray, string taskName)
        {
            Console.WriteLine(taskName + ":");
            foreach (int i in inputArray)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine("\n       ");
        }
    }
}
