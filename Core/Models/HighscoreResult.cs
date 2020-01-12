using Core.Enums;
using System;
using System.Linq;

namespace Core.Models
{
    public class HighscoreResult
    {
        public string[] Skills { get; private set; }

        public string[] Activities { get; private set; }

        public HighscoreResult(string apiResults)
        {
            string[] parsedResults = ParseAPIResults(apiResults);

            this.Skills = parsedResults.Take(Enum.GetNames(typeof(Skills)).Length).ToArray(); ;
            this.Activities = parsedResults.TakeLast(Enum.GetNames(typeof(Activities)).Length).ToArray();
        }

        private string[] ParseAPIResults(string apiResults)
        {
            string[] parsedHighscoreResults = apiResults.Split("\n");

            // Drop the last element which is an empty line
            parsedHighscoreResults = parsedHighscoreResults.Take(parsedHighscoreResults.Count() - 1).ToArray();

            return parsedHighscoreResults;
        }
    }
}
