using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            PallindromicPermutations palperm = new PallindromicPermutations();
            var palpermres= palperm.GeneratePalindromes("aba");
            Permutations pra = new Permutations();
            var upperandlower= pra.GetPermutationsUpperAndLower(new char[] { 'h', 'a', 't' });


            StringArrayPermutation spa = new StringArrayPermutation();
            var rspa = spa.GetStringPermutations(new string[] { "red", "fox", "super" });

            EnglishToIntegerWords etoi = new EnglishToIntegerWords();
            string pronoune= etoi.NumberToWords(2147483647);

            LongestWordFromOtherWords lw = new LongestWordFromOtherWords();
            
            string[] longestWords = new string[] { "dog", "cat", "walk","e", "nana", "dogwalker", "banana","ba" };
            string lword = lw.Longest(longestWords);

            //string xyz = TileCase("hello world");



            //PreorderSerialization pre = new PreorderSerialization();
            //bool what = pre.IsValidSerialization(@"531###78##10##");

            //WordPatternProblem wp = new WordPatternProblem();
            //bool j= wp.WordPattern("abba", "dog cat cat dog");

            //Combinations co = new Combinations();
            //var csa = co.PrintAllCombinationsDuplicates(new int[] { 1, 1, 1, 1 });

            Permutations p = new Permutations();
            var l = p.GetPermutations(new int[] { 1, 2, 3, 4 });
            var l1 = p.GetPermutationsDuplicates(new int[] { 1, 2 });
            string a = "  hello  wor ld";
            string[] tok = a.Split(' ');
            MyStrings s = new MyStrings();
            //string rev = s.Reverse("              the   sky  blue");

            ISet<string> set = new HashSet<string>();
            set.Add("hot");
            set.Add("dot");
            set.Add("dog");
            set.Add("lot");
            set.Add("log");
            set.Add("fog");
            //set.Add("fot");

            //WordLadderProblem ladder = new WordLadderProblem();
            //int l =  ladder.GetShortestPath("hot", "dog",set);

            //WordLadderProblem2 ladder2 = new WordLadderProblem2();
            //var res = ladder2.GetWordLadderPath2("hit", "cog", set);


            char[,] matrix = new char[3, 4]
            {
                { 'A', 'B', 'C', 'E' },
                { 'S', 'F', 'C', 'S'},
                { 'A', 'D', 'E', 'E' }
            };


            WordSearch ws = new WordSearch();
            //bool a = ws.WordExists(matrix, "ABCCED");

            char[,] matrix2 = new char[4, 4]
            {
               { 'o', 'a', 'a', 'n' },
               { 'e', 't', 'a', 'e' },
               { 'i', 'h', 'k', 'r' },
               { 'i', 'f', 'l', 'v' }
            };

            string[] dic = new string[]
            {
                "oath","pea","eat","rain","neat"

            };

            WordSearch2 ws2 = new WordSearch2();
            // var res = ws2.FindDictionaryWords(matrix2, dic);

            OneEditDistanceAway oed = new OneEditDistanceAway();
            //bool test = oed.IsOneEditDistance("abcd", "abcdefg");

            Anagrams ana = new Anagrams();
            //ana.GroupStrings(new string[] { "abc", "bcd", "acef", "xyz", "az", "ba", "a", "z" });

            // Pallindrome p = new Pallindrome();
            //var sp = p.ShortestPalindrome("aabba");
            // Console.ReadLine();

            PhoneNumberWords ph = new PhoneNumberWords();
            HashSet<string> validWords = new HashSet<string>() { "money", "tree", "used", "cab", "bac", "ped", "red" };

            ph.GetValidWordsFromDigits("733", validWords);

            Console.ReadLine();
        }

        public static string TileCase(string s)
        {

            //string title = "war and peace";
            //TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            //title = textInfo.ToTitleCase(title)

            // your code goes here

            char[] a = s.ToCharArray();

            int i = 0;
            while (i < a.Length)
            {
                int j = i;
                while (j < a.Length && a[j] != ' ')
                {
                    j++;
                }

                if (j == a.Length)
                {
                    a[i] = (char)(a[i] -32);
                    break;
                }
                else
                {
                    a[i] = (char)(a[i] - 32);
                    i = j + 1;
                }
            }

            string p = new string(a);
            Console.WriteLine(p);
            return p;
        }
    }
}
