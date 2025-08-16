using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Activity_19
{
    class Question
    {
        public string Text;
        public string Topic;
        public string Difficulty;

        public Question(string text, string topic, string difficulty)
        {
            Text = text;
            Topic = topic;
            Difficulty = difficulty;
        }
    }
    class Program
    {
        static void Main()
        {
            List<Question> bank = new List<Question>()
        {
            new Question("What is 2+2?", "Math", "Easy"),
            new Question("What is PI?", "Math", "Medium"),
            new Question("Solve x+3=5", "Math", "Easy"),
            new Question("Capital of France?", "Geo", "Easy"),
            new Question("Largest country?", "Geo", "Medium"),
            new Question("River in Egypt?", "Geo", "Easy"),
            new Question("Who wrote Hamlet?", "Lit", "Medium"),
            new Question("Synonym of 'happy'?", "Lit", "Easy"),
            new Question("What is irony?", "Lit", "Medium")
        };

            string[] topics = { "Math", "Geo", "Lit" };
            string[] diffs = { "Easy", "Easy", "Medium" };
            int[] counts = { 2, 1, 1 };

            Random rnd = new Random(42); 
            List<Question> quiz = new List<Question>();

            for (int i = 0; i < topics.Length; i++)
            {
                string topic = topics[i];
                string diff = diffs[i];
                int need = counts[i];

                List<Question> matches = new List<Question>();
                foreach (Question q in bank)
                {
                    if (q.Topic == topic && q.Difficulty == diff)
                    {
                        matches.Add(q);
                    }
                }
                if (matches.Count < need)
                {
                    Console.WriteLine("Not enough questions for " + topic + " - " + diff);
                    quiz.AddRange(matches);
                }
                else
                {
                    List<int> usedIndexes = new List<int>();
                    while (usedIndexes.Count < need)
                    {
                        int idx = rnd.Next(matches.Count);
                        if (!usedIndexes.Contains(idx))
                        {
                            usedIndexes.Add(idx);
                            quiz.Add(matches[idx]);
                        }
                    }
                }
            }

            Console.WriteLine("\nGenerated Quiz:");
            int num = 1;
            foreach (Question q in quiz)
            {
                Console.WriteLine(num + ". [" + q.Topic + "/" + q.Difficulty + "] " + q.Text);
                num++;
            }
        }
    }
}
            
