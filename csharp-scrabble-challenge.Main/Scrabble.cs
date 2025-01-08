using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        //private Dictionary<char[], int> LetterScores = new Dictionary<char[], int>();
        Dictionary<char, int> LetterScores = new Dictionary<char, int>();

        private string word;
        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            this.word = word.ToUpper();

            GiveScoreToChar(LetterScores);
            /*
            LetterScores.Add(['A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'], 1);
            LetterScores.Add(['D', 'G'], 2);
            LetterScores.Add(['B', 'C', 'M', 'P'], 3);
            LetterScores.Add(['F', 'H', 'V', 'W', 'Y'], 4);
            LetterScores.Add(['K'], 5);
            LetterScores.Add(['J', 'X'], 8);
            LetterScores.Add(['Q', 'Z'], 10);
            */
        }

        public int score()
        {
            int Score = 0;
            int LetterModifier = 1;
            int WordModifier = WordModifierValue(word);
            int CurlyBracketCounter = 0;
            int BracketCounter = 0;

            /*
            Regex LetterDoublePattern = new Regex("[{][A-Z]{1}[}]");
            Regex LetterTripplePattern = new Regex("[[][A-Z]{1}[]]");
            Regex WordDoublePattern = new Regex("[{][A-Z][}]");
            Regex WordTripplePattern = new Regex("[[][A-Z][]]");

            if(WordDoublePattern.IsMatch(word))
            {
                WordModifier = 2;
            }
            else if (WordTripplePattern.IsMatch(word))
            {
                WordModifier = 3;
            }*/


            foreach (char c in word)
            {
                if(c == '[' || c == ']' || c == '{' || c == '}')
                {
                    continue;
                }

                if (LetterScores.ContainsKey(c))
                {
                    Score += LetterModifier * LetterScores[c];
                }
            }

            return WordModifier * Score;
        }

        private int WordModifierValue(string word)
        {
            if (word.Length < 3)
                return 1;

            char start = word[0];
            char end = word[word.Length - 1];

            if (start == '[' && end == ']')
                return 3;

            if (start == '{' && end == '}')
                return 2;

            return 1;
        }

        private void GiveScoreToChar(Dictionary<char, int> LetterScores)
        {
            //1 point chars
            LetterScores.Add('A', 1);
            LetterScores.Add('E', 1);
            LetterScores.Add('I', 1);
            LetterScores.Add('O', 1);
            LetterScores.Add('U', 1);
            LetterScores.Add('L', 1);
            LetterScores.Add('N', 1);
            LetterScores.Add('R', 1);
            LetterScores.Add('S', 1);
            LetterScores.Add('T', 1);

            //2 point chars
            LetterScores.Add('D', 2);
            LetterScores.Add('G', 2);

            //3 point chars
            LetterScores.Add('B', 3);
            LetterScores.Add('C', 3);
            LetterScores.Add('M', 3);
            LetterScores.Add('P', 3);

            //4 point chars
            LetterScores.Add('F', 4);
            LetterScores.Add('H', 4);
            LetterScores.Add('V', 4);
            LetterScores.Add('W', 4);
            LetterScores.Add('Y', 4);

            //5 point chars
            LetterScores.Add('K', 5);

            //8 point chars
            LetterScores.Add('J', 8);
            LetterScores.Add('X', 8);

            //10 point chars
            LetterScores.Add('Q', 10);
            LetterScores.Add('Z', 10);
        }
    }
}
