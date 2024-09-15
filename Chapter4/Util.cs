using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    public class Util
    {
        public delegate void ProgressReporter(int percentComplete);

        public delegate T Transformer<T>(T arg);

        public interface ITransformer
        {
            int Transform(int x);
        }

        public class Squarer : ITransformer
        {
            public int Transform(int x) => x * x;
        }
        public class Cuber : ITransformer
        {
            public int Transform(int x) => x * x * x;
        }

        public static void HardWork(ProgressReporter p)
        {
            for (int i = 0; i < 10; i++)
            {
                p(i * 10); // Invoke delegate
                System.Threading.Thread.Sleep(100); // Simulate hard work
            }
        }
        public static void PrintTitle(string title) => Console.WriteLine(title.PadRight(30 , '*').PadLeft(40 , '*'));

        public static void WriteProgressToConsole(int percentComplete) => Console.WriteLine(percentComplete);
        public static void WriteProgressToFile(int percentComplete) => File.WriteAllText("progress.txt", percentComplete.ToString());



        public static void Transform<T>(T[] values, Transformer<T> t)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = t(values[i]);
        }

        public static void TransformAll(int[] values, ITransformer t)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = t.Transform(values[i]);
        }
    }
}
