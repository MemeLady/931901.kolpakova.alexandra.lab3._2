using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class Quiz
    {
        public int rightAnswersCount { get; set; }
        public int answersCount { get; set; }
        public List<string> Results { get; set; } = new List<string>();
        public int curRightAnswersCount { get; set; } = 0;
        public int curAnswersCount { get; set; } = 0;
        public List<string> curResults { get; set; } = new List<string>();

        public void ResetCurrentValue()
        {
            curRightAnswersCount = curAnswersCount = 0;
            curResults.Clear();
        }

        public void UpdateValue(int hanswer, string hexpression, int answer)
        {
            curAnswersCount += 1; answersCount += 1;
            if (hanswer == answer)
            {
                rightAnswersCount += 1;
                curRightAnswersCount += 1;
            }
            curResults.Add(hexpression + " = " + answer);
            Results.Add(hexpression + " = " + answer);
        }
    }
}
