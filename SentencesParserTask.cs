using System;
using System.Collections.Generic;
using System.Linq;

//В этом задании нужно реализовать метод в классе SentencesParserTask. Метод должен делать следующее:

//Разделять текст на предложения, а предложения на слова.

//a. Считайте, что слова состоят только из букв (используйте метод char.IsLetter) или символа апострофа ' и отделены друг от друга любыми другими символами.

//b. Предложения состоят из слов и отделены друг от друга одним из следующих символов .!?;:()

//Приводить символы каждого слова в нижний регистр.

//Пропускать предложения, в которых не оказалось слов.

//Метод должен возвращать список предложений, где каждое предложение — это список из одного или более слов в нижнем регистре.

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var sentecearray = text.Split(new Char[] { '.', '!', '?', ';', ':', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sentence in sentecearray)
            {
                List<string> temp = ParseWords(sentence);
                if (temp.Count != 0)
                    sentencesList.Add(temp);
            }
            return sentencesList;
        }
        public static List<string> ParseWords(string sentence)
        {
            List<string> words = new List<string>();
            char[] chararray = sentence.ToCharArray();
            string[] wordsarray = sentence.Split(chararray.Where(ch => !char.IsLetter(ch) && ch != '\'').ToArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in wordsarray)
                words.Add(word.ToLower());
            return words;
        }
    }
}