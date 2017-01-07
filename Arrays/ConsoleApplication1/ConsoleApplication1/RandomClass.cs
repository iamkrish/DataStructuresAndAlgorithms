using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class RandomClass
    {
        // This generates Pseudo random values
        // Do not create multiple instances of random in close time
        private static readonly Random random = new Random();


        //Inclusive of left and right
        private int GetRandom(int min, int max)
        {
            return min + (int)random.Next() * (max - min + 1);
        }

        public void Shuffle(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {

                int k = random.Next(0, i);
                int temp = a[i];
                a[i] = a[k];
                a[k] = temp;

            }
        }

        public void GenerateRandomSetOfMelements(int[] input, int m)
        {

            int[] output = new int[m];

            for (int i = 0; i < m; i++)
            {
                output[i] = input[i];
            }
            
            for (int i = m; i < input.Length; i++)
            {

                int k = random.Next(0, i);

                if (k < m)
                {
                    output[k] = input[i];
                }                
            }

            PrintArray(output);
        }

        private void PrintArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + "  ");
            }
            Console.ReadLine();
        }

    }
}
