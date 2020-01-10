namespace RunescapeConsole.Models
{
    class Skill
    {
        public string Name { get; set; }

        public int Rank { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public Skill()
        {

        }

        public bool isMax()
        {
            if ((this.Name == "Overall" && this.Level == 2277) || this.Level == 99)
            {
                return true;
            }

            return false;
        }

    }
}
