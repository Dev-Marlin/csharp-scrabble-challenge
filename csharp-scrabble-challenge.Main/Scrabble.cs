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
        Dictionary<char, int> LetterScores = new Dictionary<char, int>();

        private string word;
        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            this.word = word.ToUpper();

            GiveScoreToChar(LetterScores);
        }

        public int score()
        {
            int Score = 0;
            int LetterModifier = 1;
            int WordModifier = 1;
            List<char> Brackets = new List<char>();

            foreach (char c in word)
            {
                if(c == '[' || c == '{' )
                {
                    Brackets.Add(c);

                    if (c == '[')
                        LetterModifier = 3;

                    if (c == '{')
                        LetterModifier = 2;

                    continue;
                }

                if (c == ']')
                {
                    if (Brackets[Brackets.Count - 1] == '[')
                    {
                        LetterModifier = 1;
                    }
                    else
                    {
                        Score = 0;
                        break;
                    }

                continue;
                }
                else if (c == '}')
                {
                    if (Brackets[Brackets.Count - 1] == '{')
                    {
                        LetterModifier = 1;
                    }
                    else
                    {
                        Score = 0;
                        break;
                    }

                continue;
                }

                if (LetterScores.ContainsKey(c))
                {
                    Score += LetterModifier * LetterScores[c];
                }
                else
                {
                    Score = 0;
                    break;
                }
            }
            return WordModifier * Score;
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
