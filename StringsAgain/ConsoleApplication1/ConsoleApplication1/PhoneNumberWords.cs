using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class PhoneNumberWords
    {
        public IList<string> GetValidWordsFromDigits(string number, HashSet<string> dictionary)
        {
            IList<string> res = new List<string>();
            if(number == null || number.Length ==0)
            {
                return res;
            }

            IDictionary<string, IList<string>> numberToWordMapping = NumberToValidWordsMapping(dictionary);

            if(numberToWordMapping.ContainsKey(number))
            {
                IList<string> words = numberToWordMapping[number];
                foreach(string word in words)
                {
                    res.Add(word);
                }
            }

            return res;
        }

        //private IDictionary<char, IList<char>> GetDigitToCharactersMapping()
        //{
        //    IDictionary<char, IList<char>> digitToCharMapping = new Dictionary<char, IList<char>>();
        //    digitToCharMapping.Add('1', new List<char>() { ' ' });
        //    digitToCharMapping.Add('2', new List<char>() { 'a','b','c' });
        //    digitToCharMapping.Add('3', new List<char>() { 'd', 'e', 'f' });
        //    digitToCharMapping.Add('4', new List<char>() { 'g', 'h', 'i' });
        //    digitToCharMapping.Add('5', new List<char>() { 'j', 'k', 'l' });
        //    digitToCharMapping.Add('6', new List<char>() { 'm', 'n', 'o' });
        //    digitToCharMapping.Add('7', new List<char>() { 'p', 'q', 'r', 's' });
        //    digitToCharMapping.Add('8', new List<char>() { 't', 'u', 'v' });
        //    digitToCharMapping.Add('9', new List<char>() { 'w', 'x', 'y','z' });
        //    digitToCharMapping.Add('0', new List<char>() { ' '});

        //    return digitToCharMapping;

        //}

        private IDictionary<char, char> GetCharacterToDigitMapping()
        {
            IDictionary<char, char> dic = new Dictionary<char, char>();
            dic.Add('a', '2');
            dic.Add('b', '2');
            dic.Add('c', '2');
            dic.Add('d', '3');
            dic.Add('e', '3');
            dic.Add('f', '3');
            dic.Add('g', '4');
            dic.Add('h', '4');
            dic.Add('i', '4');
            dic.Add('j', '5');
            dic.Add('k', '5');
            dic.Add('l', '5');
            dic.Add('m', '6');
            dic.Add('n', '6');
            dic.Add('o', '6');
            dic.Add('p', '7');
            dic.Add('q', '7');
            dic.Add('r', '7');
            dic.Add('s', '7');
            dic.Add('t', '8');
            dic.Add('u', '8');
            dic.Add('v', '8');
            dic.Add('w', '9');
            dic.Add('x', '9');
            dic.Add('y', '9');
            dic.Add('z', '9');

            return dic;
        }

        private IDictionary<string, IList<string>> NumberToValidWordsMapping(HashSet<string> inputWords)
        {
            IDictionary<string, IList<string>> numberToWordsMapping = new Dictionary<string, IList<string>>();
            IDictionary<char, char> charToDigitMapping = GetCharacterToDigitMapping();

            foreach(string word in inputWords)
            {
                StringBuilder sb = new StringBuilder();
                foreach(char c in word)
                {
                    if(charToDigitMapping.ContainsKey(c))
                    {
                        sb.Append(charToDigitMapping[c]);
                    }
                }
                string digitWord = sb.ToString();
                if(!numberToWordsMapping.ContainsKey(digitWord))
                {
                    numberToWordsMapping.Add(digitWord, new List<string>());
                }
                numberToWordsMapping[digitWord].Add(word);
            }

            return numberToWordsMapping;

        }
    }
}
