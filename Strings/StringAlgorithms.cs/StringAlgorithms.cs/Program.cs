using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strings.BasicQuestions;
using StringDataStructures;
using StringDataStructures.cs;

namespace StringAlgorithms.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "abc";

            //var results = GetPermutations(input);

            // var results = GetUniquePermutations(input);
            //PrintResults(results);

            //GetCombinationsUnique(input); 

            //string org = "This is   America                       ";
            //Console.WriteLine(ReverseString(org));

            //string uncompressed = "aabbc";
            //string compressed = RLE(uncompressed);
            //Console.WriteLine(compressed);

            string[] trieInputs = new string[]
            {
                "cat",
                "cap",
                "bat",
                "back",
                "alpha"
            };

            //Trie trie = new Trie();
            //trie.AddToTrie(trieInputs);
            //trie.Root.PrintTrieContents();

            //bool containsPrefix = trie.Root.Search("cap");
            //Console.WriteLine(containsPrefix);

            // TODO: RLE DECODING
            //string encoded = "10a2b2c";
            //Console.WriteLine(RunLengthDecoding2(encoded));

            string text = "banana";
            string pattern = "ana";
            SuffixArray2 s = new SuffixArray2(text);
            //int startOfPattern = s.GetCount(text, pattern);
            IList<int> CountOccurences = s.GetCount(text, pattern);

            string i = "e";
            Console.ReadLine();
        }

        /// <summary>
        /// Eg: In "abc". Imagine we already have all permutations of b and c
        /// Now all we need to do is iterate over those permutations and add the remaining character 'a' in all
        /// possible positions in each of the remaining permutations
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static IList<string> GetPermutations(string s)
        {
            if (s == null) return null;

            IList<string> perms = new List<string>();
            if (s.Length == 0)
            {
                perms.Add("");
                return perms;
            }

            IList<string> remainingPermutations = GetPermutations(s.Substring(1));
            char current = s[0];
            foreach (string perm in remainingPermutations)
            {
                // Note the = sign. this is required when we want to include the character at end.
                for (int i = 0; i <= perm.Length; i++)
                {
                    string overallPerm = ConstructPermutatedString(perm, current, i);
                    perms.Add(overallPerm);
                }
            }
            return perms;
        }

        static string ConstructPermutatedString(string existingString, char charToInclude, int index)
        {
            string left = existingString.Substring(0, index);
            string right = existingString.Substring(index);
            return left + charToInclude + right;
        }

        static IList<string> GetUniquePermutations(string s)
        {
            if (s == null) return null;
            IList<string> results = new List<string>();

            IDictionary<char, int> map = new Dictionary<char, int>();
            //Keep a count of all characters
            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                {
                    map[c] += 1;
                }
                else
                {
                    map.Add(c, 1);
                }
            }

            GetUniquePermutationsHelper(map, "", s.Length, results);
            return results;
        }

        static void GetUniquePermutationsHelper(IDictionary<char, int> dictionary, string prefix, int remainingLength, IList<string> results)
        {
            if (remainingLength == 0)
            {
                results.Add(prefix);
            }
            else
            {
                // loop through all characters in dictionary
                IList<char> keys = new List<char>(dictionary.Keys);
                foreach (char c in keys)
                {
                    if (dictionary[c] > 0)
                    {

                        dictionary[c]--;
                        GetUniquePermutationsHelper(dictionary, prefix + c, remainingLength - 1, results);

                        //Add it back after returning from the call that included this character as the prefix
                        dictionary[c]++;
                    }
                }
            }
        }

        static void PrintResults(IList<string> results)
        {
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        static IList<string> GetCombinations(string s)
        {
            if (s == null) return null;
            IList<string> results = new List<string>();
            GetCombinationsHelper(s, ref results);
            return results;
        }

        static void GetCombinationsHelper(string s, ref IList<string> results)
        {
            if (s.Length == 0)
            {
                results.Add("");
                return;
            }

            char first = s[0];
            GetCombinationsHelper(s.Substring(1), ref results);
            IList<string> copy = new List<string>(results);
            foreach (string res in copy)
            {
                results.Add(first + res);
            }
        }

        static void GetCombinationsUnique(string s)
        {
            if (s == null) return;
            if (s.Length == 0) return;

            StringBuilder sb = new StringBuilder();
            int recur_length = 0;
            int start_length = 0;
            GetCombinationsUniqueHelper(s, sb, start_length, recur_length);

        }

        static void GetCombinationsUniqueHelper(string input, StringBuilder output, int start, int recurLength)
        {

            for (int i = start; i < input.Length; i++)
            {
                output.Append(input[i]);
                Console.WriteLine(output);
                //PrintCombination(output, i, recurLength);
                if (i < input.Length - 1)
                {
                    GetCombinationsUniqueHelper(input, output, i + 1, recurLength + 1);
                }

                //This step will make sure that output array has right number of elements.               
                output.Length = output.Length - 1;
            }

        }

        static string ReverseString(String s)
        {
            if (s == null) return null;
            if (s.Length == 0 || s.Length == 1) return s;
            char[] input = s.ToArray();
            ReverseStringHelper(input, 0, input.Length - 1);

            // Fix the actual words;
            //int fix = 0;
            //int start;
            //while (true)
            //{
            //    while (fix < input.Length && input[fix] == ' ')
            //    {
            //        fix++;
            //    }
            //    if (fix == input.Length)
            //    {
            //        break; ;
            //    }

            //    start = fix;
            //    while (fix < input.Length && input[fix] != ' ')
            //    {
            //        fix++;
            //    }
            //    ReverseStringHelper(input, start, fix - 1);
            //}

            int end = 0;
            int start;
            while (end < input.Length)
            {
                if (input[end] == ' ')
                {
                    end++;
                }
                else
                {
                    start = end;
                    while (end < input.Length && input[end] != ' ')
                    {
                        end++;
                    }
                    ReverseStringHelper(input, start, end - 1);
                    end++;

                }

            }
            return new string(input);
        }

        static void ReverseStringHelper(char[] input, int start, int end)
        {
            char temp;
            while (start < end)
            {
                temp = input[start];
                input[start] = input[end];
                input[end] = temp;
                start++;
                end--;
            }
        }

        static string RLE(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            if (s.Length <= 2) return s;
            else
            {
                StringBuilder sb = new StringBuilder();
                int i = 1;
                sb.Append(s[i - 1]);
                int count = s.Length;
                int char_count = 1;
                while (i < s.Length)
                {
                    if (s[i] == s[i - 1])
                    {
                        char_count++;
                    }
                    else
                    {
                        sb.Append(char_count);
                        char_count = 1;
                        sb.Append(s[i]);
                        if (sb.Length >= count)
                        {
                            return s;
                        }
                    }
                    i++;
                }
                sb.Append(char_count);
                return sb.ToString();

            }
        }

        static string RunLengthDecoding(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            if (s.Length == 1) return s;
            int index = 0;
            int count = 0;

            StringBuilder finalStringBuilder = new StringBuilder();

            while (index < s.Length)
            {
                char currentChar = s[index];
                if (currentChar >= '0' && currentChar <= '9')
                {
                    //Increment the previous value by 10
                    count = 10 * count + (currentChar - '0');
                    index++;
                }
                else
                {
                    //character after the count
                    for (int i = 0; i < count; i++)
                    {
                        finalStringBuilder.Append(currentChar);
                    }

                    //Clear the original count
                    count = 0;
                    index++;
                }
            }
            return finalStringBuilder.ToString();
        }

        static string GetDecodedString(string toConvert, char ch)
        {

            int value = Int32.Parse(toConvert);
            StringBuilder sb = new StringBuilder();
            while (value > 0)
            {
                sb.Append(ch);
                value--;
            }
            return sb.ToString();
        }

        static bool WordPattern(string pattern, string str)
        {

            return wordPatternHelper(pattern, str);
        }

        static bool wordPatternHelper(string p, string s)
        {
            if (s == null && p == null) return true;

            if (p == null) return false;

            if (s.Length == 0 && p.Length == 0) return true;

            string[] tokens = s.Split(' ');

            if (tokens == null || tokens.Length != p.Length) return false;

            int count = 0;


            StringBuilder sb = new StringBuilder();
            IDictionary<string, char> dic = new Dictionary<string, char>();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (!dic.ContainsKey(tokens[i]))
                {
                    char ch = (char)('a' + count);
                    dic.Add(tokens[i], ch);
                    count++;
                }

                sb.Append(dic[tokens[i]]);
            }

            string res = sb.ToString();

            bool eq = String.Equals(p, res);
            return eq;
        }

    }
}
