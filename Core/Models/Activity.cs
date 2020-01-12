namespace Core.Models
{
    public class Activity
    {
        public string Name { get; private set; }

        private int rank;

        public int Rank
        {
            get
            {
                if (rank < 0)
                    return 0;

                return rank;
            }
            private set { rank = value; }
        }

        private int number;

        public int Number
        {
            get {
                if (number < 0)
                    return 0;

                return number;
            }
            private set { number = value; }
        }


        public Activity(string name, int rank, int number)
        {
            this.Name = name;
            this.Rank = rank;
            this.Number = number;
        }
    }
}
