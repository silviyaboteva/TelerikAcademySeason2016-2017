//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _08.Extract_sentences
//{
//    class Program
//    {
//         static void Main(string[] args)
//        {
//            string word = Console.ReadLine();
//            string text = Console.ReadLine();

//            string sentences = ExtractSentencesContainingGivenWord(word, text);
//            Console.WriteLine(sentences);
//        }

//        private static string ExtractSentencesContainingGivenWord(string word, string text)
//        {
//            StringBuilder sentences = new StringBuilder();

//            var seperateSentences = text.Split('.');

//            char[] separator = text.Where(x => !char.IsLetter(x) && x != '.') // Add separator if it is not a letter or '.'.
//                             .Distinct() // Remove repeated characters.
//                             .ToArray(); // Add separators in array.

//            for (int i = 0; i < seperateSentences.Length; i++)
//            {
//                string currentSentence = seperateSentences[i];
               

//                var splittedCurrentSentence = currentSentence.Split(separator);
//                foreach (var wordInSentence in splittedCurrentSentence)
//                {
//                    if (word == wordInSentence)
//                    {
//                        sentences.Append(currentSentence);
//                        sentences.Append('.');
//                        break;
//                    }
//                }
//            }

//            return sentences.ToString();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ExtractSentences
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO : 90/100 fix
            string wordToSearch = Console.ReadLine().ToLower();
            string input = Console.ReadLine();

            Console.WriteLine(Extract(input, wordToSearch));
        }

        public static string Extract(string str, string keyword)
        {
            string[] arr = str.Split('.');
            StringBuilder answer = new StringBuilder();
            char[] separators = GetSeparators(str);
            foreach (string sentence in from sentence in arr let words = sentence.ToLower().Split(separators).ToArray() let isMatch = words.Any(x => x == keyword) where isMatch select sentence)
            {
                answer.Append(sentence + ".");
            }

            return answer.ToString();
        }

        private static char[] GetSeparators(string text)
        {
            return text.Where(x => !char.IsLetter(x) && x != '.').Distinct().ToArray();
        }
    }
}